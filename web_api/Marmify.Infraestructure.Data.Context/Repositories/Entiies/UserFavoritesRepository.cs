using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Infraestructure.Data.Context.Repositories.RepositoryBase;

namespace Marmify.Infraestructure.Data.Context.Repositories.Entiies
{
	public class UserFavoritesRepository : MarmifyRepositoryBase<UserFavorites>, IUserFavoritesRepository
	{
	}
}
