using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;

namespace Marmify.Domain.Services.Entities
{
	public class PurchaseOrderService : MarmifyServiceBase<PurchaseOrder>, IPurchaseOrderService
	{
		private readonly IPurchaseOrderRepository _purchaseOrderRepository;

		public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
				: base(purchaseOrderRepository)
		{
			_purchaseOrderRepository = purchaseOrderRepository;
		}
	}
}
