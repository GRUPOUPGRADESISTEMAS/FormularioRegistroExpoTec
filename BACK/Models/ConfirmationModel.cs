using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace seguimiento_expotec.Models
{
    public class ConfirmationModel
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("confirmedBy")]
        public BusinessExecutivesModel? ConfirmedBy { get; set; }

        [BsonElement("confirmationDate")]
        public DateTime ConfirmationDate { get; set; }

        [BsonElement("status")]
        public ConfirmationStatus Status { get; set; }

        [BsonElement("validityDate")]
        public DateTime ValidityDate { get; set; }
    }

    public enum ConfirmationStatus
    {
        AsistiraAlEvento,
        Ocupado,
        NoContesta,
        NoAsistira
    }
}
