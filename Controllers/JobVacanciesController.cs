namespace DevJobs.API.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        // api/JobVancancies ou api/job-vacancies
        [HttpGet]
        public ActionResult GetAll()
        {

            return Ok();
        }

        // GET BY ID api/job-vacancies/4
        [HttpGet("{id}")]
        public ActionResult GetById(int Id)
        {

            return Ok();
        }

        // POST api/job-vacancies
        [HttpPost]
        public ActionResult Post(int Id)
        {

            return Ok();
        }

        // PUT api/job-vacancies/4
        [HttpPut("{id}")]
        public ActionResult Put(int Id)
        {

            return NoContent();
        }
    }
}