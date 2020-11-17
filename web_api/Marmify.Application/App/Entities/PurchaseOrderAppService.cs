using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Application.Utils.Enuns;
using Marmify.Domain.Commons;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Marmify.Application.App.Entities
{
	public class PurchaseOrderAppService : MarmifyAppServiceBase<PurchaseOrder>, IPurchaseOrderAppService
	{
		private readonly IPurchaseOrderService _purchaseOrderService;
		private readonly IItemAppService _itemAppService;

		public PurchaseOrderAppService(IPurchaseOrderService purchaseOrderService,
			IItemAppService itemAppService)
				: base(purchaseOrderService)
		{
			_purchaseOrderService = purchaseOrderService;
			_itemAppService = itemAppService;
		}

		public PurchaseOrder CreatePurchaseOrder(PurchaseOrder purchaseOrder)
		{
			Delivery delivery = new Delivery()
			{
				EstablishmentId = purchaseOrder.EstablishmentId,
				DeliveryDate = DateTime.Now,
				Status = EDeliveryStatus.AwaitingPreparation.ToString(),
				TotalDeliveryTime = CalculateDeliveryTime(purchaseOrder.ItemPurchases)
			};

			RemoveReferences(purchaseOrder);
			purchaseOrder.Amount = CaltulateTotal(purchaseOrder.ItemPurchases);
			purchaseOrder.Delivery = delivery;
			purchaseOrder.Status = EPurchaseOrderStatus.RequestReceived.ToString();

			PurchaseOrder purchase = _purchaseOrderService.CreateEntity(purchaseOrder);

			if (purchase != null)
				return purchase;

			return null;
		}

		public IEnumerable<PurchaseOrder> GetAll(ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			if (!string.IsNullOrEmpty(currentUser.Role))
			{
				if (currentUser.Role.Equals(ConstProfiles.Administrator))
					return _purchaseOrderService.GetAll();
				else if (currentUser.Role.Equals(ConstProfiles.Establishment))
					return _purchaseOrderService.GetByInclude(x => x.EstablishmentId == currentUser.EstablishmentId, null);
				else if (currentUser.Role.Equals(ConstProfiles.User))
					return _purchaseOrderService.GetByInclude(x => x.UserId == currentUser.Id, null);
			}

			return null;
		}

		public PurchaseOrder GetById(long id, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			PurchaseOrder purchaseOrder = _purchaseOrderService.GetById(id);
			if (purchaseOrder != null && IsAllowed(currentUser, purchaseOrder))
			{
				return purchaseOrder;
			}

			return null;
		}

		public PurchaseOrder UpdateEntity(PurchaseOrderDTO purchaseOrderDTO, ClaimsPrincipal user)
		{
			PurchaseOrder purchaseOrder = _purchaseOrderService.GetById(purchaseOrderDTO.Id);

			CurrentUser currentUser = new CurrentUser(user);

			if (purchaseOrder != null)
			{
				if (!string.IsNullOrEmpty(currentUser.Role)
					&& currentUser.Role.Equals(ConstProfiles.Establishment))
				{
					var status = PurchaseOrderStatus.Status.Where(x => x.ToString().Equals(purchaseOrderDTO.Status)).FirstOrDefault();

					if (status > 0)
					{
						purchaseOrder.Status = status.ToString();
					}
				}
				else if (string.IsNullOrEmpty(currentUser.Role)
					&& currentUser.Role.Equals(ConstProfiles.User))
					purchaseOrder.PaymentConditionId = purchaseOrderDTO.PaymentConditionId;

				if (_purchaseOrderService.UpdateEntity(purchaseOrder) != null)
					return purchaseOrder;
			}

			return null;
		}

		private bool IsAllowed(CurrentUser user, PurchaseOrder purchaseOrder)
		{
			if (!string.IsNullOrEmpty(user.Role)
				&& (user.Role.Equals(ConstProfiles.Administrator)
				|| (user.Role.Equals(ConstProfiles.Establishment)
						&& user.EstablishmentId == purchaseOrder.EstablishmentId)
				|| (user.Role.Equals(ConstProfiles.User)
						&& user.Id == purchaseOrder.UserId)))
			{
				return true;
			}

			return false;
		}

		private decimal CaltulateTotal(IEnumerable<ItemPurchase> itemPurchases)
		{
			decimal total = 0.0M;

			foreach (var item in itemPurchases)
			{
				total += (item.ItemValue * item.ItemQuantity);
			}

			return total;
		}

		private void RemoveReferences(PurchaseOrder purchaseOrder)
		{
			purchaseOrder.User = null;
			purchaseOrder.Establishment = null;
			purchaseOrder.PaymentCondition = null;
			purchaseOrder.Delivery = null;
			purchaseOrder.DeliveryType = null;
		}

		private int CalculateDeliveryTime(IEnumerable<ItemPurchase> itemPurchases)
		{
			int totalTime = 0;

			foreach (var item in itemPurchases)
			{
				totalTime += (_itemAppService.GetById(item.ItemId).PreparationTime * item.ItemQuantity);
			}

			return totalTime += 60;//60 = Tempo de entrega - Fazer integração com google maps;
		}
	}
}
