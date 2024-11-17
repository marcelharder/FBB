namespace FBB.data.dtos;
    public class UserForUpdateDto
    {
        public required string UserName { get; set; }
        public string? KnownAs { get; set; } = string.Empty;
        public required string PhotoUrl { get; set; }
        public required string Email { get; set; }
        public string? Mobile { get; set; }
        public int Id { get; set; }
        public DateTime PaidTill { get; set; } 
    }