using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9_LINQ
{
    public class Car {
        public String Make { get; set; }
        public String Model { get; set; }
        public String Registration { get; set; }
        public double EngineSize { get; set; }

        public override String ToString() {
            return "Make: " + Make + "\tModel: " + Model 
                + "\tReg: " + Registration + "\tEngine: " + EngineSize;
        }
    }
       
    class Fleet {
        public static void main {
            private List<Car> fleet = new List<Car> { ("Mazda", "121", "03D332", 1.2)};

        }
    }
}
