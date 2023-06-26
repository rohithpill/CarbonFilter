using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CarbonFilter.Models
{
    public class DropDown
    {

        [Key]
        public int DropDownId { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(200)")] 
        public string? DropDownName { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(200)")]
        public string? DropDownUnit { get; set; }

        public ICollection<DropDownOption>? DropDownOptions { get; set; }

    }
}
