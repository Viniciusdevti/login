using Login.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string email, CancellationToken cancellationToken);
        Task Create(User user, CancellationToken cancellationToken);
        Task<User> Edit(User user, string email, CancellationToken cancellationToken);
    }
}
