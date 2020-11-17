using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils.Enuns;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Marmify.Web.Api.Controllers
{
	[ApiVersion("1")]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[Authorize]
	public class PurchaseOrderController : Controller
	{
		private readonly IPurchaseOrderAppService _purchaseOrderAppService;
		private readonly IDeliveryAppService _deliveryAppService;
		private readonly IMapper _mapper;

		public PurchaseOrderController(IPurchaseOrderAppService purchaseOrderAppService,
			IDeliveryAppService deliveryAppService, IMapper mapper)
		{
			_purchaseOrderAppService = purchaseOrderAppService;
			_deliveryAppService = deliveryAppService;
			_mapper = mapper;
		}

		// GET: api/v1/purchaseorder
		[HttpGet]
		[Authorize("Bearer", Roles = "Administrator, Establishment, User")]
		public ActionResult<PurchaseOrderDTO> GetAll()
		{
			try
			{
				IEnumerable<PurchaseOrderDTO> purchaseOrderDTOs;

				purchaseOrderDTOs = _mapper.Map<IEnumerable<PurchaseOrderDTO>>(_purchaseOrderAppService.GetAll(this.User));

				if (purchaseOrderDTOs != null && purchaseOrderDTOs.Any())
					return Ok(purchaseOrderDTOs);

				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/v1/purchaseorder/{id}
		[HttpGet("{id}")]
		[Authorize("Bearer", Roles = "Administrator, Establishment, User")]
		public ActionResult<PurchaseOrderDTO> GetById(long id)
		{
			try
			{
				PurchaseOrderDTO purchaseOrderDTO = _mapper.Map<PurchaseOrderDTO>(
					_purchaseOrderAppService.GetById(id, this.User));

				if (purchaseOrderDTO == null)
					return NotFound();

				return Ok(purchaseOrderDTO);
			}
			catch (Exception)
			{

				throw;
			}
		}

		// POST: api/v1/purchaseorder
		[HttpPost]
		[Authorize("Bearer", Roles = "User")]
		public ActionResult<PurchaseOrderDTO> Create([FromBody] PurchaseOrderDTO purchaseOrderDTO)
		{
			try
			{
				if (!ModelState.IsValid)
					return UnprocessableEntity(purchaseOrderDTO);

				PurchaseOrder purchaseOrder = _mapper.Map<PurchaseOrder>(purchaseOrderDTO);

				purchaseOrderDTO = _mapper.Map<PurchaseOrderDTO>(_purchaseOrderAppService.CreatePurchaseOrder(purchaseOrder));

				return new ObjectResult(purchaseOrderDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT: api/v1/purchaseorder
		[HttpPut]
		[Authorize("Bearer", Roles = "Establishment, User")]
		public ActionResult<PurchaseOrderDTO> Edit([FromBody] PurchaseOrderDTO purchaseOrderDTO)
		{
			try
			{
				if (!ModelState.IsValid)
					return UnprocessableEntity(purchaseOrderDTO);

				PurchaseOrder purchaseOrder = _purchaseOrderAppService.UpdateEntity(purchaseOrderDTO, this.User);

				if (purchaseOrder == null)
					return NotFound();

				return new ObjectResult(purchaseOrderDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// DELETE: api/v1/purchaseorder/1
		[HttpDelete("{id}")]
		[Authorize("Bearer", Roles = "Administrator")]
		public ActionResult Delete(long id)
		{
			try
			{
				PurchaseOrder purchaseOrder = _purchaseOrderAppService.GetById(id, this.User);

				if (purchaseOrder != null)
				{
					Delivery delivery = _deliveryAppService.GetById(id, this.User);
					if (delivery != null)
					{
						_purchaseOrderAppService.RemoveEntity(purchaseOrder);
						_deliveryAppService.RemoveEntity(delivery);
						return NoContent();
					}
				}

				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}