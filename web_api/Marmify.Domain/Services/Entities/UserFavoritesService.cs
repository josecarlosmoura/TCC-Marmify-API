using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;

namespace Marmify.Domain.Services.Entities
{
	public class UserFavoritesService : MarmifyServiceBase<UserFavorites>, IUserFavoritesService
	{
		private readonly IUserFavoritesRepository _userFavoritesRepository;

		public UserFavoritesService(IUserFavoritesRepository userFavoritesRepository) : base(userFavoritesRepository)
		{
			_userFavoritesRepository = userFavoritesRepository;
		}
	}
}
