using CarbonFilter.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace CarbonFilterAPI.Models
{
    public class QuestionDisplay
    {
        public string? CategoryName { get; set; }
        public int? QuestionNum { get; set; }
        public string? QuestionName { get; set; }
        public IDictionary<int, string>? PickListItems { get; set; }
        public IDictionary<int, string>? DropDownOptions { get; set; }
        public string? InfoNotes { get; set; }
        public string? kgCo2eEmissions { get; set; }
    }
}
