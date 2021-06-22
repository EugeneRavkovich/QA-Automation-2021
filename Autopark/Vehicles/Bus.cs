namespace Homework_4
{
    class Bus: Vehicle
    {
        public string RouteNumber { get; set; }


        public Bus(double engineCapacity, string transmissionType, int maxSpeed, string routeNumber)
            : base(engineCapacity, transmissionType, maxSpeed) 
        {
            this.RouteNumber = routeNumber;
        }


        public override string GetFullInfo()
        {
            return "VehicleType: bus, " + base.GetFullInfo();
        }
    }
}
