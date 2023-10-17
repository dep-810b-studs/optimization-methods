//
// Created by v.sherbakov on 25.02.2020.
//

#include <cmath>
#include "GradientSpusk.h"

double gradient_spusk::f(double x, double y)
{
    return std::pow(x,4) + std::pow(y,4) + 2 * std::pow(x,2) * std::pow(y,2) - 4 * x  + 3;
}

double gradient_spusk::dfdx(double x, double y)
{
    return 4 * std::pow(x,3)  + 4 * x * std::pow(y,2) - 4;
}

double gradient_spusk::dfdy(double x, double y)
{
    return 4 * std::pow(y,3) + 4 * y * std::pow(x,2);
}

vector gradient_spusk::step(vector operand)
{
    double k = 0.05;

    vector result;

    result.x = operand.x - k * gradient_spusk::dfdx(operand.x,operand.y);
    result.y = operand.y -  k * gradient_spusk::dfdy(operand.x,operand.y);

    return result;
}

double gradient_spusk::norma(vector right_vector, vector left_vector)
{
    vector diff_vector;
    diff_vector.x = right_vector.x - left_vector.x;
    diff_vector.y = right_vector.y - left_vector.y;
    return sqrt(pow(diff_vector.x,2) + pow(diff_vector.y,2));
}