namespace Vote.Model
{
    public class Voter : Person
    {
        public override PersonType Type { get; set; } = PersonType.Voter;

        public string HasVote { get; set; }
    }
}