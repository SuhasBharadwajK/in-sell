using System;
using System.Collections.Generic;
using System.Text;

namespace InSell.Models
{
    public class Practice : IBasePersistable
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public UserProfile BDR { get; set; }

        public string Type => "Practice";
    }
}
