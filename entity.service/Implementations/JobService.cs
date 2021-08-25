using entity.service.model;
using Entities = entity.data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using entity.data;
using System.Threading.Tasks;

namespace entity.service.Implementations
{
    internal class JobService : ServiceBase<Job, Entities.Job>, IJobService
    {
        protected override string[] DefaultIncludes => new string[]
        {
            "User"
        };

        public JobService(IMapper mapper, tododbContext db) : base(mapper, db)
        {
        }

        public async Task<Job> GetJob(Guid id)
        {
            return await Single(x => x.Id == id);
        }

        public async Task<IList<Job>> GetJobs()
        {
            return await Query();
        }

        public async Task<Job> AddJob(Job job)
        {
            var result = await base.Add(job);
            return result ? await base.Single(x => x.Id == job.Id) : null;
        }

        public async Task<IList<Job>> AddJobs(IList<Job> jobs)
        {
            var result = new List<Job>();

            foreach (var job in jobs)
            {
                result.Add(await AddJob(job));
            }

            return result;
        }

        public async Task<Job> UpdateJob(Job job)
        {
            var result = await base.Update(job);
            return result ? await base.Single(x => x.Id == job.Id) : null;
        }

        public async Task<IList<Job>> UpdateJobs(IList<Job> jobs)
        {
            var result = new List<Job>();

            foreach (var job in jobs)
            {
                result.Add(await UpdateJob(job));
            }

            return result;
        }

        public async Task<Job> DeleteJob(Guid id)
        {
            var originJob = await base.Single(x => x.Id == id);
            var result = await base.Delete(originJob);
            return result ? originJob : null;
        }

        public async Task<IList<Job>> DeleteJobs(IList<Guid> ids)
        {
            var result = new List<Job>();

            foreach (var id in ids)
            {
                result.Add(await DeleteJob(id));
            }

            return result;
        }
    }
}
