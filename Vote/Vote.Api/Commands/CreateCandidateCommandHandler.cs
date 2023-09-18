using MediatR;
using Vote.Data;
using Vote.Data.Entities;

namespace Vote.Api.Commands
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand>
    {
        private readonly VoteDb _context;

        public CreateCandidateCommandHandler(VoteDb context)
        {
            _context = context;
        }

        public Task Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newCandidate = new Person { FirstName = request.Candidate.FirstName, LastName = request.Candidate.LastName, Type = PersonType.Candidate };

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
