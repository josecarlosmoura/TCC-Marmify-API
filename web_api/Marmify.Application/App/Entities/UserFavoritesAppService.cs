using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Marmify.Application.App.Entities
{
	public class UserFavoritesAppService : MarmifyAppServiceBase<UserFavorites>, IUserFavoritesAppService
	{
		private readonly IUserFavoritesService _userFavoritesService;
		private readonly IEstablishmentAppService _establishmentAppService;
		private readonly IUserAppService _userAppService;
		public UserFavoritesAppService(IUserFavoritesService userFavoritesService, 
			IEstablishmentAppService establishmentAppService,
			IUserAppService userAppService)
			: base(userFavoritesService)
		{
			_userFavoritesService = userFavoritesService;
			_establishmentAppService = establishmentAppService;
			_userAppService = userAppService;
		}

		public IEnumerable<UserFavorites> GetAll(ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			return _userFavoritesService.GetByInclude(x => x.UserId == currentUser.Id, null);
		}

		public UserFavorites CreateEntity(long establishmentId, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);

			Establishment establishment = _establishmentAppService.GetById(establishmentId);
			User foundUser = _userAppService.GetById(currentUser.Id);

			if (establishment != null && foundUser != null)
			{
				UserFavorites userFavorites = _userFavoritesService.CreateEntity(new UserFavorites()
				{
					UserId = foundUser.Id,
					EstablishmentId = establishment.Id,
				});

				return userFavorites;
			}

			return null;			
		}

		public UserFavorites GetByEstablishment(long establishmentId, ClaimsPrincipal user)
		{
			CurrentUser currentUser = new CurrentUser(user);
			UserFavorites userFavorites = _userFavoritesService.GetByInclude(x => x.EstablishmentId == establishmentId
			&& x.UserId == currentUser.Id, null).FirstOrDefault();

			if (userFavorites != null)
			{
				return userFavorites;
			}

			return null;
		}
	}
}
