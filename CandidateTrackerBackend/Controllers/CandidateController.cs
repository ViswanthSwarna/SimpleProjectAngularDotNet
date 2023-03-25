using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CandidateTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private static List<CandidateModel> candidateModels = new List<CandidateModel>();


        [HttpGet,Route("CandidateList")]
        public IEnumerable<CandidateModel> Get()
        {
            return candidateModels.ToArray(); 
        }

        [HttpPost, Route("AddCandidate")]
        public IEnumerable<CandidateModel> Post(Object candidateModel)
        {
            CandidateModel deserializedCandidateModel =
                JsonSerializer.Deserialize<CandidateModel>(candidateModel.ToString());
            candidateModels.Add(deserializedCandidateModel);
            return candidateModels.ToArray();
        }
    }
}