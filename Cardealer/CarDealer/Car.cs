namespace Cardealer
{
    public class Car
    {
        public Brand Brand { get; private set; }
        public string Model { get; private set; }
        public BodyType BodyType { get; private set; }
        public EngineType EngineType { get; private set; }
        public double EngineCapacity { get; private set; }
        public double Price { get; private set; }


        public Car(Brand brand, string model, BodyType bodyType, EngineType engineType,
                   double engineCapacity, double price) 
        {
            this.Brand = brand;
            this.Model = model;
            this.BodyType = bodyType;
            this.EngineType = engineType;
            this.EngineCapacity = engineCapacity;
            this.Price = price;
        }
    }
}
