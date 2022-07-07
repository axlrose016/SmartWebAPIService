using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwilioService.Core.Models;
using TwilioService.Core.Repositories;

namespace SmartWebAPI.Controllers.TwilioController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioCentreController : ControllerBase
    {
        private readonly ITwilioCentreRepo _twilioCentre;
        public TwilioCentreController(ITwilioCentreRepo twilioCentre)
        {
            _twilioCentre = twilioCentre;
        }

        [HttpPost,Route("PostTwilioSMS")]
        public ActionResult PostTwilioSMS([FromBody]TwilioSMS msg)
        {
            try
            {
                _twilioCentre.PostSMS(msg.ReceiverNo, msg.MsgBody);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("PostTwilioSMS Error: " + ex.Message);
            }
        }

        [HttpPost, Route("PostTwilioVoiceCall")]
        public ActionResult PostTwilioVoiceCall([FromBody]TwilioVoicaCall vc)
        {
            try
            {
                _twilioCentre.PostVoiceCall(vc.ReceiverNo);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest("PostVoiceCall Error: " + ex.Message);
            }
        }
    }
}
