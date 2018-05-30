using HackathonManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager.Sms
{
    public class InboundSmsRoutingConductor
    {
        public Queue<SmsDto> InboundMessages { get; set; }
        public Queue<SmsDto> OutboundMessages { get; set; }

        public InboundSmsRoutingConductor()
        {
            InboundMessages = new Queue<SmsDto>();
            OutboundMessages = new Queue<SmsDto>();
        }

        public TwoWayCommMatch ProcessQueues()
        {
            var matches = new List<TwoWayCommMatch>();

            foreach (var inboundSms in InboundMessages)
            {
                foreach (var outboundsms in OutboundMessages)
                {
                    if (outboundsms.ToPhoneNumber == inboundSms.FromPhoneNumber)
                    {
                        matches.Add(new TwoWayCommMatch() { OutBound = outboundsms, Inbound = inboundSms });
                    }
                }
            }

            return null;
        }

        private MatchType EvaluateMatchType()
        {


            return MatchType.None;
        }
    }

    public class TwoWayCommMatch
    {
        public SmsDto OutBound { get; set; }
        public SmsDto Inbound { get; set; }
        public MatchType MatchType { get; set; }
    }

    public enum MatchType
    {
        None,
        MentorRequest,
        JudgingVote
    }
}
