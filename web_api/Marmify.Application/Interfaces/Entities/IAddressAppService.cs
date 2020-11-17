using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marmify.Application.Interfaces.Entities
{
	public interface IAddressAppService : IMarmifyAppServiceBase<Address>
	{
		IEnumerable<Address> GetAll(ClaimsPrincipal user);
		Address GetById(long id, ClaimsPrincipal user);
	}
}
