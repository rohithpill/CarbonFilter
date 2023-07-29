using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarbonFilter.Models
{
    public class UserResponse
    {
        [Key]
        public int UserResponseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ResponseId { get; set; }

    }
}
