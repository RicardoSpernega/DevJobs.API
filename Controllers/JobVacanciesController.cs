namespace DevJobs.API.Controllers
{
    using DevJobs.API.Models;
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
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            return Ok();
        }

        //PUT api/job-vacancies/4
        [HttpPut("{id}")]
        public IActionResult Put(UpdateJobVacancyInputModel model)
        {
            return NoContent();
        }


    }
}
