using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace seguimiento_expotec.Models
{
    public class CompanyModel
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("letterId")]
        public string? LetterId { get; set; }

        [BsonElement("addedBy")]
        public string? AddedBy { get; set; }

        [BsonElement("companyName")]
        public string? CompanyName { get; set; }

        [BsonElement("ruc")]
        public string? Ruc { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [BsonElement("district")]
        public string? District { get; set; }

        [BsonElement("contacts")]
        public List<ContactModel>? Contacts { get; set; }

        [BsonElement("confirmations")]
        public List<ConfirmationModel>? Confirmations { get; set; }

        [BsonElement("executiveResponsible")]
        public BusinessExecutivesModel? ExecutiveResponsible { get; set; }

        [BsonElement("invitationStatus")]
        public string? InvitationStatus { get; set; }

        [BsonElement("candidateForCocktail")]   
        public bool CandidateForCocktail { get; set; }

        [BsonElement("attendedEvent")]
        public bool AttendedEvent { get; set; }

        [BsonElement("comments")]
        public string? Comments { get; set; }
    }
}
