using System;

namespace InSell.Models
{
    public class UserProfile : IBasePersistable
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ProfilePicUrl { get; set; }

        public string ReportingToId { get; set; } // ID of the user reporting to.

        public string Type => "UserProfile";
    }
}
