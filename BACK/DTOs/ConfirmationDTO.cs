using seguimiento_expotec.Models;

namespace seguimiento_expotec.DTOs
{
    public class ConfirmationDTO
    {
        public string? Id { get; set; }
        public BusinessExecutiveDTO? ConfirmedBy { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public ConfirmationStatus Status { get; set; }
        public DateTime ValidityDate { get; set; }
    }
}
