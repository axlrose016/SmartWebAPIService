using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using TwilioService.Core.Models;
using TwilioService.Core.Repositories;

namespace TwilioService.Persistence.Repositories
{
    public class TwilioCentreRepo : ITwilioCentreRepo
    {
        private readonly TwilioConfiguration _twilioConfig;
        public TwilioCentreRepo(TwilioConfiguration twilioConfig)
        {
            _twilioConfig = twilioConfig;
        }

        public void PostSMS(string _recieverNo, string _msgBody)
        {
            TwilioClient.Init(_twilioConfig.AcctId, _twilioConfig.AuthToken);
            var msg = MessageResource.Create(
                body: _msgBody,
                from: new PhoneNumber(_twilioConfig.TwilioNumber),
                to: new PhoneNumber(_recieverNo)
            );
        }

        public void PostVoiceCall(string _receiverNo)
        {
            TwilioClient.Init(_twilioConfig.AcctId, _twilioConfig.AuthToken);

            var to = new PhoneNumber(_receiverNo);
            var from = new PhoneNumber(_twilioConfig.TwilioNumber);
            var call = CallResource.Create(to, from,
                url: new Uri("http://demo.twilio.com/docs/voice.xml"));
        }
    }
}
