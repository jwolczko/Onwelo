using MediatR;
using Vote.Model;

namespace Vote.Api.Commands
{
    public class CreateCandidateCommand:IRequest
    {
        public Person Candidate { get; set; }
    }
}
