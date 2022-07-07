using System;
using System.Collections.Generic;
using System.Text;

namespace TwilioService.Core.Repositories
{
    public interface ITwilioCentreRepo
    {
        void PostSMS(string _recieverNo, string _msgBody);
        void PostVoiceCall(string _receiverNo);
    }
}
