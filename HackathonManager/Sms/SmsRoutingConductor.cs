using HackathonManager.DTO;
using HackathonManager.Interfaces;
using HackathonManager.Models;
using HackathonManager.RepositoryPattern;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace HackathonManager.Sms
{
    public class SmsRoutingConductor
    {
        #region fields
        //THE GOAL IS TO HANDLE EACH ITEM, SAVE IT TO THE DB, AND DEQUEUE IT
        public static ConcurrentQueue<SmsDto> InboundMessages = new ConcurrentQueue<SmsDto>();
        public static ConcurrentQueue<SmsDto> OutboundMessages = new ConcurrentQueue<SmsDto>();
        public static ConcurrentQueue<MentorRequest> UnprocessedMentorRequests = new ConcurrentQueue<MentorRequest>();

        //private static List<TwoWayCommMatch> _matches = new List<TwoWayCommMatch>();

        private readonly IRepository _db;
        private readonly ISmsService _sms;
        #endregion

        #region ctor
        public SmsRoutingConductor(IRepository repository, ISmsService sms)
        {
            _db = repository;
            _sms = sms;
        }
        #endregion

        #region Public Methods
        public void ProcessQueues()
        {
            foreach (var inboundSms in InboundMessages)
            {
                foreach (var mentorRequest in UnprocessedMentorRequests)
                {
                    if (mentorRequest.OutboundSms.ToPhoneNumber == inboundSms.FromPhoneNumber)
                    {
                        //mentorRequest

                    }
                }
            }

            foreach (var match in _matches)
            {
                if (match.MatchType == MatchType.MentorRequest)
                {
                    //DEAL WITH OBJECT IN unproccessedMentorRequests

                    if (IsAcceptanceResponse(new SmsDto()))
                    {
                        //NOTIFY PARTY OF ACCEPTANCE
                    }
                    if (IsRejectionResponse(new SmsDto()))
                    {

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
        //private MatchType EvaluateMatchType (TwoWayCommMatch twoWay)
        //{
        //    if (CheckIfMentorRequest(twoWay)) { return MatchType.MentorRequest; }
        //    //if (CheckIfJudgingVote(twoWay)) { return MatchType.JudgingVote; }

        //    return MatchType.None;
        //}
        private bool IsAcceptanceResponse(SmsDto sms)
        {
            if(sms.MessageBody.Trim().ToLower() == "y" ||
                sms.MessageBody.Trim().ToLower() == "yes")
                return true;

            return false;
        }
        private bool IsRejectionResponse(SmsDto sms)
        {
            if (sms.MessageBody.Trim().ToLower() == "n" ||
                sms.MessageBody.Trim().ToLower() == "no")
                return true;

            return false;
        }
        private void ResponseProcessedConfirmation(SmsDto sms)
        {
            string message = $"Response confirmed.";
            _sms.SendSms(uint.Parse(sms.FromPhoneNumber), message);
        }
        private void UnIdentifiedResponse(SmsDto sms)
        {
            string message = $"Uncertain how to execute your objective.";
            _sms.SendSms(uint.Parse(sms.FromPhoneNumber), message);
            //RESEND THE INITAL PROMPT SMS
            _sms.SendSms(uint.Parse(sms.FromPhoneNumber), sms.MessageBody);
            //SHOULD IT BE ADDED TO THE OUTBOUND MESSAGES?
        }
        #endregion

    }

    //public class TwoWayCommMatch
    //{
    //    public SmsDto Outbound { get; set; }
    //    public SmsDto Inbound { get; set; }
    //    public MatchType MatchType { get; set; }
    //}

    public enum MatchType
    {
        None,
        MentorRequest,
        JudgingVote
    }
}
