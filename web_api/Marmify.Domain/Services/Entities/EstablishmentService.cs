using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;

namespace Marmify.Domain.Services.Entities
{
	public class EstablishmentService : MarmifyServiceBase<Establishment>, IEstablishmentService
	{
		private readonly IEstablishmentRepository _establishmentRepository;

		public EstablishmentService(IEstablishmentRepository establishmentRepository) : base(establishmentRepository)
		{
			_establishmentRepository = establishmentRepository;
		}
	}
}
