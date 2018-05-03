using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager.RepositoryPattern
{
    class Log
    {
        public DateTime DateTime { get { return DateTime.Now; } }
        public string Details { get; set; }
    }
}
