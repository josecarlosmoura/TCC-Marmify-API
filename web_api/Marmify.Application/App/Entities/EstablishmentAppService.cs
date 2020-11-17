using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Domain.Commons;
using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Services;
using System.Security.Claims;

namespace Marmify.Application.App.Entities
{
	public class EstablishmentAppService : MarmifyAppServiceBase<Establishment>, IEstablishmentAppService
	{
		private readonly IEstablishmentService _establishmentService;

		public EstablishmentAppService(IEstablishmentService establishmentService) : base(establishmentService)
		{
			_establishmentService = establishmentService;
		}

		public Establishment GetById(long id, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			if (IsAllowed(id, currentUser))
			{
				return _establishmentService.GetById(id);
			}

			return null;
		}

		private bool IsAllowed(long id, CurrentUser user)
		{
			if ((!string.IsNullOrEmpty(user.Role) && (user.Role.Equals(ConstProfiles.Administrator) 
				|| user.Role.Equals(ConstProfiles.User))) || user.EstablishmentId == id)
				return true;

			return false;
		}
	}
}
