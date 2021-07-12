namespace CarFleet
{
    class Invoker
    {
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