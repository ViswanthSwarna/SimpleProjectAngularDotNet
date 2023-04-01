using CandidateTracker.Models;
using CandidateTracker.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CandidateTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var candidates= _candidateService.GetCandidates();
            return Ok(candidates); 
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var candidate = _candidateService.GetCandidate(id);
            return Ok(candidate);
        }

        [HttpPost]
        public IActionResult Add(CandidateModel candidateModel)
        {
            var inserted = _candidateService.AddCandidate(candidateModel);
            return Ok(inserted);
        }

        [HttpPut]
        public IActionResult Update(CandidateModel candidateModel)
        {
            var inserted = _candidateService.UpdateCandidate(candidateModel);
            return Ok(inserted);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var inserted = _candidateService.DeleteCandidate(id);
            return Ok(inserted);
        }
    }
}