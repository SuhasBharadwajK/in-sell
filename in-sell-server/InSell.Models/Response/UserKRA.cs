using System;
using System.Collections.Generic;
using System.Text;

namespace InSell.Models.Response
{
    public class UserKRA
    {
        public string UserProfileId { get; set; }

        public string FirstName { get; set; }

        public string ProfilePicUrl { get; set; }

        public string ReportingToId { get; set; }

        public int LeadsCount { get; set; }
    }
}
