using entity.service;
using entity.service.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity.api.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="jobService"></param>
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        /// <summary>
        /// Get jobs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IList<Job>), 200)]
        public async Task<IActionResult> GetJobs()
        {
            return Ok(await _jobService.GetJobs());
        }

        /// <summary>
        /// Get a job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Job), 200)]
        public async Task<IActionResult> GetJob(Guid id)
        {
            return Ok(await _jobService.GetJob(id));
        }

        /// <summary>
        /// Create a job
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(Job), 200)]
        public async Task<IActionResult> CreateJob(Job job)
        {
            return Ok(await _jobService.AddJob(job));
        }

        /// <summary>
        /// Update a job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Job), 200)]
        public async Task<IActionResult> UpdateJob(Guid id, Job job)
        {
            job.Id = id;
            return Ok(await _jobService.UpdateJob(job));
        }

        /// <summary>
        /// Delete a job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Job), 200)]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            return Ok(await _jobService.DeleteJob(id));
        }
    }
}
