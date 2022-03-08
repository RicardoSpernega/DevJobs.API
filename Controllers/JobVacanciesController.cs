namespace DevJobs.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        //GET api/job-vacancies/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }


        //POST api/job-vacancies
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        //PUT api/job-vacancies/4
        [HttpPut("{id}")]
        public IActionResult Put()
        {
            return NoContent();
        }


    }
}
