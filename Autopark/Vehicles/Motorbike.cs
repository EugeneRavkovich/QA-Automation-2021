namespace Homework_4
{
    class Motorbike: Vehicle
    {
        public string ManufacturerCompany { get; set; }


        public Motorbike(double engineCapacity, string transmissionType, int maxSpeed, string manufacturerCompany)
            : base(engineCapacity, transmissionType, maxSpeed)
        {
            this.ManufacturerCompany = manufacturerCompany;
        }


        public override string GetFullInfo()
        {
            return "VehicleType: motorbike, " + base.GetFullInfo();
        }
    }
}
