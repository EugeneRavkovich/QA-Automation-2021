namespace Task1
{
    /// <summary>
    /// A class that represents an credentials object
    /// </summary>
    public class Credentials
    {
        public string Login { get; private set; }
        private string Password { get; set; }
        private string SecretQuestion { get; set; }


        public Credentials(string loginName, string password,
            string secretQuestion)
        {
            this.Login = loginName;
            this.Password = password;
            this.SecretQuestion = secretQuestion;
        }       


        public bool IsEqual(Credentials creds)
        {
            return (Login == creds.Login
                    && Password == creds.Password
                    && SecretQuestion == creds.SecretQuestion);            
        }
    }
}
