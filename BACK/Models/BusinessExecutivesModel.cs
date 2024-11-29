using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace seguimiento_expotec.Models
{
    public class BusinessExecutivesModel
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string? Id { get; set; } 

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("dni")]
        public string? Dni { get; set; }
    }
}
