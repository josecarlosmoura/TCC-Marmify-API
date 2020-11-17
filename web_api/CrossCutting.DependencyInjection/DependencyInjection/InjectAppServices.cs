using Marmify.Application.App.Commons;
using Marmify.Application.App.Entities;
using Marmify.Application.Interfaces.Commons;
using Marmify.Application.Interfaces.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection.DependencyInjection
{
	public class InjectAppServices
	{
		public InjectAppServices(IServiceCollection services)
		{
			services.AddScoped(typeof(IMarmifyAppServiceBase<>), typeof(MarmifyAppServiceBase<>));
			services.AddScoped<IUserAppService, UserAppService>();
			services.AddScoped<IEstablishmentAppService, EstablishmentAppService>();
			services.AddScoped<IAddressAppService, AddressAppService>();
			services.AddScoped<IItemAppService, ItemAppService>();
			services.AddScoped<IPaymentConditionAppSerivce, PaymentConditionAppService>();
			services.AddScoped<IPurchaseOrderAppService, PurchaseOrderAppService>();
			services.AddScoped<IDeliveryAppService, DeliveryAppService>();
			services.AddScoped<IDeliveryTypeAppService, DeliveryTypeAppService>();
			services.AddScoped<IUserFavoritesAppService, UserFavoritesAppService>();
		}
	}
}
