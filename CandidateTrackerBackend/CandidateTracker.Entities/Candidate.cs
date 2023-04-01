using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateTracker.Entities
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; } 
        public string Address { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
