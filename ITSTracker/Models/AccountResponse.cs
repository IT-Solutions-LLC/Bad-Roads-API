namespace ITSTracker.Models
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public bool LoggedIn { get; set; }
    }
}