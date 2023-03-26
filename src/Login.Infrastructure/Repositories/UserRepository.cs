using Login.Domain;
using MongoDB.Driver;

namespace Login.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        IMongoCollection<User> _user;

        public UserRepository(MongoConnection mongoDB)
        {
            _user = mongoDB.DB.GetCollection<User>("user");
        }
        public async Task Create(User user, CancellationToken cancellationToken)
        {
            await _user.InsertOneAsync(user, cancellationToken: cancellationToken);

        }

        public Task<User> Edit(User user, string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(string email, CancellationToken cancellationToken)
        {
            return await _user.FindAsync(u => u.Email == email).Result.FirstAsync();
        }
    }
}
