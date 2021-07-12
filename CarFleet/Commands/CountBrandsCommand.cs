using System;

namespace CarFleet
{
    class CountBrandsCommand: ICommand
    {
        private CarFleet _fleet;


        public CountBrandsCommand()
        {
            this._fleet = CarFleet.GetFleet();
        }


        public void Execute()
        {
            Console.WriteLine(_fleet.CountBrands());
        }
    }
}