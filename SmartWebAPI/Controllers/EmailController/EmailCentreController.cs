using EmailService.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SmartWebAPI.Controllers.EmailController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailCentreController : ControllerBase
    {
        private readonly IEmailCentreRepo _emailRepo;
        public EmailCentreController(IEmailCentreRepo emailRepo)
        {
            _emailRepo = emailRepo;
        }

        [HttpPost,Route("PostEmail")]
        public ActionResult PostEmail([FromBody]MailMessage mailMsg)
        {
            try
            {
                _emailRepo.SendEmail(mailMsg);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest("PostEmail Error: " + ex.Message);
            }
        }
    }
}
