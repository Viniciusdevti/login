using Login.Api.Dtos.Inputs;
using Login.Api.Dtos.Outputs;
using Login.Domain;

namespace Login.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<bool> GetUserByEmail(string email, CancellationToken cancellationToken);
        Task<string> GetUserByEmailAndPassword(string email, string password, CancellationToken cancellationToken);
        Task Create(User user, CancellationToken cancellationToken);
        Task<User> Edit(User user, string email, CancellationToken cancellationToken);
    }
}
