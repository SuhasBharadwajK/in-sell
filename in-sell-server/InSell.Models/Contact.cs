namespace InSell.Models
{
    public class Contact : IBasePersistable
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Designation { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string LinkedInLink { get; set; }

        public bool IsEmailValidated { get; set; }

        public string Type => "Contact";
    }
}
