using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace OptimizationMethods.Core
{
    public static class Extensions
    {
        public static Vector2 Multiply(this Vector2 vector2, double mult)=>
            new Vector2((float)(vector2.X * mult),(float)(vector2.Y * mult));
        
        public static double[,] Inverse(this double[,] arr) =>
            Matrix<double>.Build.DenseOfArray(arr).Inverse().ToArray();
    }
}