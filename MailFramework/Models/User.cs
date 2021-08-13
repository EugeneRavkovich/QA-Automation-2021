namespace MailFramework.Models
{
    /// <summary>
    /// A class that defines the entity of an User object
    /// </summary>
    public class User
    {
        /// <summary>
        /// User's name
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User's password
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="username">User's name</param>
        /// <param name="password">User's password</param>
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }


        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns>User object as a string</returns>
        public override string ToString()
        {
            return $"{this.Username}\n{this.Password}";
        }
    }
}
