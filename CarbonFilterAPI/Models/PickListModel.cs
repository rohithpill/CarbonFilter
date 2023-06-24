using AspReactProject1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CarbonFilter.Models
{
    public class PickListItem
    {

        [Key]
        public int PickListItemId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")] 
        public string? PickListItemName { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(2000)")]
        public string? PickListItemDescription { get; set; }

        [Required]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question? Question { get; set; }

    }
}
