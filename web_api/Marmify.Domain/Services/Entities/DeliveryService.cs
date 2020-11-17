using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;

namespace Marmify.Domain.Services.Entities
{
	public class DeliveryService : MarmifyServiceBase<Delivery>, IDeliveryService
	{
		private readonly IDeliveryRepository _deliveryRepository;

		public DeliveryService(IDeliveryRepository deliveryRepository) : base(deliveryRepository)
		{
			_deliveryRepository = deliveryRepository;
		}
	}
}
