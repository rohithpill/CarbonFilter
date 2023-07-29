using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CarbonFilter.Models
{
    [PrimaryKey(nameof(ResponseId), nameof(QuestionId))]
    public class Response
    {

        //[Key, Column(Order = 0)]
        public int ResponseId { get; set; }

        //[Key, Column(Order = 1)]
        [Required]        
        public int QuestionId { get; set; }        

        [AllowNull]
        [Column(TypeName = "nvarchar(2000)")]
        public string? InfoNotes { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(2000)")]
        public string? kgCo2eEmissions { get; set; }

        [AllowNull]
        [Column(TypeName = "int")]
        public int? PickListItemId { get; set; }

        [AllowNull]
        [Column(TypeName = "int")]
        public int? DropDownOptionId { get; set; }

        [AllowNull]
        [Column(TypeName = "int")]
        public int? ImageId { get; set; }

    }
}
