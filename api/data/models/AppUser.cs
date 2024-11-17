using Microsoft.AspNetCore.Identity;

namespace FBB.data.models;
public class AppUser: IdentityUser<int>

    {
        public byte[]? PasswordSalt { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string? PhotoUrl { get; set; }
        public string? KnownAs {get; set;}
        public string? Country {get; set;}
        public string Mobile {get; set;} = string.Empty;
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime PaidTill { get; set; }
        public Boolean Active {get; set;}
        public ICollection<AppUserRole>? UserRoles { get; set; }

       
    }
