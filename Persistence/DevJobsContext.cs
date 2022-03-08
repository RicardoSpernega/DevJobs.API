namespace DevJobs.API.Persistence
{
    using DevJobs.API.Entities;
    public class DevJobsContext
    {
        public DevJobsContext()
        {
            JobVacancies = new List<JobVacancy>();
        }
        public List<JobVacancy> JobVacancies { get; set; }
    }
}
