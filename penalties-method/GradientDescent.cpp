//
// Created by v.sherbakov on 10/05/20.
//

#include "GradientDescent.h"
#include <cmath>
#include <fstream>

double GradientDescent::f(Vector vector)
{
    return - vector.x_1 - 4 * vector.x_2 + 2 * vector.x_2 * vector.x_2 + _t_k * (- 3 * vector.x_1 - 2 * vector.x_2 - 6);
}

double GradientDescent::df_dx_1(Vector vector)
{
    return -1 - 3 * _t_k;
}

double GradientDescent::df_dx_2(Vector vector)
{
    return - 4 + 4 * vector.x_2 - 2 * _t_k;
}

double GradientDescent::norma(Vector right_vector, Vector left_vector)
{
    auto diff_vector = Vector(right_vector.x_1 - left_vector.x_1, right_vector.x_2 - left_vector.x_2);
    return sqrt(pow(diff_vector.x_1,2) + pow(diff_vector.x_2,2));
}

Vector GradientDescent::step(Vector x_i)
{
    double k = 0.05;

    Vector x_i_next;

    x_i_next.x_1 = x_i.x_1 - k * df_dx_1(x_i);
    x_i_next.x_2 = x_i.x_2 - k * df_dx_2(x_i);

    return x_i_next;
}

Vector GradientDescent::run(Vector initial_approximation)
{
    auto current_value = initial_approximation;
    auto prev_value = Vector(0.0,0.0);

    auto output_file_stream = std::ofstream("./log.txt",std::ios::out | std::ios::app);

    output_file_stream << "t_k = " << _t_k << std::endl;

    for(int i = 0; i < 10000 && norma(current_value, prev_value) > _epsilon; ++i)
    {
        prev_value = current_value;
        current_value = step(initial_approximation);

        output_file_stream << "x_1 = " << current_value.x_1 <<" x_2 = " << current_value.x_2 << std::endl;
        output_file_stream << "=== Next iteration ===" << std::endl;
    }

    output_file_stream << "finish with current t_k" << std::endl;

    return current_value;
}

