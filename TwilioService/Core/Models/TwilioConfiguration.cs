using System;
using System.Collections.Generic;
using System.Text;

namespace TwilioService.Core.Models
{
    public class TwilioConfiguration
    {
        public string AcctId { get; set; }
        public string AuthToken { get; set; }
        public string TwilioNumber { get; set; }
    }

    public class TwilioSMS
    {
        public string ReceiverNo { get; set; }
        public string MsgBody { get; set; }
    }

    public class TwilioVoicaCall
    {
        public string ReceiverNo { get; set; }
    }
}
