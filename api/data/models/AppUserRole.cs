using Microsoft.AspNetCore.Identity;

namespace FBB.data.models;

    public class AppUserRole: IdentityUserRole<int>
    {
        public AppUser? User { get; set; }
        public AppRole? Role { get; set; }
    }
