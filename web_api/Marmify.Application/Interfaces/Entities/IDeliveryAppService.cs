using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marmify.Application.Interfaces.Entities
{
	public interface IDeliveryAppService : IMarmifyAppServiceBase<Delivery>
	{
		IEnumerable<Delivery> GetAll(ClaimsPrincipal user);

		Delivery GetById(long id, ClaimsPrincipal user);

		IEnumerable<Delivery> GetAllByEstablishmentId(long establishmentId, ClaimsPrincipal user);
	}
}
