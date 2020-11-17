using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Infraestructure.Data.Context.Repositories.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marmify.Infraestructure.Data.Context.Repositories.Entiies
{
    public class UserRepository : MarmifyRepositoryBase<User>, IUserRepository
    {
    }
}
