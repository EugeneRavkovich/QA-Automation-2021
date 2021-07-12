namespace CarFleet
{
    class AddCommand: ICommand
    {
        private Car _car;
        private CarFleet _fleet;


        public AddCommand(Car car)
        {
            this._car = car;
            this._fleet = CarFleet.GetFleet();
        }


        public void Execute()
        {
            _fleet.Add(_car);
        }
    }
}