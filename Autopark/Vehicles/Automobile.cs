namespace Homework_4
{
    class Automobile: Vehicle
    {
        public int NumberOfPassengers { get; set; }


        public Automobile(double engineCapacity, string transmissionType, int maxSpeed, int numberOfPassengers)
            : base(engineCapacity, transmissionType, maxSpeed)
        {
            this.NumberOfPassengers = numberOfPassengers;
        }


        public override string GetFullInfo() 
        {
            return "VehicleType: automobile, " + base.GetFullInfo();
        }
    }
}
