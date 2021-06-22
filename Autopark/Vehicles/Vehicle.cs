namespace Homework_4
{
    abstract class Vehicle
    {
        public double EngineCapacity { get; set; }
        public string TransmissionType { get; set; }
        public int MaxSpeed { get; set; }


        public Vehicle(double engineCapacity, string transmissionType, int maxSpeed)
        {
            this.EngineCapacity = engineCapacity;
            this.TransmissionType = transmissionType;
            this.MaxSpeed = maxSpeed;
        }


        public virtual string GetFullInfo() 
        {
            return $"EngineCapacity: {EngineCapacity} l., TransmissionType:" +
                   $" {TransmissionType}, MaxSpeed: {MaxSpeed} km/h";
        }
    } 
}
