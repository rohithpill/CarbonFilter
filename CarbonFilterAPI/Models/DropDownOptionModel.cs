﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CarbonFilter.Models
{
    public class DropDownOption
    {

        [Key]
        public int DropDownOptionId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,4)")]
        public decimal MinValue { get; set; }

        [AllowNull]
        [Column(TypeName = "decimal(10,4)")]
        public decimal? MaxValue { get; set; }

        public string Range => ((int)MinValue).ToString() 
            + ((MaxValue is null) ? string.Empty : " - " + ((int)MaxValue).ToString())
            + ((DropDown is null) ? string.Empty : ' ' + DropDown.DropDownUnit);

        [Required]
        [ForeignKey("DropDown")]
        public int? DropDownId { get; set; }
        public DropDown? DropDown { get; set; }
    }
}
