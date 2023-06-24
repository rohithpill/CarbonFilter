using AspReactProject1.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarbonFilter.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string? CategoryName { get; set; }

        public ICollection<Question>? Questions { get; set; }
    }
}
