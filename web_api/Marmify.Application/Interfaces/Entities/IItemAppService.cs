using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marmify.Application.Interfaces.Entities
{
	public interface IItemAppService : IMarmifyAppServiceBase<Item>
	{
		IEnumerable<Item> GetAll(ClaimsPrincipal user);

		Item GetById(long id, ClaimsPrincipal user);

		IEnumerable<Item> GetAllByEstablishmentId(long establishmentId, ClaimsPrincipal user);
	}
}
