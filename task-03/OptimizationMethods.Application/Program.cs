//Main file

using System;
using System.Numerics;

namespace task_03
{
    class Program
    {
        private const double EPSILON = 1e-3;
        
        static void Main(string[] args)
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
                Console.WriteLine($"S(x) = {Function.S_x(cur)} Delimiter = {tk}");
                tk *= delimeter;
                step++;
            } while (Function.S_x(cur) >= EPSILON);
            
            Console.WriteLine($"Final result: X1 = {cur.X} X2 = {cur.Y} with residue = {Function.S_x(cur)}");
            Console.WriteLine($"F(x) = {Function.f(cur)}");

            var resultValid = Math.Abs(Math.Round(Function.S_x(cur))) == 0 ? 
                ValidationStatus.VALID:
                ValidationStatus.INVALID; 
            
            Console.WriteLine($"Result is {resultValid}");
        }
    }
}
