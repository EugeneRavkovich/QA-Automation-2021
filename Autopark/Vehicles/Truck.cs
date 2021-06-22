namespace Homework_4
{
    class Truck: Vehicle
    {
        public int Tonnage { get; set; }


        public Truck(double engineCapacity, string transmissionType, int maxSpeed, int tonnage)
            : base(engineCapacity, transmissionType, maxSpeed) 
        {
            this.Tonnage = tonnage;
        }


        public override string GetFullInfo()
        {
            return "VehicleType: truck, " + base.GetFullInfo();
        }
    }
}
