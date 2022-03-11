namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using DevJobs.API.Persistence.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {

        private readonly IJobVacancyRepository _repository;
        public JobVacanciesController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        // api/JobVancancies ou api/job-vacancies
        [HttpGet]
        public ActionResult GetAll()
        {
            var jobVacancies = _repository.GetAll();

            return Ok(jobVacancies);
        }

        // GET BY ID api/job-vacancies/4
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            return Ok(jobVacancy);
        }

        // POST api/job-vacancies
        /// <summary>
        /// Cadastrar uma vaga de emprego
        /// </summary>
        /// <remarks>
        /// {
        /// "title": "Dev .NET Jr",
        /// "description": "Auxilio e Manuteçao no desenvolvimento de codigos .NET",
        /// "company": "GabrielDev",
        /// "isRemote": true,
        /// "salaryRange": "3000-4000"
        /// }
        /// </remarks
        /// <param name="model">Dados da vaga</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos.</response>

        [HttpPost]
        public ActionResult Post(AddJobVacancyInputModel model)
        {
            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange
            );

            // Exemplo BadRequest
            if (jobVacancy.Title.Length > 30)
                return BadRequest("Titulo precisa ter menos de 40 caracteres");

            _repository.Add(jobVacancy);

            return CreatedAtAction("GetById",
            new { id = jobVacancy.Id },
            jobVacancy);
        }

        // PUT api/job-vacancies/4
        [HttpPut("{id}")]
        public ActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)

                return NotFound();
            jobVacancy.Update(model.Title, model.Description);
            _repository.Update(jobVacancy);

            return NoContent();
        }
    }
}