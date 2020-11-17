using System.Collections.Generic;

namespace Marmify.Application.Utils.Enuns
{
	public enum EDeliveryStatus
	{
		AwaitingPreparation = 1,
		OutForDelivery = 2,
		DeliveryClosed = 3,
	}

	public static class DeliveryStatus
	{
		public static IEnumerable<EDeliveryStatus> Status
		{
			get
			{
				List<EDeliveryStatus> list = new List<EDeliveryStatus>
				{
					EDeliveryStatus.AwaitingPreparation,
					EDeliveryStatus.OutForDelivery,
					EDeliveryStatus.DeliveryClosed
				};

				return list;
			}
		}
	}
}
