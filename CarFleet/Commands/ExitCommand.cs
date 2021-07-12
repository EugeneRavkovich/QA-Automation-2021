using System;

namespace CarFleet
{
    class ExitCommand: ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Program terminated");
            System.Threading.Thread.Sleep(1500);
            Environment.Exit(0);
        }
    }
}