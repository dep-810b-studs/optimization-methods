﻿using System.Numerics;

namespace OptimizationMethods.Core
{
    public class GradientDescentOptimizer
    {
        public static Vector2 Run(Vector2 startPoint, int stepLimit, double oneStep, double residue, double tk)
        {
            int count = 0;
            Vector2 nextVec = startPoint;
            Vector2 sP = startPoint;
            double resTemp = 0;

            while (count < stepLimit)
            {
                nextVec = sP - Function2.df(sP, tk).Multiply(oneStep);
                resTemp = Math.Abs(Function2.F(sP, tk)-Function2.F(nextVec,tk));
                if (resTemp <= residue)
                    break;
                sP = nextVec;
                ++count;
            }

            if (count < stepLimit)
            {
                Console.WriteLine($"Solution found with residue: {resTemp}");
                return nextVec;
            }
            else
            {
                Console.WriteLine("Maximum step limit reached. No solution found");
                return new Vector2(0,0);
            }
            
        }
    }
}