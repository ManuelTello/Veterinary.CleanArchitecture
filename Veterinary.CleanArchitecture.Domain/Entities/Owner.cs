using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.CleanArchitecture.Domain.Entities
{
    [Table("owners")]
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 0)]
        public Guid Id { get; set; }

        [Column("full_name", Order = 1)]
        public string FirstName { get; set; } = string.Empty;
        
        [Column("phone_number", Order = 2)]
        public string? PhoneNumber { get; set; }
        
        [Column("extra_information", Order = 3)]
        public string? ExtraInformation { get; set; }
        
        [Column("date_added_to_system", Order = 4)]
        public DateTime DateAddedToSystem { get; set; }
        
        [Column("identification", Order = 5)]
        public string Identification { get; set; } = string.Empty;
    }
}

