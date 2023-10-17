namespace OptimizationMethods.Core
{
    public class Function
    {
        #region Исходные данные задачи
        private double[] a;
        private double epsilon;
        private double[] x0;
        #endregion

        #region Конструктор
        public Function(double[] a, double[] x0, double epsilon)
        {
            this.a = a.Clone() as double[];
            this.x0 = x0.Clone() as double[];
            this.epsilon = epsilon;
        }
        #endregion
        
        #region Исходная функция
        public double Calculate(double x1, double x2, double x3) =>
            a[0] * x1 * x1 + 2 * a[1] * x1 * x2 + 2 * a[2] * x1 * x3 + a[3] * x2 * x2 + 2 * a[4] * x2 * x3 + a[5] * x3 * x3 +
                   2 * a[6] * x1 + 2 * a[7] * x2 + 2 * a[8] * x3;
#endregion

        #region  Частные производные
        private double dFdx1(double[] x) =>
            2 * a[0] * x[0] + 2 * a[1] * x[1] + 2 * a[2] * x[2] + 2 * a[6];
        private double dFdx1dx1(double[] x) =>
            2 * a[0];
        private double dFdx1dx2(double[] x) =>
             2 * a[1];
        private double dFdx1dx3(double[] x) =>
            2 * a[2];
        private double[] Jacobi(double[] x) =>
            new double[] { -dFdx1(x), -dFdx2(x), -dFdx3(x) };
        private double dFdx2(double[] x) =>
            2 * a[1] * x[0] + 2 * a[3] * x[1] + 2 * a[4] * x[2] + 2 * a[7];
        private double dFdx2dx2(double[] x) =>
            2 * a[3];
        private double dFdx2dx3(double[] x) =>
            2 * a[4];
        private double dFdx3(double[] x) =>
            2 * a[2] * x[0] + 2 * a[4] * x[1] + 2 * a[5] * x[2] + 2 * a[8];
        private double dFdx3dx3(double[] x) =>
            2 * a[5];
        #endregion

        #region Методы

        public double[] MethodFastestSpusk()
        {
            if (x0.Length > 3) throw new ArgumentException();

            var res_x = x0.Clone() as double[];

            int numberIteration = 0;

            while (true)
            {
                var ak = CountAlpha(res_x, Jacobi(res_x));

                var nx1 = res_x[0] - ak * dFdx1(res_x);
                var nx2 = res_x[1] - ak * dFdx2(res_x);
                var nx3 = res_x[2] - ak * dFdx3(res_x);

                numberIteration++;

                if(Math.Sqrt(Math.Pow(res_x[0] - nx1, 2) + Math.Pow(res_x[1] - nx2, 2) + Math.Pow(res_x[2] - nx3, 2)) < epsilon)
                {
                    break;
                }

                res_x[0] = nx1;
                res_x[1] = nx2;
                res_x[2] = nx3;
            }

            Console.WriteLine($"Число итераций : {numberIteration}");

            return res_x;
        }

        public double[] MethodNewton()
        {
            var res_x = x0.Clone() as double[];
            
            for (int i = 0; i != 1; i++)
            {
                var multiplying = MethodNewtonSubFunction(res_x, Jacobi(res_x)); 
                Parallel.For(0, 3, (j) => res_x[j] -= multiplying[j]);
            }

            return res_x;
        }

        public double[] MethodGradienov()
        {
            var h0 = Jacobi(x0);
            var res_x = x0.Clone() as double[];
            var a = CountAlpha(x0, h0);

            for (int i = 0; i < 3; i++)
            {
               var x1 = new double[] { res_x[0] + a * h0[0], res_x[1] + a * h0[1], res_x[2] + a * h0[2]};
               h0 = CountH(res_x, x1, h0);
               res_x = x1.Clone() as double[];
               a = CountAlpha(x0, h0);
            }

            return res_x;
        }

        #endregion

        #region Вспомогательные методы
        private double CountAlpha (double [] x, double [] h)
        {
             var f2 = new double[3, 3]
            {
                { dFdx1dx1(x), dFdx1dx2(x), dFdx1dx3(x)},
                { dFdx1dx2(x), dFdx2dx2(x), dFdx2dx3(x)},
                { dFdx1dx3(x), dFdx2dx3(x), dFdx3dx3(x)}
            };

            var h_copy = h.Clone() as double[];
            var res = new double[3];

            Parallel.For(0, 3, (i) =>
             Parallel.For(0, 3, (j) => 
              {
                res[i] += h_copy[j] * f2[i, j];
              }));

            return -(dFdx1(x) * h[0] + dFdx2(x) * h[1] + dFdx3(x) * h[2])
                  / (h[0] * res[0] + h[1] * res[1] + h[2] * res[2]);
        }

        private double[] MethodNewtonSubFunction(double[] x, double[] h)
        {
            var res = new double[3];

            var inverseJacobi = new double[3, 3]
            {
                { dFdx1dx1(x), dFdx1dx2(x), dFdx1dx3(x)},
                { dFdx1dx2(x), dFdx2dx2(x), dFdx2dx3(x)},
                { dFdx1dx3(x), dFdx2dx3(x), dFdx3dx3(x)}
            }.Inverse();

            Parallel.For(0, 3, (i) =>
             Parallel.For(0, 3, (j) =>
             {
                 res[i] += -h[j] * inverseJacobi[i, j];
             }));

            return res;
        }

        public double[] CountH(double [] x0, double[] x1, double[] h)
        {
            var res = new double[3] { -dFdx1(x1), -dFdx2(x1), -dFdx3(x1) };
            double coef = (dFdx1(x1) * dFdx1(x1) + dFdx2(x1) * dFdx2(x1) + dFdx3(x1) * dFdx3(x1))
                / (dFdx1(x0) * dFdx1(x0) + dFdx2(x0) * dFdx2(x0) + dFdx3(x0) * dFdx3(x0));
            Parallel.ForEach(Enumerable.Range(0, 3), (i) => res[i] += h[i] * coef);
            return res;
        }

        #endregion
    }
}
