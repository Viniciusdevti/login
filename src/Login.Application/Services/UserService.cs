using Login.Application.Services;
using Login.Domain;
using Login.Infrastructure.Repositories;

namespace Login.Application
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user, CancellationToken cancellation)
        {
            await _userRepository.Create(user, cancellation);
        }

        public Task ResetPassword(User user, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<User> VerifyUser(string email, CancellationToken cancellation)
        {
           return  await _userRepository.Get(email, cancellation);
        }
    }
}