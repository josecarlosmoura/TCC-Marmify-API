using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Marmify.Web.Api.Controllers
{
	[ApiVersion("1")]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[Authorize("Bearer")]
	public class EstablishmentController : Controller
	{
		private readonly IEstablishmentAppService _establishmentAppService;
		private readonly IMapper _mapper;

		public EstablishmentController(IEstablishmentAppService establishmentAppService, IMapper mapper)
		{
			_establishmentAppService = establishmentAppService;
			_mapper = mapper;
		}

		// GET: api/v1/establishment
		[HttpGet]
		[Authorize("Bearer", Roles = "Administrator")]
		public ActionResult<EstablishmentDTO> GetAll()
		{
			try
			{
				return Ok(_mapper.Map<IEnumerable<EstablishmentDTO>>(_establishmentAppService.GetAll()));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/v1/establishment/1
		[HttpGet("{id}")]
		[Authorize("Bearer", Roles = "Administrator, Establishment, User")]
		public ActionResult<EstablishmentDTO> GetById(long id)
		{
			try
			{
				EstablishmentDTO establishmentDTO = _mapper.Map<EstablishmentDTO>(_establishmentAppService.GetById(id, this.User));

				if (establishmentDTO == null)
					return NotFound();

				return Ok(establishmentDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST: api/v1/establishment
		[HttpPost]
		[Authorize("Bearer", Roles = "Administrator")]
		public ActionResult<EstablishmentDTO> Create([FromBody] EstablishmentDTO establishmentDTO)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return UnprocessableEntity(ModelState);
				}

				establishmentDTO.ispartner = true;

				Establishment establishment = _mapper.Map<Establishment>(establishmentDTO);

				if (_establishmentAppService.CreateEntity(establishment) != null)
					return Created("/api/v1/establishment", HttpStatusCode.Created);

				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT: api/v1/establishment
		[HttpPut]
		[Authorize("Bearer", Roles = "Administrator, Establishment")]
		public ActionResult<EstablishmentDTO> Edit([FromBody] EstablishmentDTO establishmentDTO)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return UnprocessableEntity(ModelState);
				}

				Establishment establishment = _establishmentAppService.GetById((long)establishmentDTO.Id, this.User);

				if (establishment == null)
					return Forbid();

				establishment.CompanyName = establishmentDTO.CompanyName;
				establishment.Email = establishmentDTO.Email;
				establishment.Phone = establishmentDTO.Phone;
				establishment.Address = establishmentDTO.Address;
				establishment.Number = establishmentDTO.Number;
				establishment.Neighborhood = establishmentDTO.Neighborhood;

				_establishmentAppService.UpdateEntity(establishment);

				return Ok(new ObjectResult(establishmentDTO));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// DELETE: api/v1/establishment/1
		[HttpDelete("{id}")]
		[Authorize("Bearer", Roles = "Administrator")]
		public ActionResult Delete(long id)
		{
			try
			{
				Establishment establishment = _establishmentAppService.GetById(id);

				if (establishment == null)
					return NotFound();

				_establishmentAppService.RemoveEntity(establishment);

				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}