using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marmify.Application.Interfaces.Entities
{
	public interface IDeliveryTypeAppService : IMarmifyAppServiceBase<DeliveryType>
	{
		IEnumerable<DeliveryType> GetAll(ClaimsPrincipal user);

		DeliveryType GetById(long id, ClaimsPrincipal user);

		IEnumerable<DeliveryType> GetAllByEstablishmentId(long establishmentId, ClaimsPrincipal user);
	}
}
