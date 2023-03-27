using Login.Api.Dtos.Inputs;
using Login.Api.Dtos.Outputs;
using Login.Domain;

namespace Login.Application.Services
{
    public interface IUserService
    {
        Task VerifyIfUserExisting(string email, CancellationToken cancellation);
        Task<LoginOutput> VerifyIfUserIsValid(string email, string password, CancellationToken cancellation);
        Task CreateUser(UserInput userInput, CancellationToken cancellation);
        Task ResetPassword(User userInput,  CancellationToken cancellation);
    }
}
