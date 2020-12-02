using Marmify.Application.Interfaces.Commons;
using Marmify.Application.Utils;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;

namespace Marmify.Application.Interfaces.Entities
{
    public interface IUserAppService : IMarmifyAppServiceBase<User>
    {
        User UpdateEntity(CurrentUser currentUser, User user, UserUpdateDTO userDTO);
    }
}
