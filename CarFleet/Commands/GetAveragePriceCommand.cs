using System;

namespace CarFleet
{
    class GetAveragePriceCommand: ICommand
    {
        private CarFleet _fleet;


        public GetAveragePriceCommand()
        {
            this._fleet = CarFleet.GetFleet();
        }


        public void Execute()
        {
            Console.WriteLine(_fleet.GetAveragePrice());
        }
    }
}