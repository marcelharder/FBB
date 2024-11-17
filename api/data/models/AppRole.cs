using Microsoft.AspNetCore.Identity;

namespace FBB.data.models;

    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole>? UserRoles { get; set; }
    }
