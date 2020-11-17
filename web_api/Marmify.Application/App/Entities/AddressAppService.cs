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
	public class AddressAppService : MarmifyAppServiceBase<Address>, IAddressAppService
	{
		private readonly IAddressService _addressService;

		public AddressAppService(IAddressService addressService) : base(addressService)
		{
			_addressService = addressService;
		}

		public IEnumerable<Address> GetAll(ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);
			if ((!string.IsNullOrEmpty(currentUser.Role) && currentUser.Role.Equals(ConstProfiles.Administrator)))
			{
				return _addressService.GetAll();
			}
			else
			{
				IEnumerable<Address> listAddress = _addressService.GetByInclude(x => x.UserId == currentUser.Id, null);
				if (listAddress.Any() && IsAllowed(listAddress.FirstOrDefault().UserId, currentUser))
					return listAddress;
			}

			return null;
		}

		public Address GetById(long id, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);
			Address address = _addressService.GetById(id);

			if (address != null && IsAllowed(address.UserId, currentUser))
			{
				return address;
			}

			return null;
		}

		private bool IsAllowed(long? userId, CurrentUser user)
		{
			if (user.Id == userId)
				return true;

			return false;
		}
	}
}
