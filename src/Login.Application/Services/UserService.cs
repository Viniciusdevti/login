using Login.Api.Dtos.Inputs;
using Login.Api.Dtos.Outputs;
using Cryptography = Login.Application.Helpers.Cryptography;
using Login.Application.Services;
using Login.Domain;
using Login.Infrastructure.Repositories;

namespace Login.Application
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private const string incluirChave = "asfasfa";

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserInput userInput, CancellationToken cancellation)
        {
            var password = CryptographyPassWord(userInput.Password);
            var user = new User(userInput.Email, userInput.Name, password);
            await _userRepository.Create(user, cancellation);
        }

        public Task ResetPassword(User userInput, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task VerifyIfUserExisting(string email, CancellationToken cancellation)
        {
            var userExist = await _userRepository.GetUserByEmail(email, cancellation);

            if (!userExist)
                throw new Exception("Email já utilizado por outro usuário.");
        }

        public async Task<LoginOutput> VerifyIfUserIsValid(string email, string password, CancellationToken cancellation)
        {
            var passwordEncrypt = CryptographyPassWord(password);
            var userName = await _userRepository.GetUserByEmailAndPassword(email, passwordEncrypt, cancellation);
           
            if (string.IsNullOrEmpty(userName))
                throw new Exception("Usuário ou senha invalidos.");

            return new LoginOutput
            {
                Name = userName,
                Token = TokenService.TokenGenerator(userName, incluirChave)
            };
        }

        private string CryptographyPassWord(string password)
        {
            return Cryptography.Encrypt(password);
        }

    }
}