using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4 {
    public class Calculator {
        public static double Divide(double lhs, double rhs) {
            if (rhs == 0){
                throw new ArgumentException("Error, cannot divide by zero");
            }
            else {
                return lhs / rhs; 
            }
        }
    }
    class Test {
        public static void Main() {
            double num1, num2;
            
            Console.WriteLine("Enter first numbers: ");
            num1 = Double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second numbers: ");
            num2 = Double.Parse(Console.ReadLine());

            Console.WriteLine(Calculator.Divide(num1, num2));

            Console.WriteLine();
        }
    }
}
