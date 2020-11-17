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
	public class DeliveryTypeAppService : MarmifyAppServiceBase<DeliveryType>, IDeliveryTypeAppService
	{
		private readonly IDeliveryTypeService _deliveryTypeService;
		public DeliveryTypeAppService(IDeliveryTypeService deliveryTypeService) : base(deliveryTypeService)
		{
			_deliveryTypeService = deliveryTypeService;
		}

		public IEnumerable<DeliveryType> GetAll(ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			if (!string.IsNullOrEmpty(currentUser.Role) && currentUser.Role.Equals(ConstProfiles.Administrator))
			{
				return _deliveryTypeService.GetAll();
			}
			else if (!string.IsNullOrEmpty(currentUser.Role) && currentUser.Role.Equals(ConstProfiles.Establishment))
			{
				return _deliveryTypeService.GetByInclude(x => x.EstablishmentId == currentUser.EstablishmentId, null);
			}

			return null;
		}

		public IEnumerable<DeliveryType> GetAllByEstablishmentId(long establishmentId, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			var listDeliverieTypes = _deliveryTypeService.GetByInclude(x => x.EstablishmentId == establishmentId, null);
			if (listDeliverieTypes != null && listDeliverieTypes.Any())
			{
				if (IsAllowed(listDeliverieTypes.FirstOrDefault().EstablishmentId, currentUser))
				{
					return listDeliverieTypes;
				}
			}

			return null;
		}

		public DeliveryType GetById(long id, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);
			DeliveryType deliveryType = _deliveryTypeService.GetById(id);
			if (deliveryType != null && IsAllowed(deliveryType.EstablishmentId, currentUser))
			{
				return deliveryType;
			}

			return null;
		}

		private bool IsAllowed(long? establishmentId, CurrentUser user)
		{
			if (string.IsNullOrEmpty(user.Role)
				&& (user.Role.Equals(ConstProfiles.Establishment) || user.Role.Equals(ConstProfiles.Establishment)
				&& establishmentId != user.EstablishmentId))
			{
				return false;
			}

			return true;
		}
	}
}
