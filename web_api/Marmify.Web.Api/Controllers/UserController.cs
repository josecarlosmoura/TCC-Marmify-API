using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Domain.Commons;
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
	public class UserController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IUserAppService _userAppService;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<ApplicationRole> _roleManager;

		public UserController(IUserAppService userAppService,
				UserManager<User> userManager,
				RoleManager<ApplicationRole> roleManager,
				IMapper mapper)
		{
			_userAppService = userAppService;
			_roleManager = roleManager;
			_userManager = userManager;
			_mapper = mapper;
		}

		// GET: api/v1/user
		[HttpGet]
		[Authorize("Bearer", Roles = "Administrator")]
		public ActionResult<IEnumerable<UserResponseDTO>> GetAll()
		{
			try
			{
				return Ok(_mapper.Map<IEnumerable<UserResponseDTO>>(_userAppService.GetAll()));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/v1/user/1
		[HttpGet("{id}")]
		[Authorize("Bearer", Roles = "Administrator, Establishment, User")]
		public ActionResult<UserResponseDTO> GetById(long id)
		{
			try
			{
				UserResponseDTO userDTO;
				CurrentUser currentUser = new CurrentUser(this.User);

				if (!string.IsNullOrEmpty(currentUser.Role)
					&& (currentUser.Role.Equals(ConstProfiles.Establishment)
					|| currentUser.Role.Equals(ConstProfiles.User)))
					userDTO = _mapper.Map<UserResponseDTO>(_userAppService.GetById(currentUser.Id));
				else
					userDTO = _mapper.Map<UserResponseDTO>(_userAppService.GetById(id));

				if (userDTO == null)
					return NotFound();

				return Ok(userDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST: api/v1/user
		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Create([FromBody] UserResquestDTO userDTO)
		{
			try
			{
				if (this.User.Claims.Any())
				{
					CurrentUser currentUser = new CurrentUser(this.User);

					if (currentUser.Role.Equals(ConstProfiles.Administrator)
							&& userDTO.Role != (long)EnumProfiles.Establishment)
					{
						return UnprocessableEntity(ModelState);
					}
				}
				else if (!ModelState.IsValid || userDTO.Role != (long)EnumProfiles.User)
				{
					return UnprocessableEntity(ModelState);
				}

				User user = _mapper.Map<User>(userDTO);

				user.EmailConfirmed = true;

				var result = await _userManager.CreateAsync(user, userDTO.Password);

				var role = await _roleManager.FindByIdAsync(userDTO.Role.ToString());

				if (!result.Succeeded || role == null)
					return BadRequest(result.Errors);

				_userManager.AddToRoleAsync(user, role.Name).Wait();

				return Created("/api/v1/login", HttpStatusCode.Created);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT: api/v1/user
		[HttpPut]
		[Authorize("Bearer", Roles = "Administrator, Establishment, User")]
		public async Task<ActionResult> Edit([FromBody] UserUpdateDTO userDTO)
		{
			try
			{
				if (!ModelState.IsValid)
					return UnprocessableEntity(ModelState);

				User user = await _userManager.FindByIdAsync(userDTO.Id.ToString());

				CurrentUser currentUser = new CurrentUser(this.User);

				if (user == null || currentUser.Id != user.Id)
					return NotFound();

				user = _userAppService.UpdateEntity(user, userDTO);

				await _userManager.UpdateAsync(user);

				return Ok(new ObjectResult(userDTO));
			}
			catch (Exception)
			{

				throw;
			}
		}

		// DELETE: api/v1/user/1
		[HttpDelete("{id}")]
		[Authorize("Bearer", Roles = "Administrator")]
		public ActionResult Delete(long id)
		{
			try
			{
				User user = _userAppService.GetById(id);

				if (user == null)
					return NotFound();

				_userAppService.RemoveEntity(user);

				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException);
			}
		}
	}
}