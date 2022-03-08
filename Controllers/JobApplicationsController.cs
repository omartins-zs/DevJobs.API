namespace DevJobs.API.Controllers
{
    using DevJobs.API.Models;
    using Microsoft.AspNetCore.Mvc;

// Rota diferente Por que para criar um Application tem que ter um identificador
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            
            return Ok();
        }
    }
}