namespace Vote.Model
{
    public class Candidate : Person
    {
        public long VotesNumber { get; set; }
        public override PersonType Type { get; set; } = PersonType.Candidate;
    }
}
