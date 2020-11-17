using Marmify.Domain.Interfaces.Commons;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Infraestructure.Data.Context.Repositories.Entiies;
using Marmify.Infraestructure.Data.Context.Repositories.RepositoryBase;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection.DependencyInjection
{
	public class InjectRepositories
	{
		public InjectRepositories(IServiceCollection services)
		{
			services.AddScoped(typeof(IMarmifyRepositoryBase<>), typeof(MarmifyRepositoryBase<>));
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
			services.AddScoped<IAddressRepository, AddressRepository>();
			services.AddScoped<IItemRepository, ItemRepository>();
			services.AddScoped<IPaymentConditionRepository, PaymentConditionRepository>();
			services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
			services.AddScoped<IDeliveryRepository, DeliveryRepository>();
			services.AddScoped<IDeliveryTypeRepository, DeliveryTypeRepository>();
			services.AddScoped<IUserFavoritesRepository, UserFavoritesRepository>();
		}
	}
}
