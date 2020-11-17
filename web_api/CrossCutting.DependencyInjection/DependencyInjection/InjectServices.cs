using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.Interfaces.Commons;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;
using Marmify.Domain.Services.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection.DependencyInjection
{
	public class InjectServices
	{
		public InjectServices(IServiceCollection services)
		{
			services.AddScoped(typeof(IMarmifyServiceBase<>), typeof(MarmifyServiceBase<>));
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IEstablishmentService, EstablishmentService>();
			services.AddScoped<IAddressService, AddressService>();
			services.AddScoped<IItemService, ItemService>();
			services.AddScoped<IPaymentConditionService, PaymentConditionService>();
			services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
			services.AddScoped<IDeliveryService, DeliveryService>();
			services.AddScoped<IDeliveryTypeService, DeliveryTypeService>();
			services.AddScoped<IUserFavoritesService, UserFavoritesService>();

			services.AddScoped<ICepService, CepService>();
		}
	}
}
