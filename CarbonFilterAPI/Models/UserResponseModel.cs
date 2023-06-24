using AspReactProject1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarbonFilter.Models
{
    public class UserResponse
    {
        [Key]
        public int UserResponseId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        [ForeignKey("Response")]
        public int ResponseId { get; set; }
        public Response? Response { get; set; }

    }
}
