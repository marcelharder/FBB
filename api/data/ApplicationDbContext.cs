using FBB.data.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FBB.data;

    public class ApplicationDbContext : IdentityDbContext<
    AppUser, 
    AppRole, 
    int, 
    IdentityUserClaim<int>,
    AppUserRole,
    IdentityUserLogin<int>,
    IdentityRoleClaim<int>, 
    IdentityUserToken<int>
    >
    
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       
        
        public DbSet<CaseReport> CaseReports { get; set; }
        



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

