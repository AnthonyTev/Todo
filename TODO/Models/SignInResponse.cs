namespace TODO.Models
{
    public class SignInResponse
    {
        public int status { get; set; }
        public UserData data { get; set; }
        public string message { get; set; }
    }

    public class UserData
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string timemodified { get; set; }
    }
}