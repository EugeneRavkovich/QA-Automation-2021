namespace CarFleet
{
    /// <summary>
    /// Class that sends a request to execute the command
    /// </summary>
    class Invoker
    {
        /// <summary>
        /// Method that executes the provided command
        /// </summary>
        /// <param name="command">Command to execute</param>
        public void Execute(ICommand command)
        {
            if (command is null)
            {
                return;
            }
            command.Execute();
        }
    }
}