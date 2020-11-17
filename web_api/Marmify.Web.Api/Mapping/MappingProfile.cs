using AutoMapper;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;

namespace Marmify.Web.Api.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserResponseDTO>();
			CreateMap<UserResponseDTO, User>();

			CreateMap<User, UserResquestDTO>();
			CreateMap<UserResquestDTO, User>();

			CreateMap<Address, AddressDTO>();
			CreateMap<AddressDTO, Address>();

			CreateMap<Establishment, EstablishmentDTO>();
			CreateMap<EstablishmentDTO, Establishment>();

			CreateMap<Item, ItemDTO>();
			CreateMap<ItemDTO, Item>();

			CreateMap<PaymentCondition, PaymentConditionDTO>();
			CreateMap<PaymentConditionDTO, PaymentCondition>();

			CreateMap<PurchaseOrder, PurchaseOrderDTO>();
			CreateMap<PurchaseOrderDTO, PurchaseOrder>();

			CreateMap<ItemPurchase, ItemPurchaseDTO>();
			CreateMap<ItemPurchaseDTO, ItemPurchase>();

			CreateMap<Delivery, DeliveryDTO>();
			CreateMap<DeliveryDTO, Delivery>();

			CreateMap<DeliveryType, DeliveryTypeDTO>();
			CreateMap<DeliveryTypeDTO, DeliveryType>();

			CreateMap<UserFavorites, UserFavoritesDTO>();
			CreateMap<UserFavoritesDTO, UserFavorites>();
		}
	}
}
