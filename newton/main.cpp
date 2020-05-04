#include <iostream>
#include <cmath>
using namespace std;

#define eps 0.0001

double f(double x, double y)
{
    return x - cos(y) - 1;
}

double g(double x, double y)
{
    return y - log10(x +1) - 3;
}

double df_dx(double x, double y)
{
    return 1;
}

double df_dy(double x, double y)
{
    return sin(y);
}

double dg_dx(double x, double y)
{
    return - 1 / ((x + 1) * log(10));
}

double dg_dy(double x, double y)
{
    return 1;
}

void ober_matr(double a[2][2])
{
    double det, aa;
    det = a[0][0]*a[1][1] - a[0][1]*a[1][0];
    aa = a[0][0];
    a[0][0] = a[1][1]/det;
    a[1][1] = aa/det;
    aa = a[0][1];
    a[0][1] = -a[1][0]/det;
    a[1][0] = -aa/det;
}

void nuton(double x, double y)
{
    int i = 1;
    double a[2][2], dx, dy, b[2], norm;
    do
    {
        a[0][0] = df_dx(x, y);
        a[0][1] = df_dy(x, y);
        a[1][0] = dg_dx(x, y);
        a[1][1] = dg_dy(x, y);
        ober_matr(a);
        dx = -a[0][0]*f(x, y) + -a[0][1]*g(x, y);
        dy = -a[1][0]*f(x, y) + -a[1][1]*g(x, y);
        x = x + dx;
        y = y + dy;
        b[0] = df_dx(x, y);
        b[1] = df_dy(x, y);
        norm = sqrt(b[0]*b[0]+b[1]*b[1]);
        i++;
    }
    while (norm >= eps && i < 10000);
    cout << x << endl << y << endl;
}
int main()
{
    double x = 0.00943991, y = 3.00408;
    cout << round(f (x,y)) << endl;
    cout << round(g (x,y)) << endl;
    nuton(x,y);
    cout << endl;
    system("PAUSE");

    return 0;
}