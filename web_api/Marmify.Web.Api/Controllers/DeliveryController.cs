using AutoMapper;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils.Enuns;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marmify.Web.Api.Controllers
{
	[ApiVersion("1")]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[Authorize]
	public class DeliveryController : Controller
	{
		private readonly IDeliveryAppService _deliveryAppService;
		private readonly IMapper _mapper;

		public DeliveryController(IDeliveryAppService deliveryAppService, IMapper mapper)
		{
			_deliveryAppService = deliveryAppService;
			_mapper = mapper;
		}

		// GET: api/v1/delivery
		[HttpGet]
		[Authorize("Bearer", Roles = "Administrator, Establishment")]
		public ActionResult<DeliveryDTO> GetAll(long? establishmentId)
		{
			try
			{
				IEnumerable<DeliveryDTO> deliveryDTOs;
				if (establishmentId == null || establishmentId <= 0)
				{
					deliveryDTOs = _mapper.Map<IEnumerable<DeliveryDTO>>(_deliveryAppService.GetAll(this.User));
				}
				else
				{
					deliveryDTOs = _mapper.Map<IEnumerable<DeliveryDTO>>(
						_deliveryAppService.GetAllByEstablishmentId((long)establishmentId, this.User));
				}

				if (deliveryDTOs == null || !deliveryDTOs.Any())
					return NotFound();

				return Ok(deliveryDTOs);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/v1/delivery/1
		[HttpGet("{id}")]
		[Authorize("Bearer", Roles = "Establishment, User")]
		public ActionResult<DeliveryDTO> GetById(long id)
		{
			try
			{
				DeliveryDTO deliveryDTO = _mapper.Map<DeliveryDTO>(_deliveryAppService.GetById(id, this.User));

				if (deliveryDTO == null)
					return NotFound();

				return Ok(deliveryDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT: api/v1/delivery
		[HttpPut]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult<DeliveryDTO> Edit([FromBody] DeliveryDTO deliveryDTO)
		{
			try
			{
				if (!ModelState.IsValid)
					return UnprocessableEntity(ModelState);

				Delivery delivery = _mapper.Map<Delivery>(_deliveryAppService.GetById(deliveryDTO.Id, this.User));

				if (delivery == null)
					return NotFound();

				var status = DeliveryStatus.Status.Where(x => x.ToString().Equals(deliveryDTO.Status));
				if (status != null)
				{
					delivery.Status = deliveryDTO.Status;

					_deliveryAppService.UpdateEntity(delivery);
					
					return new ObjectResult(deliveryDTO);
				}

				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
