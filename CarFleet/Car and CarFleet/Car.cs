using System;

namespace CarFleet
{
    /// <summary>
    /// Class that defines a car object
    /// </summary>
    class Car
    {
        /// <summary>
        /// The number of cars of this brand and model being added
        /// </summary>
        private int _quantity;

        /// <summary>
        /// Price of one car
        /// </summary>
        private int _price;

        /// <summary>
        /// Car brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Car model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Method for setting and getting the _quantity field value
        /// </summary>
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

        /// <summary>
        /// Method for setting and getting the _price field value
        /// </summary>
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


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="brand">Car brand</param>
        /// <param name="model">Car model</param>
        /// <param name="quantity">The number of cars</param>
        /// <param name="price">Price of one car</param>
        public Car(string brand, string model, int quantity, int price)
        {
            this.Brand = brand;
            this.Model = model;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}