using Login.Domain;

namespace Login.Application.Services
{
    public interface IUserService
    {
        Task<User> VerifyUser(string email, CancellationToken cancellation);
        Task CreateUser(User user, CancellationToken cancellation);
        Task ResetPassword(User user,  CancellationToken cancellation);
    }
}
