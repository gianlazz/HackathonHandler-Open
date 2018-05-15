using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager
{
    class Sms
    {
        public DateTime DateCreated { get; set; }
        public string ToPhoneNumber { get; set; }
        public string FromPhoneNumber { get; set; }
        public string MessageBody { get; set; }
        /// <summary>
        /// A string that uniquely identifies this message
        /// </summary>
        public string Sid { get; set; }
    }
}
