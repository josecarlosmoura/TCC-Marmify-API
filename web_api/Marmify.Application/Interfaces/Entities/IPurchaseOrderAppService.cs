using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marmify.Application.Interfaces.Entities
{
	public interface IPurchaseOrderAppService : IMarmifyAppServiceBase<PurchaseOrder>
	{
		PurchaseOrder CreatePurchaseOrder(PurchaseOrder purchaseOrder);

		IEnumerable<PurchaseOrder> GetAll(ClaimsPrincipal user);

		PurchaseOrder GetById(long id, ClaimsPrincipal user);

		PurchaseOrder UpdateEntity(PurchaseOrderDTO purchaseOrderDTO, ClaimsPrincipal user);
	}
}
