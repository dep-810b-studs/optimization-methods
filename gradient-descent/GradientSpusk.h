//
// Created by v.sherbakov on 25.02.2020.
//

#ifndef UNTITLED_GRADIENTSPUSK_H
#define UNTITLED_GRADIENTSPUSK_H

struct vector
{
    double x;
    double y;
};

class gradient_spusk
{

    public:
    static double f(double, double);
    static double dfdx(double, double);
    static double dfdy(double, double);
    static double norma(vector,vector);
    static vector step(vector);
};


#endif //UNTITLED_GRADIENTSPUSK_H
