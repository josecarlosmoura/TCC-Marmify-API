using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;

namespace Marmify.Domain.Services.Entities
{
	public class AddressService : MarmifyServiceBase<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService (IAddressRepository addressRepository) : base (addressRepository)
        {
            _addressRepository = addressRepository;
        }
    }
}
