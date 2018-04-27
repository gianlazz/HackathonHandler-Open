using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager.DTO
{
    public class Mentor
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsPresent { get; set; }
    }
}
