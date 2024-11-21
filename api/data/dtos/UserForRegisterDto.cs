using System.ComponentModel.DataAnnotations;

namespace fbb.data.dtos;

public class UserForRegisterDto
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        [StringLength(80, MinimumLength = 6, ErrorMessage="Password should be minimum 6 and max 80 char")]
        public required string Password { get; set; }
        public required string Country {get; set;}
        public string? City {get; set;}
        public required string Email {get; set;}
        public required string Mobile {get; set;}
        public required string Gender {get; set;}
        public string? KnownAs {get; set;}
        public DateTime Created { get; set; }
        public Boolean Active { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime PaidTill { get; set; }
        
       
       

    }