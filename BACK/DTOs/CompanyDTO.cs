namespace seguimiento_expotec.DTOs
{
    public class CompanyDTO
    {
        public string? Id { get; set; }
        public string? LetterId { get; set; }
        public string? AddedBy { get; set; }
        public string? CompanyName { get; set; }
        public string? Ruc { get; set; }
        public string? Address { get; set; }
        public string? District { get; set; }
        public List<ContactDTO>? Contacts { get; set; }
        public List<ConfirmationDTO>? Confirmations { get; set; }
        public BusinessExecutiveDTO? ExecutiveResponsible { get; set; }
        public string? InvitationStatus { get; set; }
        public bool CandidateForCocktail { get; set; }
        public bool AttendedEvent { get; set; }
        public string? Comments { get; set; }
    }

}
