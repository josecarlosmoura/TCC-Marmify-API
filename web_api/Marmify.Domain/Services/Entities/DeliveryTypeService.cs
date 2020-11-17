using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;

namespace Marmify.Domain.Services.Entities
{
	public class DeliveryTypeService : MarmifyServiceBase<DeliveryType>, IDeliveryTypeService
	{
		private readonly IDeliveryTypeRepository _deliveryTypeRepository;
		public DeliveryTypeService(IDeliveryTypeRepository deliveryTypeRepository) : base(deliveryTypeRepository)
		{
			_deliveryTypeRepository = deliveryTypeRepository;
		}
	}
}
