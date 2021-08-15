using InSell.Models;
using InSell.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISell.API.Controllers
{
    [Route("api/email")]
    [ApiController]

    public class EmailController: ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            this._emailService = emailService;
        }

        [HttpGet("")]
        public void SendEmail()
        {
            _emailService.SendEmailAsync();
        }
    }
}