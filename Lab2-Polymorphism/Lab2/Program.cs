using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism {
    public class Vertex {
        private int xcoord;
        private int ycoord;

        public Vertex(int xcoord, int ycoord) {
            this.xcoord = xcoord;
            this.ycoord = ycoord;
        }

        public int Xcoord { 
            get{
                return xcoord;
            }
            set {
                xcoord = value;
            }
        }

        public int Ycoord {
            get {
                return ycoord;
            }
            set {
                ycoord = value;
            }
        }       
    }

    public enum ShapeColor { red, green, blue }

    public abstract class Shape {
        private ShapeColor color;

        public Shape(ShapeColor color) {
            this.color = color;
        }

        public ShapeColor Color {
            get {
                return color;
            }
            set {
                color = value;
            }
        }

        public override string ToString() {
            return "Color: " + color;
        }

        public abstract void Translate(Vertex v);
    }

    public class Line : Shape {
        private Vertex v1, v2;

        public Line(int x1, int y1, int x2, int y2, ShapeColor c)
            :base(c) {
                this.v1 = new Vertex(x1, y1);
                this.v2 = new Vertex(x2, y2);
        }

        public int V1xcoord { 
            get {
                return v1.Xcoord;            
            } 
            set {
                v1.Xcoord = value;
            }
        }
        public int V1ycoord {
            get {
                return v1.Ycoord;
            }
            set {
                v1.Ycoord = value;
            }
        }
        public int V2xcoord {
            get {
                return v2.Xcoord;
            }
            set {
                v2.Xcoord = value;
            }
        }
        public int V2ycoord {
            get {
                return v2.Ycoord;
            }
            set {
                v2.Ycoord = value;
            }
        }

        public override string ToString() {
            return base.ToString() 
                + " X1: " + V1xcoord
                + " Y1: " + V1ycoord 
                + " X2: " + V2xcoord 
                + " Y2: " + V2ycoord;
        }

        public override void Translate(Vertex v) {
            v1.Xcoord += v.Xcoord;
            v1.Ycoord += v.Ycoord;
            v2.Xcoord += v.Xcoord;
            v2.Ycoord += v.Ycoord;
        }
    }

    public class Circle : Shape {
        private int radius;
        private Vertex v;

        public Circle(int x, int y, int r, ShapeColor c) 
            : base(c) {
                this.v = new Vertex(x, y);
                this.radius = r;
        }

        public int Radius {
            get {
                return radius;
            }
            set {
                radius = value;
            }
        }

        public int xcoord {
            get {
                return v.Xcoord;
            }
            set {
                v.Xcoord = value;
            }
        }
        public int ycoord {
            get {
                return v.Ycoord;
            }
            set {
                v.Ycoord = value;
            }
        }

        public override string ToString() {
            return base.ToString() 
                + " X1: " + xcoord
                + " Y1: " + ycoord
                + " Radius: " + radius
                + " Area: " + area();
        }

        public override void Translate(Vertex v) {
            v.Xcoord += v.Xcoord;
            v.Ycoord += v.Ycoord;
        }

        public virtual double area() {
            return Math.PI * radius * radius;
        }

    }

    public class Test {
        public static void Main() {

            Shape[] shapes = {new Line(3,4,4,3, ShapeColor.red),
                                 new Circle(3,3,6,ShapeColor.blue)};

            foreach (Shape s in shapes) {
                Console.WriteLine("Before: " + s);
                s.Translate(new Vertex (5, 5));
                Console.WriteLine("After: " + s);
                Console.WriteLine("* * * *");
            }
            
            Console.ReadKey();
        }
    }
}
