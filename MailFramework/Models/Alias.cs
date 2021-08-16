namespace MailFramework.Models
{
    /// <summary>
    /// Class that defines the entity of an Alias object 
    /// </summary>
    public class Alias
    {
        /// <summary>
        /// Name of an user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname of an user
        /// </summary>
        public string Surname { get; set; }


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="name">Name of an user</param>
        /// <param name="surname">Surname of an user</param>
        public Alias(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }


        /// <summary>
        /// Overrided method Equals for comparing two Alias objects
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if objects are equal, else false</returns>
        public override bool Equals(object obj)
        {
            Alias comparableAlias = (Alias)obj;
            return this.Name == comparableAlias.Name &&
                this.Surname == comparableAlias.Surname;
        }
    }
}
