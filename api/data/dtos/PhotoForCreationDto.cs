using System;
using Microsoft.AspNetCore.Http;

namespace FBB.data.dtos;

    public class PhotoForCreationDto
    {
       public string Url { get; set; }  = string.Empty;
       public IFormFile? File { get; set; } = null;
       public string Description { get; set; } = string.Empty;
       public DateTime DateAdded { get; set; }
       public string PublicId { get; set; } = string.Empty;

       public PhotoForCreationDto()
       {
           DateAdded = DateTime.UtcNow;
       }
    }
