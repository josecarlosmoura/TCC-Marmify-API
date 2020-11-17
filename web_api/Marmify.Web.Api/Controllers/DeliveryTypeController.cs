using AutoMapper;
using Marmify.Application.Interfaces.Entities;
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
	public class DeliveryTypeController : Controller
	{
		private readonly IDeliveryTypeAppService _deliveryTypeAppService;
		private readonly IMapper _mapper;

		public DeliveryTypeController(IDeliveryTypeAppService deliveryTypeAppService, IMapper mapper)
		{
			_deliveryTypeAppService = deliveryTypeAppService;
			_mapper = mapper;
		}

		// GET: api/v1/deliverytype
		[HttpGet]
		[Authorize("Bearer", Roles = "Establishment, User")]
		public ActionResult<DeliveryTypeDTO> GetAll(long? establishmentId)
		{
			try
			{
				IEnumerable<DeliveryTypeDTO> deliveryTypeDTOs;
				if (establishmentId == null || establishmentId <= 0)
				{
					deliveryTypeDTOs = _mapper.Map<IEnumerable<DeliveryTypeDTO>>(_deliveryTypeAppService.GetAll(this.User));
				}
				else
				{
					deliveryTypeDTOs = _mapper.Map<IEnumerable<DeliveryTypeDTO>>(
						_deliveryTypeAppService.GetAllByEstablishmentId((long)establishmentId, this.User));
				}

				if (deliveryTypeDTOs == null && !deliveryTypeDTOs.Any())
					return NotFound();

				return Ok(deliveryTypeDTOs);

			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/v1/deliverytype/1
		[HttpGet("{id}")]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult<DeliveryTypeDTO> GetById(long id)
		{
			try
			{
				DeliveryTypeDTO deliveryDTO = _mapper.Map<DeliveryTypeDTO>(_deliveryTypeAppService.GetById(id, this.User));

				if (deliveryDTO == null)
					return NotFound();

				return Ok(deliveryDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST: api/v1/deliverytype
		[HttpPost]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult<DeliveryTypeDTO> Create([FromBody] DeliveryTypeDTO deliveryTypeDTO)
		{
			try
			{
				if (!ModelState.IsValid)
					return UnprocessableEntity(ModelState);

				DeliveryType deliveryType = _mapper.Map<DeliveryType>(deliveryTypeDTO);

				if (_deliveryTypeAppService.CreateEntity(deliveryType) != null)
					return Created("/api/v1/deliverytype", HttpStatusCode.Created);

				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT: api/v1/deliverytype
		[HttpPut]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult<DeliveryTypeDTO> Edit([FromBody] DeliveryTypeDTO deliveryTypeDTO)
		{
			try
			{
				if (!ModelState.IsValid)
					return UnprocessableEntity(ModelState);

				DeliveryType deliveryType = _mapper.Map<DeliveryType>(_deliveryTypeAppService.GetById(deliveryTypeDTO.Id, this.User));

				if (deliveryType == null)
					return BadRequest();

				deliveryType.Description = deliveryTypeDTO.Description;
				deliveryType.DeliveryValue = deliveryTypeDTO.DeliveryValue;

				_deliveryTypeAppService.UpdateEntity(deliveryType);

				return new ObjectResult(deliveryTypeDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// DELETE: api/v1/deliverytype/1
		[HttpDelete("{id}")]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult Delete(long id)
		{
			try
			{
				DeliveryType deliveryType = _deliveryTypeAppService.GetById(id, this.User);

				if (deliveryType == null)
					return Forbid();

				_deliveryTypeAppService.RemoveEntity(deliveryType);

				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
