using MediatR;
using Microsoft.EntityFrameworkCore;
using Vote.Data;
using Vote.Model;

namespace Vote.Api.Queries
{
    public class CandidateQueryHandler : IRequestHandler<CandidateQuery, IEnumerable<Candidate>>
    {
        private readonly VoteDb _context;

        public CandidateQueryHandler(VoteDb context)
        {
            _context = context;
        }

        public Task<IEnumerable<Candidate>> Handle(CandidateQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new List<Candidate>();
                var candidates = _context.Persons
                    .Where(p => p.Type == Data.Entities.PersonType.Candidate)
                    .Include(p => p.VoterVots)
                    .ToList();

                foreach (var candidate in candidates)
                {
                    result.Add(new Candidate 
                    { 
                        Id = candidate.Id, 
                        FirstName = candidate.FirstName, 
                        LastName = candidate.LastName,
                        VotesNumber = candidate.VoterVots.Count,
                    });
                }

                return Task.FromResult(result.AsEnumerable());
            }
            catch (Exception)
            {
                return Task.FromResult(new List<Candidate>().AsEnumerable());
            }
        }
    }
}
