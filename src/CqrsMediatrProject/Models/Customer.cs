using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CqrsMediatrProject.Models
{
    public class Customer
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("CPF")]
        public string Cpf { get; set; } = string.Empty;

        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("Adress")]
        public string Adress { get; set; } = string.Empty;

        [BsonElement("Phone")]
        public string Phone { get; set; } = string.Empty;

        [BsonElement("Status")]
        public bool Active { get; set; } = true;


    }

}
