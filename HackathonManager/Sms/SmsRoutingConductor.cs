using HackathonManager.DTO;
using HackathonManager.Models;
using HackathonManager.RepositoryPattern;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager.Sms
{
    public class SmsRoutingConductor
    {
        #region fields
        public static ConcurrentQueue<SmsDto> InboundMessages = new ConcurrentQueue<SmsDto>();
        public static ConcurrentQueue<SmsDto> OutboundMessages = new ConcurrentQueue<SmsDto>();
        private IRepository _Db;
        private List<TwoWayCommMatch> _matches = new List<TwoWayCommMatch>();

        public static ConcurrentQueue<MentorRequest> UnprocessedMentorRequests = new ConcurrentQueue<MentorRequest>();
        #endregion

        #region ctor
        public SmsRoutingConductor(IRepository repository)
        {
            _Db = repository;
        }
        #endregion

        #region Public Methods
        public void ProcessQueues()
        {
            foreach (var inboundSms in InboundMessages)
            {
                foreach (var outboundsms in OutboundMessages)
                {
                    if (outboundsms.ToPhoneNumber == inboundSms.FromPhoneNumber)
                    {
                        var match = new TwoWayCommMatch() { Outbound = outboundsms, Inbound = inboundSms };
                        match.MatchType = EvaluateMatchType(match);
                        _Db.Add<TwoWayCommMatch>(match);
                        _matches.Add(match);
                    }
                }
            }

        }
        #endregion

        #region MentorRequest Handeling
        private bool CheckIfMentorRequest(TwoWayCommMatch twoWay)
        {
            /* $"🔥 {mentor.FirstName}, team {team.Name}, located in {team.Location},
             * has requested your assistance.\n\n Reply with:\nY to accept \nor\n N to reject the request
             */
            if (twoWay.Outbound.MessageBody.Contains("requested your assistance"))
            {
                return true;
            }

            return false;
        }

        private void ReplyToMentorRequests()
        {
            var studentMentorRequests = _matches.Where(x => x.MatchType == MatchType.MentorRequest).ToList();

            foreach (var request in studentMentorRequests)
            {

            }
        }
        #endregion

        #region Helper Methods
        private MatchType EvaluateMatchType (TwoWayCommMatch twoWay)
        {
            if (CheckIfMentorRequest(twoWay)) { return MatchType.MentorRequest; }
            //if (CheckIfJudgingVote(twoWay)) { return MatchType.JudgingVote; }

            return MatchType.None;
        }
        #endregion

    }

    public class TwoWayCommMatch
    {
        public SmsDto Outbound { get; set; }
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
