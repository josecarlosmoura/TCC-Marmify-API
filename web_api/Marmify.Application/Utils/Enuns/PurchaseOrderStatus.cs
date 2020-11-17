using System.Collections.Generic;

namespace Marmify.Application.Utils.Enuns
{
	public enum EPurchaseOrderStatus
	{
		RequestReceived = 1,
		InPreparation = 2,
		OutForDelivery = 3,
		OrderClosed = 4,
		OrderCanceled = 5
	}

	public static class PurchaseOrderStatus
	{
		public static IEnumerable<EPurchaseOrderStatus> Status 
		{ 
			get 
			{
				List<EPurchaseOrderStatus> list = new List<EPurchaseOrderStatus>
				{
					EPurchaseOrderStatus.RequestReceived,
					EPurchaseOrderStatus.InPreparation,
					EPurchaseOrderStatus.OutForDelivery,
					EPurchaseOrderStatus.OrderClosed,
					EPurchaseOrderStatus.OrderCanceled
				};

				return list;
			} 
		}
	}
}
