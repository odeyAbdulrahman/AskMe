using AskMe.API.Domain.Entities;
using AskMe.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestion Question;

        public QuestionsController(IQuestion question)
        {
            Question = question;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(string id)
        {
           
            return Ok(await Question.GetAsync(id));
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await Question.GetAllAsync());
        }

        [HttpGet("{fromDate}/{toDate}")]
        public async Task<ActionResult> GetAsync(DateTime fromDate, DateTime toDate)
        {

            return Ok(await Question.GetAllAsync(fromDate, toDate));
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> PostAsync([FromBody] Question model)
        {
            return Ok(await Question.InsertAsync(model));
        }

        [HttpPut()]
        [Route("Update")]
        public async Task<ActionResult> PutAsync([FromBody] Question model)
        {
            return Ok(await Question.UpdateAsync(model));
        }

        [HttpDelete()]
        [Route("Delete")]
        public async Task<ActionResult> DeleteAsync([FromBody] Question model)
        {
            return Ok(await Question.DeleteAsync(model));
        }
    }
}
