using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Data.Entities
{
    [Table("Person")]
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonType Type { get; set; }

        public ICollection<Vote> CandidateVots { get; }
        public ICollection<Vote> VoterVots { get; }
    }
}
