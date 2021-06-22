using System.Text;
using System.Collections.Generic;

namespace Homework_4
{
    class Autopark
    {
        public List<Vehicle> Park;


        public Autopark(List<Vehicle> park) 
        {
            this.Park = park;
        }


        public string GetFullInfo() 
        {
            StringBuilder info = new StringBuilder();
            foreach (Vehicle x in Park) 
            {
                info.Append(x.GetFullInfo() + "\n");
            }
            return info.ToString();
        }
    }
}
