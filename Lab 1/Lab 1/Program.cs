using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shape {
    public abstract class ThreeDShape {
        private String type;
      
        // Read-Only property
        public String Type {
            get {
                return type;
            }
        }

        public ThreeDShape(String type) {
            this.type = type;
        }

        public abstract double CalculateVolume();

        public override string ToString() {
            return "This is a " + Type + " shape";
        }
    }

    public class Sphere : ThreeDShape {
        private double radius;

        public Sphere(double radius)
            : base("Sphere") {
            this.radius = radius;
        }

        public Sphere()
            : this(0) {
        }

        // Read - Write property
        public double Radius {
            get {
                return radius;
            }
            set {
                if (value >= 0) {
                    radius = value;
                }
                else {
                    throw new ApplicationException
                        ("Radius must be positive");
                }
            }
        }

        public override double CalculateVolume() {
            return Math.PI * radius * radius * radius;
        }

        public override String ToString() {
            return base.ToString() + " of radius: "
                + radius.ToString();
        }

    }
    public class Test {
        public static void Main() {
            ThreeDShape[] collection = { new Sphere(),
                                               new Sphere(10)
                                             };

            foreach (ThreeDShape s in collection) {
                Console.WriteLine(s + " volume: " + s.CalculateVolume());
            }
           // Console.ReadKey();
        }
    }
    
}
