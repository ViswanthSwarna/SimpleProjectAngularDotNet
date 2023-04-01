using CandidateTracker.Models;
using CandidateTracker.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CandidateTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeService _resumeService;
        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        [HttpPost("upload")]
        public IActionResult UploadFile(IFormFile file) 
        {
            ResumeModel resumeModel = null;
            if (file.Length> 0)
            {
                byte[] bytes = null;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                var fileBase64 = Convert.ToBase64String(bytes);
                resumeModel = new ResumeModel { ResumeContent = fileBase64, FileName = file.FileName };
                resumeModel = _resumeService.AddResume(resumeModel);
            }
            return Ok(resumeModel);
        }


        [HttpPost("update/{id}")]
        public IActionResult UpdateFile(IFormFile file, int id)
        {
            ResumeModel resumeModel = null;
            if (file.Length > 0)
            {
                byte[] bytes = null;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                var fileBase64 = Convert.ToBase64String(bytes);
                resumeModel = new ResumeModel {ResumeId = id, ResumeContent = fileBase64, FileName = file.FileName };
                resumeModel = _resumeService.UpdateResume(resumeModel);
            }
            return Ok(resumeModel);
        }

        [HttpGet("download/{id}")]
        public IActionResult Download(int id)
        {
            var resumeModel = _resumeService.GetResume(id);
            var bytes = Convert.FromBase64String(resumeModel.ResumeContent);
            return File(bytes, "application/pdf", resumeModel.FileName);
        }
    }
}
