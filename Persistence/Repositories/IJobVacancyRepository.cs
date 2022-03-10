using DevJobs.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevJobs.API.Persistence.Repositories
{
    public interface IJobVacancyRepository
    {
        List<JobVacancy> GetAll();
        JobVacancy GetById(int id);
        void Add(JobVacancy jobVacancy);
        void AddApplication(JobApplication jobApplication);
        void Update(JobVacancy jobVacancy);
        void UpdateApplication(JobApplication jobApplication);
    }
}
