using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hipages.Application.Tradie.NewJobs.Commands.UpdateNewJob;
using Hipages.Application.Tradie.NewJobs.Queries.GetNewJobs;
using Microsoft.AspNetCore.Mvc;

namespace Hipages.WebApi.Tradie.Controllers
{
    public class NewJobsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<NewJobsVm>> Get()
        {
            return await Mediator.Send(new GetNewJobsQuery());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateNewJobCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}