using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Login.Infrastructure
{
    public class MongoConnection 
    {
        public IMongoDatabase DB { get; }
        public MongoConnection(IConfiguration configuration)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017/");
                DB = client.GetDatabase("User");
            }
            catch (Exception ex)
            {
                throw new MongoException("Não foi possivel se conectar ao Mongo.", ex);
            }
        }

    }
}
