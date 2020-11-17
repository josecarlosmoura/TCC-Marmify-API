using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Domain.Commons;
using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marmify.Application.App.Entities
{
	public class PaymentConditionAppService : MarmifyAppServiceBase<PaymentCondition>, IPaymentConditionAppSerivce
	{
		private readonly IPaymentConditionService _paymentConditionService;

		public PaymentConditionAppService(IPaymentConditionService paymentConditionService)
				: base(paymentConditionService)
		{
			_paymentConditionService = paymentConditionService;
		}

		public PaymentCondition GetById(long id, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);
			PaymentCondition paymentCondition = _paymentConditionService.GetById(id);

			if (IsAllowed(paymentCondition.EstablishmentId, currentUser))
			{
				return paymentCondition;
			}

			return null;
		}

		public IEnumerable<PaymentCondition> GetAll(ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			if (IsAllowed(null, currentUser))
			{
				return _paymentConditionService.GetAll();
			}

			return null;
		}

		public IEnumerable<PaymentCondition> GetAllByEstablishmentId(long establishmentId, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			if (IsAllowed(establishmentId, currentUser))
			{
				return _paymentConditionService.GetByInclude(x => x.EstablishmentId == establishmentId, null);
			}

			return null;
		}

		private bool IsAllowed(long? establishmentId, CurrentUser user)
		{
			if ((!string.IsNullOrEmpty(user.Role) && user.Role.Equals(ConstProfiles.Administrator))
				|| (!string.IsNullOrEmpty(user.Role)
					&& (user.Role.Equals(ConstProfiles.Establishment)
						|| user.Role.Equals(ConstProfiles.User))
					&& user.EstablishmentId == establishmentId))
				return true;

			return false;
		}
	}
}
