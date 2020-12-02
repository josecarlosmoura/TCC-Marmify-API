using Marmify.Application.App.Commons;
using Marmify.Application.Interfaces.Entities;
using Marmify.Application.Utils;
using Marmify.Domain.Commons;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Services;
using System;

namespace Marmify.Application.App.Entities
{
    public class UserAppService : MarmifyAppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public User UpdateEntity(CurrentUser currentUser, User user, UserUpdateDTO userDTO)
        {
            if (IsAllowed(user, currentUser, userDTO))
            {
                user.PhoneNumber = userDTO.PhoneNumber;
                user.CellPhone = userDTO.CellPhone;
                user.FullName = userDTO.FullName;
                user.Email = userDTO.Email;
                user.EstablishmentId = userDTO.EstablishmentId;

                return user;
            }

            return null;
        }

        private bool IsAllowed(User user, CurrentUser currentUser, UserUpdateDTO userDTO)
        {
            if (!string.IsNullOrEmpty(currentUser.Role)
                && (currentUser.Role.Equals(ConstProfiles.Administrator) &&
                userDTO.Role.Equals(ConstProfiles.Establishment)
                || currentUser.Id == user.Id))
            {
                return true;
            }

            return false;
        }
    }
}
