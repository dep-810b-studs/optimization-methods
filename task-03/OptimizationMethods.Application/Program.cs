using System;
using OptimizationMethods.Core;

namespace OptimizationMethods.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new double[] { 1.1456, 0.6852 , 0.1557, 1.0539, -0.4468, 0.804, -1.0779, -0.5423, -0.5321 };
                                  //a11    a12     a13     a22     a23      a33      a14     a24        a34
            var x0 = new double[] { 2000, 2000, 2000 };
            double epsilon = 0.000001;

            var f = new Function(a,x0,epsilon);

            var pointsSpusk = f.MethodFastestSpusk();
            var pointsNewton = f.MethodNewton();
            var pointsGradient = f.MethodGradienov();

            Console.WriteLine("Метод наискорейшего спуска : ");
            Console.WriteLine($"<{pointsSpusk[0]}, {pointsSpusk[1]}, {pointsSpusk[2]}>");
            Console.WriteLine($"F={f.Calculate(pointsNewton[0], pointsNewton[1], pointsNewton[2])}");

            Console.WriteLine("Метод  Ньютона : ");
            Console.WriteLine($"<{pointsNewton[0]}, {pointsNewton[1]}, {pointsNewton[2]}>");
            Console.WriteLine($"F={f.Calculate(pointsNewton[0], pointsNewton[1], pointsNewton[2])}");

            Console.WriteLine("Метод сопряженных градиентов : ");
            Console.WriteLine($"<{pointsGradient[0]}, {pointsGradient[1]}, {pointsGradient[2]}>");
            Console.WriteLine($"F={f.Calculate(pointsGradient[0], pointsGradient[1], pointsGradient[2])}");
        }
    }
}
