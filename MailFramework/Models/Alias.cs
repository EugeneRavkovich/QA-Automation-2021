namespace MailFramework.Models
{
    public class Alias
    {
        public string Name { get; set; }

        public string Surname { get; set; }


        public Alias(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }


        public override bool Equals(object obj)
        {
            Alias comparableAlias = (Alias)obj;
            return this.Name == comparableAlias.Name &&
                this.Surname == comparableAlias.Surname;
        }
    }
}
