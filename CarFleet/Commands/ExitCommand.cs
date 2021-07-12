using System;

namespace CarFleet
{
    /// <summary>
    /// Class that defines a command to stop the program
    /// </summary>
    class ExitCommand: ICommand
    {
        /// <summary>
        /// Method for executing the current command
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Program terminated");
            System.Threading.Thread.Sleep(1500);
            Environment.Exit(0);
        }
    }
}