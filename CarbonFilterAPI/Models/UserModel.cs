using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CarbonFilter.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string? UserName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string? UserPassword { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(200)")]
        public string? UserEmail { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(10)")]
        public string? UserMobileNumber { get; set; }

        [AllowNull]
        [Column(TypeName = "decimal(10,4)")]
        public decimal? UserFootPrint { get; set; }

        [AllowNull]
        [Column(TypeName = "bit")]
        public bool? isMobileVerified { get; set; }

        [AllowNull]
        [Column(TypeName = "bit")]
        public bool? isEmailVerified { get; set; }
    }
}
