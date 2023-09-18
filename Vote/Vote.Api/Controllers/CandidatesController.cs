using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vote.Api.Queries;
using Vote.Model;

namespace Vote.Api.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        
        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            var query = new CandidateQuery();
            var result = await _mediator.Send(query);
            return result;
       }


    }
}
