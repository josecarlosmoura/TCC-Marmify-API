using AutoMapper;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Marmify.Web.Api.Controllers
{
	[ApiVersion("1")]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[Authorize]
	public class UserFavoritesController : Controller
	{
		private readonly IUserFavoritesAppService _userFavoritesAppService;
		private readonly IMapper _mapper;

		public UserFavoritesController(IUserFavoritesAppService userFavoritesAppService, IMapper mapper)
		{
			_userFavoritesAppService = userFavoritesAppService;
			_mapper = mapper;
		}

		// GET: api/v1/userfavorites
		[HttpGet]
		[Authorize("Bearer", Roles = "User")]
		public ActionResult<UserFavoritesDTO> GetAllByUser()
		{
			try
			{
				IEnumerable<UserFavoritesDTO> userFavoritesDTO = _mapper.Map<IEnumerable<UserFavoritesDTO>>(
					_userFavoritesAppService.GetAll(this.User));

				if (userFavoritesDTO == null || !userFavoritesDTO.Any())
					return NotFound();

				return Ok(userFavoritesDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/v1/userfavorites
		[HttpPost]
		[Authorize("Bearer", Roles = "User")]
		public ActionResult<UserFavoritesDTO> Create(long establishmentId)
		{
			try
			{
				if (establishmentId <= 0)
					return NotFound();

				if (_userFavoritesAppService.CreateEntity(establishmentId, this.User) != null)
					return Created("/api/v1/userfavorites", HttpStatusCode.Created);

				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// DELETE: api/v1/userfavorites/1
		[HttpDelete("{id}")]
		[Authorize("Bearer", Roles = "User")]
		public ActionResult Delete(long establishmentId)
		{
			try
			{
				UserFavorites userFavorites = _userFavoritesAppService.GetByEstablishment(establishmentId, this.User);

				if (userFavorites == null)
					return Forbid();

				_userFavoritesAppService.RemoveEntity(userFavorites);

				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
