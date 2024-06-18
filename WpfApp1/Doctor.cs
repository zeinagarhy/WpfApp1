using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YourNamespace.Models
{
    public class Doctor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
        public string PhoneNumber { get; set; }
    }
}
