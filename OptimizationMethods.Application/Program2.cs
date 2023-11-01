using System;
using System.Numerics;
using OptimizationMethods.Core;

namespace OptimizationMethods.Application
{
    class Program2
    {
        private const double EPSILON = 1e-3;
        
        public static void Main2(string[] args)
        {
            Vector2 cur = new Vector2(-5, 0);
            double delimeter =  1.1;
            double tk = 0.1;
            int step = 0;

            do
            {
                Console.WriteLine($"Step {step}");
                Console.WriteLine($"Gradient descent input: X1 = {cur.X} X2 = {cur.Y}");
                cur = GradientDescentOptimizer.Run(cur, 1000, 1e-3, 1e-3, tk);
                Console.WriteLine($"Gradient descent result: X1 = {cur.X} X2 = {cur.Y}");
                Console.WriteLine($"S(x) = {Function2.S_x(cur)} Delimiter = {tk}");
                tk *= delimeter;
                step++;
            } while (Function2.S_x(cur) >= EPSILON);
            
            Console.WriteLine($"Final result: X1 = {cur.X} X2 = {cur.Y} with residue = {Function2.S_x(cur)}");
            Console.WriteLine($"F(x) = {Function2.f(cur)}");

            var resultValid = Math.Abs(Math.Round(Function2.S_x(cur))) == 0 ? 
                ValidationStatus.VALID:
                ValidationStatus.INVALID; 
            
            Console.WriteLine($"Result is {resultValid}");
        }
        
        
        private static void Solve()
        {
            /*
             * cliArgs = ParseArgs(args);
             * ValidateFile(cliArgs.InputFileName);
             * inputStream = File.Open(cliArgs.InputFileName);
             * mathFunction = MathFunction.FromStream(inputStream);
             * optimizers
             *  .Select(optimizer => (optimizer.Kind, optimizer.Optimize(mathFunction))
             *  .ForEach(result => (result.optimizer.Kind, mathFunction(result.Value)));
             *
             */
            
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
