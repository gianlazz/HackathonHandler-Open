using System;

namespace HackathonManager
{
    public class Judge
    {
        public System.Guid GuidId { get; set; }
        public string Event { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string ProfessionalTitle { get; set; }
        public string Description { get; set; }
        //public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsPresent { get; set; }

        public Judge()
        {
            GuidId = Guid.NewGuid();
        }
    }
}