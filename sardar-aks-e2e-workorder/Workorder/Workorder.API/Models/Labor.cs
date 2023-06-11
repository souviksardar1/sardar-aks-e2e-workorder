using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Workorder.API.Models
{
    public class Labor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double SalaryPerDay { get; set; }
    }
}
