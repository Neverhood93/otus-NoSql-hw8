using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;

namespace Otus.Teaching.Pcf.GivingToCustomer.DataAccess
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("MongoDbSettings:ConnectionString").Value);
            _database = client.GetDatabase(configuration.GetSection("MongoDbSettings:DatabaseName").Value);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

        //public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");
        //public IMongoCollection<Preference> Preferences => _database.GetCollection<Preference>("Preferences");
        //public IMongoCollection<PromoCode> PromoCodes => _database.GetCollection<PromoCode>("PromoCodes");
    }
}
