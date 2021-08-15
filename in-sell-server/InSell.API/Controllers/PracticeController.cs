using InSell.Models;
using InSell.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InSell.API.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PracticeController : ControllerBase
    {
        private readonly IPracticeService _practiceService;

        public PracticeController(IPracticeService practiceService)
        {
            _practiceService = practiceService;
        }

        [HttpGet("{practiceId}")]
        public Practice GetPractice([FromRoute] long practiceId)
        {
            return _practiceService.GetPractice(practiceId);
        }

        [HttpPost]
        public void CreatePractice([FromBody] Practice practice)
        {
            _practiceService.CreatePractice(practice);
        }

        [HttpPut]
        public void UpdatePractice([FromBody] Practice practice)
        {
            _practiceService.UpdatePractice(practice);
        }

        [HttpDelete("{practiceId}")]
        public void DeletePractice(long practiceId)
        {
            _practiceService.DeletePractice(practiceId);
        }

    }
}