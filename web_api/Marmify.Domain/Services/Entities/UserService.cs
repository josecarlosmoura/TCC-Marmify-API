using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;

namespace Marmify.Domain.Services.Entities
{
    public class UserService : MarmifyServiceBase<User>, IUserService 
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base (userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
