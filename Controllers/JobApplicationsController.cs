namespace DevJobs.API.Controllers
{
    using DevJobs.API.Models;
    using Microsoft.AspNetCore.Mvc;
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : Controller
    {
        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            return NoContent();
        }
    }
}
