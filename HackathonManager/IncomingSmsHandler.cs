using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonManager.DTO;

namespace HackathonManager
{
    public class IncomingSmsHandler
    {
        private List<Func<string, bool>> _actionConditions;

        public IncomingSmsHandler(List<Func<string, bool>> actionConditions)
        {
            _actionConditions = actionConditions;
        }

        public void Process(SmsDto incomingSmsDto)
        {
            
        }
    }
}
