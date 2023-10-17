using MathNet.Numerics.LinearAlgebra;

namespace Методы_оптимизации
{
    static public class Extensions
    {
        static public double[,] Inverse(this double[,] arr) =>
             Matrix<double>.Build.DenseOfArray(arr).Inverse().ToArray();
    }
}
