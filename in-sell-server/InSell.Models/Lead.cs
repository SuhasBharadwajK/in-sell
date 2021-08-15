using System;

namespace InSell.Models
{
    public class Lead : IBasePersistable
    {
        public Lead()
        {
            this.Company = new Company();
            this.Contact = new Contact();
            this.AddedBy = new UserProfile();
            this.Practice = new Practice();
            this.BDR = new UserProfile();
        }

        public string Id { get; set; }

        public UserProfile BDR { get; set; }

        public Company Company { get; set; }

        public Contact Contact { get; set; }

        public string Source { get; set; }

        public DateTime AddedOn { get; set; }

        public UserProfile AddedBy { get; set; }

        public Practice Practice { get; set; }

        public LeadStatus Status { get; set; }

        public string Type => "Lead";
    }
}
