using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace seguimiento_expotec.Models
{
    public class ContactModel
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("dni")]
        public string? Dni { get; set; }

        [BsonElement("position")]
        public string? Position { get; set; }

        [BsonElement("area")]
        public string? Area { get; set; }

        [BsonElement("emails")]
        public List<string>? Emails { get; set; }

        [BsonElement("phones")]
        public List<string>? Phones { get; set; }

        [BsonElement("invitationSentDate")]
        public DateTime? InvitationSentDate { get; set; }
    }

}
