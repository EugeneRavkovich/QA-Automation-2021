using System;

namespace CarFleet
{
    class GetAveragePriceByBrandCommand: ICommand
    {
        private CarFleet _fleet;
        private string _brand;


        public GetAveragePriceByBrandCommand(string brand)
        {
            this._fleet = CarFleet.GetFleet();
            this._brand = brand;
        }


        public void Execute()
        {
            Console.WriteLine(_fleet.GetAveragePriceByBrand(_brand));
        }
    }
}