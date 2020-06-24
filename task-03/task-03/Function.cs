using System;
using System.Numerics;

namespace task_03
{
    public class Function
    {
        public static Func<Vector2, double> f = vector => 
            vector.X + 4 * vector.Y - 2 * Math.Pow(vector.Y,2);

        private static double dS_xdx = -3; 
        private static double dS_xdy = -2;
        private static double dFdx = -1;

        private static double dFdy(double x) =>
            -4 + 4 * x;

        public static Vector2 df(Vector2 vector2, double tk)
        {
            var dx = dFdx + tk * 2 * S_x(vector2) * dS_xdx;
            var dy = dFdy(vector2.Y) + tk * 2 * S_x(vector2) * dS_xdy;
            return new Vector2((float)dx,(float)dy);
        }

        public static double S_x(Vector2 vector2)=>
                -3*vector2.X-2*vector2.Y-6;
        
        public static double F(Vector2 vector2, double tk)=>
                -1 * f(vector2) + tk * Math.Pow(S_x(vector2),2);
    }
}