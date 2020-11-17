using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;

namespace Marmify.Domain.Services.Entities
{
	public class ItemService : MarmifyServiceBase<Item>, IItemService
	{
		private readonly IItemRepository _itemRepository;

		public ItemService(IItemRepository itemRepository) : base(itemRepository)
		{
			_itemRepository = itemRepository;
		}
	}
}
