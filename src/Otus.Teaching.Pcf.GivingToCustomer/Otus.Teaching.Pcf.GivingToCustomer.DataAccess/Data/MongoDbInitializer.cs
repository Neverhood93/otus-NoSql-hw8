using System.Threading.Tasks;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Otus.Teaching.Pcf.GivingToCustomer.DataAccess.Data
{
    public class MongoDbInitializer : IDbInitializer
    {
        private readonly IMongoDatabase _database;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Preference> _preferenceRepository;

        public MongoDbInitializer(IMongoDatabase database, IRepository<Customer> customerRepository, IRepository<Preference> preferenceRepository)
        {
            _database = database;
            _customerRepository = customerRepository;
            _preferenceRepository = preferenceRepository;
        }

        public void InitializeDb()
        {
            _database.DropCollectionAsync("Customers");
            _database.DropCollectionAsync("Preferences");

            _database.CreateCollectionAsync("Customers");
            _database.CreateCollectionAsync("Preferences");

            _preferenceRepository.AddRangeAsync(FakeDataFactory.Preferences);
            _customerRepository.AddRangeAsync(FakeDataFactory.Customers);
        }
    }
}
