using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marmify.Application.Interfaces.Entities
{
	public interface IUserFavoritesAppService : IMarmifyAppServiceBase<UserFavorites>
	{
		IEnumerable<UserFavorites> GetAll(ClaimsPrincipal user);

		UserFavorites CreateEntity(long establishmentId, ClaimsPrincipal user);

		UserFavorites GetByEstablishment(long establishmentId, ClaimsPrincipal user);
	}
}
