namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using DevJobs.API.Persistence.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Serilog;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly IJobVacancyRepository _repository;
        public JobVacanciesController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _repository.GetAll();

            return Ok(jobVacancies);
        }

        //GET api/job-vacancies/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Log.Information("Get JobVacancy by id: " + id);

            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            return Ok(jobVacancy);
        }


        //POST api/job-vacancies
        /// <summary>
        /// Cadastrar vaga de emprego
        /// </summary>
        /// <remarks>
        /// {
        /// "title": "Dev Pleno 1",
        /// "description": "Desenvolvedor .net Pleno ",
        /// "company": "Zup Innovation",
        /// "isRemote": true,
        /// "salaryRange": "7000-11000"
        ///  }
        ///  </remarks>
        /// <param name="model">Dados da vaga</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso.</response>
        /// <response code="400">Dados invalido.</response>
        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange);

            if (jobVacancy.Title.Length > 30)
                return BadRequest("Título precisa ser menor de 30 caracteres!");

            _repository.Add(jobVacancy);

            return CreatedAtAction(
                "GetById",
                new { id = jobVacancy.Id },
                jobVacancy);
        }

        //PUT api/job-vacancies/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            jobVacancy.Update(jobVacancy.Title, jobVacancy.Description);

            _repository.Update(jobVacancy);

            return NoContent();
        }


    }
}
