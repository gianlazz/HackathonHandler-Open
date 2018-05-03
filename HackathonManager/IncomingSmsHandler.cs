using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonManager.DTO;
using HackathonManager.Interfaces;
using HackathonManager.PocoModels;
using HackathonManager.RepositoryPattern;

namespace HackathonManager
{
    public class IncomingSmsHandler
    {
        private ISmsService _smsService;
        private IRepository _repo;
        private ILogger _logger;

        public IncomingSmsHandler(ISmsService smsService, IRepository repository, ILogger logger)
        {
            _smsService = smsService;
            _repo = repository;
            _logger = logger;
        }

        public void Process(SmsDto incomingSmsDto)
        {
            CheckIfTheyreValidUser(incomingSmsDto);
        }

        private void CheckIfTheyreValidUser(SmsDto incomingSms)
        {
            try
            {
                if(_repo.Single<Mentor>(x => x.PhoneNumber == incomingSms.FromPhoneNumber) != null) { }
                if(_repo.Single<Judge>(x => x.PhoneNumber == incomingSms.FromPhoneNumber) != null) { }
                if(_repo.Single<Team>(x => x.PhoneNumber == incomingSms.FromPhoneNumber) != null) { }
            }
            catch (Exception exception)
            {
                _smsService.SendSms(uint.Parse(incomingSms.FromPhoneNumber), exception.ToString());
                _logger.Log(exception);
            }
        }
    }
}
