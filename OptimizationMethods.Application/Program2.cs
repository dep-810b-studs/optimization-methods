using System;
using System.Numerics;
using OptimizationMethods.Core;

namespace OptimizationMethods.Application
{
    class Program2
    {
        private const double EPSILON = 1e-3;
        
        static void Main2(string[] args)
        {
            Vector2 cur = new Vector2(-5, 0);
            double delimeter = 1.1;
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
    }
}
