using MediatR;
using Vote.Data;
using Vote.Data.Entities;

namespace Vote.Api.Commands
{
    public class CreateVoterCommandHandler : IRequestHandler<CreateVoterCommand>
    {
        private readonly VoteDb _context;

        public CreateVoterCommandHandler(VoteDb context)
        {
            _context = context;
        }

        public Task Handle(CreateVoterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newCandidate = new Person { FirstName = request.Voter.FirstName, LastName = request.Voter.LastName, Type = PersonType.Voter };

                _context.Add(newCandidate);

                _context.SaveChanges();
            }
            catch (Exception exception)
            {

                throw;
            }

            return Task.CompletedTask;
        }
    }
}
