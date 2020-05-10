#include <iostream>
#include "GradientDescent.h"

int main()
{

    auto func_min = Vector();
    double func_value;

    for (double t_k = 100; t_k > 0 ; t_k-= 0.01)
    {
        auto gradient_descent = GradientDescent(t_k);
        auto initial_approximation = Vector(1.0,1.0);
        auto current_min = gradient_descent.run(initial_approximation);

        if(gradient_descent.f(current_min) < gradient_descent.f(func_min))
        {
            func_min = current_min;
            func_value = gradient_descent.f(func_min);
        }
    }

    std::cout << "x_1 = " << func_min.x_1 << "x_2 = " << func_min.x_2 << std::endl;
    std::cout << "f(x_1,x_2) = " << func_value << std::endl;

    return 0;
}
