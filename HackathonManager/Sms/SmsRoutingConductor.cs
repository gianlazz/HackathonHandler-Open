using HackathonManager.DTO;
using HackathonManager.Interfaces;
using HackathonManager.Models;
using HackathonManager.RepositoryPattern;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace HackathonManager.Sms
{
    public class SmsRoutingConductor
    {
        #region fields
        //THE GOAL IS TO HANDLE EACH ITEM, SAVE IT TO THE DB, AND DEQUEUE IT
        //STACK, QUEUE OR BAG??
        public static ConcurrentBag<SmsDto> InboundMessages = new ConcurrentBag<SmsDto>();
        public static ConcurrentBag<MentorRequest> MentorRequests = new ConcurrentBag<MentorRequest>();

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
        public void ProcessMentorRequests()
        {
            foreach (var inboundSms in InboundMessages.Where(x => x.DateTimeWhenProcessed == null))
            {
                foreach (var mentorRequest in MentorRequests.Where(x => x.DateTimeWhenProcessed == null))
                {
                    if (mentorRequest.OutboundSms.ToPhoneNumber == inboundSms.FromPhoneNumber)
                    {
                        if (IsAcceptanceResponse(inboundSms))
                        {
                            _db.Delete<MentorRequest>(mentorRequest);
                            _db.Delete<SmsDto>(inboundSms);
                            mentorRequest.RequestAccepted = true;
                            inboundSms.DateTimeWhenProcessed = DateTime.Now;
                            mentorRequest.DateTimeWhenProcessed = DateTime.Now;
                            mentorRequest.InboundSms = inboundSms;
                            _db.Add<MentorRequest>(mentorRequest);
                            _db.Add<SmsDto>(inboundSms);
                            //NOTIFY SIGNALR TEAM
                        }
                        else if (IsRejectionResponse(inboundSms))
                        {
                            _db.Delete<MentorRequest>(mentorRequest);
                            _db.Delete<SmsDto>(inboundSms);
                            mentorRequest.RequestAccepted = false;
                            inboundSms.DateTimeWhenProcessed = DateTime.Now;
                            mentorRequest.DateTimeWhenProcessed = DateTime.Now;
                            mentorRequest.InboundSms = inboundSms;
                            _db.Add<MentorRequest>(mentorRequest);
                            _db.Add<SmsDto>(inboundSms);
                            //NOTIFY SIGNALR TEAM
                        }
                        else
                        {
                            _db.Delete<SmsDto>(inboundSms);
                            inboundSms.DateTimeWhenProcessed = DateTime.Now;
                            UnIdentifiedResponse(inboundSms);
                            _db.Add<SmsDto>(inboundSms);
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
        //private void ResponseProcessedConfirmation(SmsDto sms)
        //{
        //    string message = $"Response confirmed.";
        //    _sms.SendSms(uint.Parse(sms.FromPhoneNumber), message);
        //}
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
