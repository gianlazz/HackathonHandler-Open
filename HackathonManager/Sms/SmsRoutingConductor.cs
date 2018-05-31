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
                        mentorRequest

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
        }
        #endregion

        #region Helper Methods
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

    public enum MatchType
    {
        None,
        MentorRequest,
        JudgingVote
    }
}
