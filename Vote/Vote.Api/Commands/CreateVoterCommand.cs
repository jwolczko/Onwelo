using MediatR;
using Vote.Model;

namespace Vote.Api.Commands
{
    public class CreateVoterCommand : IRequest
    {
        public Person Voter { get; set; }
    }
}
