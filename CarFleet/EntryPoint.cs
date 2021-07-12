namespace CarFleet
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            Utility.DisplayWelcomeMessage();
            while (true)
            {
                invoker.Execute(Parser.Parse(System.Console.ReadLine().Split(' ')));
            }
        }
    }
}