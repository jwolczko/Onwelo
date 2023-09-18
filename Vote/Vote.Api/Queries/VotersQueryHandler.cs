using MediatR;
using Microsoft.EntityFrameworkCore;
using Vote.Data;
using Vote.Model;

namespace Vote.Api.Queries
{
    public class VotersQueryHandler : IRequestHandler<VotersQuery, IEnumerable<Voter>>
    {
        private readonly VoteDb _context;

        public VotersQueryHandler(VoteDb context)
        {
            _context = context;
        }

        public Task<IEnumerable<Voter>> Handle(VotersQuery request, CancellationToken cancellationToken)
        {
            var allVoters = new List<Voter>();
            try
            {
                var candidates = _context.Persons
                    .Where(p => p.Type == Data.Entities.PersonType.Voter)
                    .Include(p => p.CandidateVots)
                    .ToList();

                foreach (var candidate in candidates)
                {
                    allVoters.Add(new Voter 
                    { 
                        Id = candidate.Id, 
                        FirstName = candidate.FirstName, 
                        LastName = candidate.LastName,
                        HasVote = candidate.CandidateVots.Any()? "v": "x"                        
                    });
                }

                return Task.FromResult(allVoters.AsEnumerable());
            }
            catch (Exception)
            {
                return Task.FromResult(new List<Voter>().AsEnumerable());
            }
        }
    }
}
