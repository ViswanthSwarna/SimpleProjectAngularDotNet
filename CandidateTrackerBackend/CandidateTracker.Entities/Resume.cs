using System.ComponentModel.DataAnnotations;

namespace CandidateTracker.Entities
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public string ResumeContent { get; set; }
        public string FileName { get; set; }
    }
}
