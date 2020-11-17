using System;
using System.Collections.Generic;
using System.Net;
using AutoMapper;
using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Commons;
using Marmify.Application.Interfaces.Entities;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marmify.Web.Api.Controllers
{
	[ApiVersion("1")]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[Authorize]
	public class AddressController : Controller
	{
		private readonly IAddressAppService _addressAppService;
		private readonly IMapper _mapper;
		private readonly ICepService _cepService;

		public AddressController(IAddressAppService addressAppService, IMapper mapper, ICepService cepService)
		{
			_addressAppService = addressAppService;
			_mapper = mapper;
			_cepService = cepService;
		}

		// GET: api/v1/address
		[HttpGet]
		[Authorize("Bearer")]
		public ActionResult<AddressDTO> GetAll()
		{
			try
			{
				return Ok(_mapper.Map<IEnumerable<AddressDTO>>(_addressAppService.GetAll(this.User)));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/v1/address/1
		[HttpGet("{id}")]
		[Authorize("Bearer", Roles = "User")]
		public ActionResult<AddressDTO> GetById(long id)
		{
			try
			{
				AddressDTO addressDTO = _mapper.Map<AddressDTO>(_addressAppService.GetById(id, this.User));

				if (addressDTO == null)
					return NotFound();

				return Ok(addressDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST: api/v1/address
		[HttpPost]
		[Authorize("Bearer", Roles = "User")]
		public ActionResult<AddressDTO> Create([FromBody] AddressDTO addressDTO)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return UnprocessableEntity(ModelState);
				}

				Address address = _mapper.Map<Address>(addressDTO);

				if (_addressAppService.CreateEntity(address) != null)
					return Created("/api/v1/address", HttpStatusCode.Created);

				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT: api/v1/address
		[HttpPut]
		[Authorize("Bearer", Roles = "User")]
		public ActionResult Edit([FromBody] AddressDTO addressDTO)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return UnprocessableEntity(ModelState);
				}

				Address address = _addressAppService.GetById(addressDTO.Id, this.User);

				if (address == null)
					return Forbid();

				address.Street = addressDTO.Street;
				address.Number = addressDTO.Number;
				address.Neighborhood = addressDTO.Neighborhood;
				address.PostalCode = addressDTO.PostalCode;

				_addressAppService.UpdateEntity(address);

				return new ObjectResult(addressDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// DELETE: api/v1/address/1
		[HttpDelete("{id}")]
		[Authorize("Bearer", Roles = "User")]
		public ActionResult Delete(long id)
		{
			try
			{
				Address address = _addressAppService.GetById(id, this.User);

				if (address == null)
					return Forbid();

				_addressAppService.RemoveEntity(address);

				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST: api/v1/address/38400000
		[HttpGet("{cep}")]
		[Authorize("Bearer", Roles = "User")]
		public ActionResult<CepDTO> ValidateCep(string cep)
		{
			if (string.IsNullOrWhiteSpace(cep))
				return BadRequest();

			CepDTO cepDTO = _cepService.GetAddressByCep(cep);

			if (cepDTO != null)
				return Ok(cepDTO);

			return NotFound();
		}
	}
}