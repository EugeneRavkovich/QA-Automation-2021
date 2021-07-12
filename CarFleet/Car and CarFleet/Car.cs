using System;

namespace CarFleet
{
    class Car
    {
        private int _quantity;

        private int _price;

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of cars can't be negative");
                }
                _quantity = value;
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price can't be negative");
                }
                _price = value;
            }
        }


        public Car(string brand, string model, int quantity, int price)
        {
            this.Brand = brand;
            this.Model = model;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}