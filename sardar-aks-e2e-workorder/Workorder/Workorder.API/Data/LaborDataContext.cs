using MongoDB.Driver;
using Workorder.API.Models;

namespace Workorder.API.Data
{
    public class LaborDataContext
    {
        public IMongoCollection<Labor> Labor { get; set; }

        public LaborDataContext(IConfiguration config)
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            var db = client.GetDatabase(config["DatabaseSettings:DatabaseName"]);

            Labor = db.GetCollection<Labor>(config["DatabaseSettings:CollectionName"]);
            SeedData(Labor);
        }
        public static void SeedData(IMongoCollection<Labor> labCollection)
        {
            bool existingProduct = labCollection.Find(x => true).Any();

            if (!existingProduct)
            {
                labCollection.InsertManyAsync(DefaultHardcodedLabors());
            }
        }
        public static IEnumerable<Labor> DefaultHardcodedLabors()
        {
            return new List<Labor> {

            new Labor
            {
                Name = "Souvik Sardar",
                Category = "Developer",
                SalaryPerDay = 1100.7
            },
            new Labor
            {
                Name = "Suprava Sinha",
                Category = "Tester",
                SalaryPerDay = 1200.8
            },
            new Labor
            {
                Name = "Aloka Sardar",
                Category = "Data Engineer",
                SalaryPerDay = 1300.9
            }
          };
        }
    }
}
