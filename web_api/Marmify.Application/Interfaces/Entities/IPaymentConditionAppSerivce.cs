using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marmify.Application.Interfaces.Entities
{
	public interface IPaymentConditionAppSerivce : IMarmifyAppServiceBase<PaymentCondition>
	{
		PaymentCondition GetById(long id, ClaimsPrincipal user);

		IEnumerable<PaymentCondition> GetAll(ClaimsPrincipal user);

		IEnumerable<PaymentCondition> GetAllByEstablishmentId(long establishmentId, ClaimsPrincipal user);
	}
}
