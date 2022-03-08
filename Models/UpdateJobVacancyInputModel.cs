namespace DevJobs.API.Models
{
    public record UpdateJobVacancyInputModel(string title, string description, string company, bool isRemote, bool salaryRange)
    {

    }
}