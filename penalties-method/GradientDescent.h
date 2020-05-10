//
// Created by v.sherbakov on 10/05/20.
//

#ifndef PENALTIES_METHOD_GRADIENTDESCENT_H
#define PENALTIES_METHOD_GRADIENTDESCENT_H

#include <functional>
#include "Vector.h"

class GradientDescent
{
    private:
        double const _epsilon = 10e-5;
        double _t_k;
        double df_dx_1(Vector);
        double df_dx_2(Vector);
        double norma(Vector,Vector);
        Vector step(Vector);
    public:
        GradientDescent(double t_k) : _t_k(t_k){};
        Vector run(Vector);
        double f(Vector);

};


#endif //PENALTIES_METHOD_GRADIENTDESCENT_H
