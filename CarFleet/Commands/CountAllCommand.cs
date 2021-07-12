using System;

namespace CarFleet
{
    class CountAllCommand: ICommand
    {
        private CarFleet _fleet;


        public CountAllCommand()
        {
            this._fleet = CarFleet.GetFleet();
        }


        public void Execute()
        {
            Console.WriteLine(_fleet.CountAll());
        }
    }
}