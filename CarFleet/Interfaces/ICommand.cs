namespace CarFleet
{
    /// <summary>
    /// Declares a method for executing commands
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Method for executing commands
        /// </summary>
        void Execute();
    }
}