using CarbonFilter.Models;
using CarbonFilterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarbonFilterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsDisplayController : ControllerBase
    {

        private readonly SurveyDbContext _context;

        public QuestionsDisplayController(SurveyDbContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public Task<ActionResult<IEnumerable<QuestionDisplay>>> GetQuestions()
        {
            if (_context.Questions == null)
            {
                return Task.FromResult<ActionResult<IEnumerable<QuestionDisplay>>>(NotFound());
            }

            List<QuestionDisplay> questionDisplayList = new List<QuestionDisplay>();

            foreach (var question in _context.Questions) 
            {
                var category = _context.Categories.Single(item => item.CategoryId == question.CategoryId);
                var dropDown = _context.DropDowns.Single(item => item.DropDownId == question.DropDownId);
                var pickListItems = _context.PickListItems.Where(item => item.QuestionId == question.QuestionId);
                var dropDownOptions = _context.DropDownOptions.Where(item => item.DropDownId == question.DropDownId);

                QuestionDisplay questionDisplay = new QuestionDisplay
                {
                    CategoryName = (category is null) ? string.Empty : category.CategoryName,
                    QuestionNum = question.QuestionNum,
                    QuestionName = question.QuestionName,
                    InfoNotes = question.InfoNotes,
                    kgCo2eEmissions = question.kgCo2eEmissions,
                    PickListItems = (pickListItems.Count() > 0)
                    ? pickListItems.ToDictionary(x => x.PickListItemId, x => x.PickListItemName ?? string.Empty) : null,
                    DropDownOptions = (dropDownOptions.Count() > 0)
                    ? dropDownOptions.ToDictionary(x => x.DropDownOptionId, x => x.Range) : null
                };

                questionDisplayList.Add(questionDisplay);
            }

            return Task.FromResult<ActionResult<IEnumerable<QuestionDisplay>>>(questionDisplayList);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDisplay>> GetQuestion(int id)
        {

            if (_context.Questions == null)
            {
                return NotFound();
            }
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(question.CategoryId);
            var dropDown = _context.DropDowns.Find(question.DropDownId);
            //FormattableString getPickListItems = $"SELECT * FROM PickListItems WHERE QuestionId={question.QuestionId}";
            //FormattableString getDropDownOptions = $"SELECT * FROM DropDownOptions WHERE DropDownId={question.DropDownId}";
            //var pickListItems = _context.PickListItems.FromSql(getPickListItems).ToList();
            //var dropDownOptions = _context.DropDownOptions.FromSql(getDropDownOptions).ToList();
            var pickListItems = _context.PickListItems.Where(item => item.QuestionId == question.QuestionId);
            var dropDownOptions = _context.DropDownOptions.Where(item => item.DropDownId == question.DropDownId);

            QuestionDisplay questionDisplay = new QuestionDisplay
            {
                CategoryName = (category is null) ? null : category.CategoryName,
                QuestionNum = question.QuestionNum,
                QuestionName = question.QuestionName,
                InfoNotes = question.InfoNotes,
                kgCo2eEmissions = question.kgCo2eEmissions,
                PickListItems = (pickListItems.Count() > 0)
                ? pickListItems.ToDictionary(x => x.PickListItemId, x => x.PickListItemName ?? string.Empty) : null,
                DropDownOptions = (dropDownOptions.Count() > 0)
                ? dropDownOptions.ToDictionary(x => x.DropDownOptionId, x => x.Range) : null
            };

            return questionDisplay;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
