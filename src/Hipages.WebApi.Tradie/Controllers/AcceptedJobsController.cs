using Hipages.Application.Tradie.AcceptedJobs.Queries.GetAcceptedJobs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hipages.WebApi.Tradie.Controllers
{
    public class AcceptedJobsController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<AcceptedJobsVm>> Get()
        {
            return await Mediator.Send(new GetAcceptedJobsQuery());
        }
    }
}
