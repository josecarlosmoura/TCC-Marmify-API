using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Domain.Commons;
using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Marmify.Application.App.Entities
{
	public class DeliveryAppService : MarmifyAppServiceBase<Delivery>, IDeliveryAppService
	{
		private readonly IDeliveryService _deliverySerive;

		public DeliveryAppService(IDeliveryService deliveryService) : base(deliveryService)
		{
			_deliverySerive = deliveryService;
		}

		public IEnumerable<Delivery> GetAll(ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			if (IsAllowed(null, currentUser))
			{
				return _deliverySerive.GetAll();
			}

			return null;
		}

		public IEnumerable<Delivery> GetAllByEstablishmentId(long establishmentId, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			var listDeliveries = _deliverySerive.GetByInclude(x => x.EstablishmentId == establishmentId, null);
			if (listDeliveries != null && listDeliveries.Any())
			{
				if (IsAllowed(listDeliveries.FirstOrDefault().EstablishmentId, currentUser))
				{
					return listDeliveries;
				}
			}

			return null;
		}

		public Delivery GetById(long id, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);
			Delivery delivery = _deliverySerive.GetById(id);
			if (delivery != null && IsAllowed(delivery.EstablishmentId, currentUser))
			{
				return delivery;
			}

			return null;
		}

		private bool IsAllowed(long? establishmentId, CurrentUser user)
		{
			if (!string.IsNullOrEmpty(user.Role) && 
				((user.Role.Equals(ConstProfiles.Administrator) || user.Role.Equals(ConstProfiles.User))
				|| (user.Role.Equals(ConstProfiles.Establishment) && establishmentId == user.EstablishmentId)))
			{
				return true;
			}

			return false;
		}
	}
}
