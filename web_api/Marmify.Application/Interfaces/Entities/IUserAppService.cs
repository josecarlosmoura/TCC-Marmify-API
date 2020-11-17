using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.DTO;
using Marmify.Domain.Entities;

namespace Marmify.Application.Interfaces.Entities
{
    public interface IUserAppService : IMarmifyAppServiceBase<User>
    {
        User UpdateEntity(User user, UserUpdateDTO userDTO);
    }
}
