using System;

namespace Task1
{
    /// <summary>
    /// Auxiliary static class
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Simulates the database
        /// </summary>
        /// <returns>Information about credentials from 'database'</returns>
        public static Credentials[] GetCredentialsFromDB()
        {
            Credentials[] dataBaseCreds = new Credentials[3];
            dataBaseCreds[0] = new Credentials("name1", "password1", "qwerty1");
            dataBaseCreds[1] = new Credentials("name2", "password2", "qwerty2");
            dataBaseCreds[2] = new Credentials("name3", "password3", "qwerty3");
            return dataBaseCreds;
        }


        /// <summary>
        /// Verify person with input credentials
        /// </summary>
        /// <param name="creds">User's credentials</param>
        /// <returns>Does such user mentioned in database or not</returns>
        public static bool IsExistingUser(Credentials creds)
        {
            Credentials[] dbCredentials = Helper.GetCredentialsFromDB();

            foreach (Credentials credData in dbCredentials)
            {
                if (creds.IsEqual(credData))
                {
                    return true;
                }
            }
            return false;
        }


        public static void TryToLogIn(Credentials cred) 
        {
            if (IsExistingUser(cred)) 
            {
                LogIn(cred);
            }
            else 
            {
                throw new Exception("Unable to log in");
            }
        }


        public static void LogIn(Credentials cred) 
        {
            //pass
        }
    }
}
