using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Domain.Commons;
using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marmify.Application.App.Entities
{
	public class ItemAppService : MarmifyAppServiceBase<Item>, IItemAppService
	{
		private readonly IItemService _itemService;

		public ItemAppService(IItemService itemService) : base(itemService)
		{
			_itemService = itemService;
		}

		public IEnumerable<Item> GetAll(ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			if (IsAllowed(null, currentUser))
			{
				return _itemService.GetAll();
			}

			return null;
		}

		public Item GetById(long id, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);
			Item item = _itemService.GetById(id);

			if (item != null && IsAllowed(item.EstablishmentId, currentUser))
			{
				return item;
			}

			return null;
		}

		public IEnumerable<Item> GetAllByEstablishmentId(long establishmentId, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			if (IsAllowed(establishmentId, currentUser))
			{
				return _itemService.GetByInclude(x => x.EstablishmentId == establishmentId, null);
			}

			return null;
		}

		private bool IsAllowed(long? establishmentId, CurrentUser user)
		{
			if ((!string.IsNullOrEmpty(user.Role) && (user.Role.Equals(ConstProfiles.Administrator) 
				|| user.Role.Equals(ConstProfiles.User)))
				|| (!string.IsNullOrEmpty(user.Role) 
					&& user.Role.Equals(ConstProfiles.Establishment) 
					&& user.EstablishmentId == establishmentId))
				return true;

			return false;
		}
	}
}
