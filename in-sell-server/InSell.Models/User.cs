namespace InSell.Models
{
    public class User : IBasePersistable
    {
        public string Id { get; set; }

        public string LoginId { get; set; }

        public string Role { get; set; }

        public bool IsLoginDisabled { get; set; }

        public UserProfile Profile { get; set; }

        public string Type => "User";
    }
}
