using entity.service.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace entity.service
{
    public interface IJobService
    {
        Task<Job> GetJob(Guid id);
        Task<IList<Job>> GetJobs();

        Task<Job> AddJob(Job job);
        Task<IList<Job>> AddJobs(IList<Job> jobs);

        Task<Job> UpdateJob(Job job);
        Task<IList<Job>> UpdateJobs(IList<Job> jobs);

        Task<Job> DeleteJob(Guid id);
        Task<IList<Job>> DeleteJobs(IList<Guid> ids);
    }
}
