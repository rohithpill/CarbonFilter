using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarbonFilter.Models
{
    public class Response
    {

        [Key]
        public int ResponseId { get; set; }

        [Required]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question? Question { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(2000)")]
        public string? InfoNotes { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(2000)")]
        public string? kgCo2eEmissions { get; set; }

        [AllowNull]
        [Column(TypeName = "int")]
        [ForeignKey("PickListItem")]
        public int? PickListItemId { get; set; }
        public PickListItem? PickListItem { get; set; }

        [AllowNull]
        [Column(TypeName = "int")]
        [ForeignKey("DropDownOption")]
        public int? DropDownOptionId { get; set; }
        public DropDownOption? DropDownOption { get; set; }

        [AllowNull]
        [Column(TypeName = "int")]
        public int? ImageId { get; set; }

    }
}
