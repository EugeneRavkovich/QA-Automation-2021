using System;

namespace Task1
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Credentials cred = new Credentials("name2", "password2", "qwerty2");
            
            try
            {
                Helper.TryToLogIn(cred);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}