namespace MailFramework.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }


        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }


        public override string ToString()
        {
            return $"{this.Username}\n{this.Password}";
        }
    }
}
