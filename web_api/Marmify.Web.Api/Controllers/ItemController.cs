using System;
using System.Collections.Generic;
using System.Net;
using AutoMapper;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
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
	[Authorize("Bearer")]
	public class ItemController : Controller
	{
		private readonly IItemAppService _itemAppService;
		private readonly IMapper _mapper;

		public ItemController(IItemAppService itemAppService, IMapper mapper)
		{
			_itemAppService = itemAppService;
			_mapper = mapper;
		}

		// GET: api/v1/item
		[HttpGet]
		[Authorize("Bearer", Roles = "Administrator, Establishment, User")]
		public ActionResult<ItemDTO> GetAll(long? establishmentId)
		{
			try
			{
				IEnumerable<ItemDTO> itensDTOs;
				if (establishmentId == null || establishmentId <= 0)
				{
					itensDTOs = _mapper.Map<IEnumerable<ItemDTO>>(_itemAppService.GetAll(this.User));
				}
				else
				{
					itensDTOs = _mapper.Map<IEnumerable<ItemDTO>>(
					_itemAppService.GetAllByEstablishmentId((long)establishmentId, this.User));
				}

				if (itensDTOs == null || !itensDTOs.Any())
					return NotFound();

				return Ok(itensDTOs);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/v1/item/1
		[HttpGet("{id}")]
		[Authorize("Bearer", Roles = "Administrator, Establishment, User")]
		public ActionResult<ItemDTO> GetById(long id)
		{
			try
			{
				ItemDTO itemDTO = _mapper.Map<ItemDTO>(_itemAppService.GetById(id, this.User));

				if (itemDTO == null)
					return NotFound();

				return Ok(itemDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST: api/v1/item
		[HttpPost]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult<ItemDTO> Create([FromBody] ItemDTO itemDTO)
		{
			try
			{
				CurrentUser currentUser = new CurrentUser(this.User);

				if (!ModelState.IsValid || itemDTO.EstablishmentId != currentUser.EstablishmentId)
				{
					return UnprocessableEntity(ModelState);
				}

				Item item = _mapper.Map<Item>(itemDTO);

				if (_itemAppService.CreateEntity(item) != null)
					return Created("/api/v1/item", HttpStatusCode.Created);

				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// PUT: api/v1/item
		[HttpPut]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult<ItemDTO> Edit([FromBody] ItemDTO itemDTO)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return UnprocessableEntity(ModelState);
				}
				Item item = _mapper.Map<Item>(_itemAppService.GetById(itemDTO.Id, this.User));

				if (item == null)
					return BadRequest();

				item.Name = itemDTO.Name;
				item.Description = itemDTO.Name;
				item.Value = itemDTO.Value;
				item.Available = itemDTO.Available;
				item.ImagePath = itemDTO.ImagePath;

				_itemAppService.UpdateEntity(item);

				return new ObjectResult(itemDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// DELETE: api/v1/item/1
		[HttpDelete("{id}")]
		[Authorize("Bearer", Roles = "Establishment")]
		public ActionResult Delete(long id)
		{
			try
			{
				Item address = _itemAppService.GetById(id, this.User);

				if (address == null)
					return NotFound();

				_itemAppService.RemoveEntity(address);

				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}