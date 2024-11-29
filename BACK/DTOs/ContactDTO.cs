namespace seguimiento_expotec.DTOs
{
    public class ContactDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Dni { get; set; }
        public string? Position { get; set; }
        public string? Area { get; set; }
        public List<string>? Emails { get; set; }
        public List<string>? Phones { get; set; }
        public DateTime? InvitationSentDate { get; set; }
    }
}
