using Login.Domain;
using MongoDB.Driver;

namespace Login.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        IMongoCollection<User> _user;

        public UserRepository(MongoConnection mongoDB)
        {
            _user = mongoDB.DB.GetCollection<User>("User");
        }
        public async Task Create(User user, CancellationToken cancellationToken)
        {
            await _user.InsertOneAsync(user, cancellationToken: cancellationToken);

        }

        public Task<User> Edit(User user, string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            return await _user.FindAsync(u => u.Email.ToLower() == email.ToLower()) is not null;

        }

        public async Task<string> GetUserByEmailAndPassword(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _user.FindAsync(u => u.Email.ToLower() == email.ToLower()
                                        && u.Password.ToLower() == password.ToLower());

            return user.ToList().Select(u => u.Name).First();
                                       
        }
    }
}
