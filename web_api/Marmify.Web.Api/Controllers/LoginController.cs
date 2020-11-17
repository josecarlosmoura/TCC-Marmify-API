using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using Marmify.Web.Api.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Marmify.Web.Api.Controllers
{
	[ApiVersion("1")]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[Authorize]
	public class LoginController : Controller
	{
		private readonly IMapper _mapper;
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;

		public LoginController(SignInManager<User> signInManager,
				UserManager<User> userManager,
				IMapper mapper)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_mapper = mapper;
		}

		// POST: api/v1/login
		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Login([FromBody] UserLoginRequestDTO userLoginRequestDTO,
				[FromServices] SigningConfigurations signingConfigurations,
				[FromServices] TokenConfigurations tokenConfigurations)
		{
			try
			{
				bool credentialsIsValid = false;
				if (userLoginRequestDTO != null && !string.IsNullOrEmpty(userLoginRequestDTO.Email))
				{
					User userLogin = _userManager.FindByEmailAsync(userLoginRequestDTO.Email).Result;

					IEnumerable<Address> address = userLogin.Addresses;

					if (userLogin != null)
					{
						var result = await _signInManager.PasswordSignInAsync(userLoginRequestDTO.Email, userLoginRequestDTO.Password, false, true);

						if (result.Succeeded)
						{
							credentialsIsValid = _userManager.IsInRoleAsync(userLogin, userLoginRequestDTO.Role).Result;
						}

						if (credentialsIsValid)
						{
							ClaimsIdentity identity = new ClaimsIdentity(
							new GenericIdentity(userLoginRequestDTO.Email, "Login"),
							new[] {
																new Claim("Id", userLogin.Id.ToString()),
																new Claim("EstablishmentId", userLogin.EstablishmentId.ToString()),
																new Claim("UserName", userLogin.UserName),
												new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
												new Claim(JwtRegisteredClaimNames.UniqueName, userLoginRequestDTO.Email)
									}
							);

							var roles = _userManager.GetRolesAsync(userLogin).Result;

							foreach (string role in roles)
							{
								identity.AddClaim(new Claim(ClaimTypes.Role, role));
							}

							DateTime creationDate = DateTime.Now;
							DateTime expirationDate = creationDate +
									TimeSpan.FromSeconds(tokenConfigurations.Seconds);

							UserLoginResponseDTO userLoginResponseDTO = new UserLoginResponseDTO
							{
								User = _mapper.Map<UserResponseDTO>(userLogin),
								Token = new AuthToken().GemerateToken(signingConfigurations, tokenConfigurations, identity, creationDate, expirationDate),
								CreationDate = creationDate,
								ExpirationDate = expirationDate
							};

							return Ok(userLoginResponseDTO);
						}
					}
					return NotFound();
				}
				return BadRequest("Unable to login.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
