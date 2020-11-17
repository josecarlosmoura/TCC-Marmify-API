using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Entities;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Services;

namespace Marmify.Application.App.Entities
{
    public class UserAppService : MarmifyAppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public User UpdateEntity(User user, UserUpdateDTO userDTO)
        {
            user.PhoneNumber = userDTO.PhoneNumber;
            user.CellPhone = userDTO.CellPhone;
            user.FullName = userDTO.FullName;
            user.Email = userDTO.Email;
            user.EstablishmentId = userDTO.EstablishmentId;

            return user;
        }
    }
}
