using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace CarbonFilter.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public int QuestionNum { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(2000)")]
        public string? QuestionName { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(2000)")]
        public string? InfoNotes { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(2000)")] 
        public string? kgCo2eEmissions { get; set; }

        [AllowNull]
        [Column(TypeName = "int")]
        [ForeignKey("DropDown")]
        public int? DropDownId { get; set; }
        public DropDown? DropDown { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [AllowNull]
        [Column(TypeName = "int")]
        public int? ImageId { get; set; }

    }
}
