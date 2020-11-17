using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.Entities;
using System.Security.Claims;

namespace Marmify.Application.Interfaces.Entities
{
	public interface IEstablishmentAppService : IMarmifyAppServiceBase<Establishment>
	{
		Establishment GetById(long id, ClaimsPrincipal User);
	}
}
