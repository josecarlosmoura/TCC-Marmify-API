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
using Microsoft.AspNetCore.Mvc;

namespace Marmify.Web.Api.Controllers
{
	[ApiVersion("1")]
	[Produces("application/json")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[Authorize("Bearer")]
	public class PaymentConditionController : Controller
	{
		private readonly IPaymentConditionAppSerivce _paymentConditionAppService;
		private readonly IMapper _mapper;

		public PaymentConditionController(IPaymentConditionAppSerivce paymentConditionAppSerivce, IMapper mapper)
		{
			_paymentConditionAppService = paymentConditionAppSerivce;
			_mapper = mapper;
		}

		// GET: api/v1/paymentcondition
		[HttpGet]
		[Authorize("Bearer", Roles = "Administrator, Establishment, User")]
		public ActionResult<PaymentConditionDTO> GetAll(long? establishmentId)
		{
			try
			{
				IEnumerable<PaymentConditionDTO> paymentConditionsDTO;
				if (establishmentId == null || establishmentId <= 0)
				{
					paymentConditionsDTO = _mapper.Map<IEnumerable<PaymentConditionDTO>>(_paymentConditionAppService.GetAll(this.User));
				}
				else
				{
					paymentConditionsDTO = _mapper.Map<IEnumerable<PaymentConditionDTO>>(
						_paymentConditionAppService.GetAllByEstablishmentId((long)establishmentId, this.User));
				}

				if (!paymentConditionsDTO.Any())
					return NotFound();

				return Ok(paymentConditionsDTO);

			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/v1/paymentcondition/{id}
		[HttpGet("{id}")]
		[Authorize("Bearer", Roles = "Administrator, Establishment")]
		public ActionResult<PaymentConditionDTO> GetById(long id)
		{
			try
			{
				PaymentConditionDTO paymentConditionDTO = _mapper.Map<PaymentConditionDTO>(
					_paymentConditionAppService.GetById(id, this.User));

				if (paymentConditionDTO == null)
					return NotFound();

				return Ok(paymentConditionDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST: api/v1/paymentcondition
		[HttpPost]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult<PaymentConditionDTO> Create([FromBody] PaymentConditionDTO paymentConditionDTO)
		{
			try
			{
				CurrentUser currentUser = new CurrentUser(this.User);
				if (!ModelState.IsValid || paymentConditionDTO.EstablishmentId != currentUser.EstablishmentId)
					return BadRequest();

				PaymentCondition paymentCondition = _mapper.Map<PaymentCondition>(paymentConditionDTO);

				if (_paymentConditionAppService.CreateEntity(paymentCondition) != null)
					return Created("/api/v1/paymentcondition", HttpStatusCode.Created);

				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT: api/v1/paymentcondition
		[HttpPut]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult<PaymentConditionDTO> Edit([FromBody] PaymentConditionDTO paymentConditionDTO)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return UnprocessableEntity(ModelState);
				}
				PaymentCondition paymentCondition = _mapper.Map<PaymentCondition>(_paymentConditionAppService.GetById((long)paymentConditionDTO.Id, this.User));

				if (paymentCondition == null)
					return BadRequest();

				paymentCondition.Description = paymentConditionDTO.Description;

				_paymentConditionAppService.UpdateEntity(paymentCondition);

				return new ObjectResult(paymentConditionDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// DELETE: api/v1/paymentcondition/1
		[HttpDelete("{id}")]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult Delete(long id)
		{
			try
			{
				PaymentCondition paymentCondition = _paymentConditionAppService.GetById(id, this.User);

				if (paymentCondition == null)
					return NotFound();

				_paymentConditionAppService.RemoveEntity(paymentCondition);

				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}