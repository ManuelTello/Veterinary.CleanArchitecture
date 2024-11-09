using System.ComponentModel.DataAnnotations;

namespace Veterinary.CleanArchitecture.MVC.Models.Owner
{
    public class CreateOwnerViewModel
    {
        [Required(ErrorMessage = "Field required")] 
        public string FullName { get; set; } = string.Empty;
        
        [MinLength(4, ErrorMessage = "Must be a valid phone number")]
        public string? PhoneNumber { get; set; }
 
        [MinLength(4, ErrorMessage = "Must be a valid phone number")]
        public string? AlternativePhoneNumber { get; set; }
        
        public int? ExtraInformation { get; set; }
        
        [Required(ErrorMessage = "Field required")]
        public int? Identification { get; set; } 
    }
}

