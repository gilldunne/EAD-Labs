using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shape {

    public interface IHasVolume {
        // Automatically public and abstract
        double CalcVolume();
    }

    // Sphere implementing IHasVolume class
    public class Sphere : Object, IHasVolume { 
        private double radius;

        public double Radius {
            get {
                return radius;
            }
            set {
                radius = value;
            }
        }

        public Sphere(double r) {
            Radius = r;
        }

        public Sphere()
            : this(0) {

        }
        public virtual double CalcVolume() {
            return 3.14 * radius * radius * radius;
        }

        public override String ToString() {
            return "Sphere of radius: "
                + radius.ToString();
        }
    }
}
