namespace CarFleet
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            invoker.Execute(new AddCommand(new Car("volvo", "s40", 3, 300)));
            invoker.Execute(new AddCommand(new Car("volvo", "s30", 1, 100)));
            invoker.Execute(new AddCommand(new Car("nissan", "skyline", 2, 200)));
            invoker.Execute(new CountAllCommand());
            invoker.Execute(new CountBrandsCommand());
            invoker.Execute(new GetAveragePriceCommand());
            invoker.Execute(new GetAveragePriceByBrandCommand("volvo"));
            invoker.Execute(new ExitCommand());
        }
    }
}