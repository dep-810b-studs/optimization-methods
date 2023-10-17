#include <iostream>
#include <math.h>
#include "GradientSpusk.h"

int main()
{
    vector value;
    vector prev_value;

    auto epsilon = 1e-5;

    value.x = -1;
    value.y = 0.1;

    for (int i = 0; i <  1000 ; ++i)
    {
        value = gradient_spusk::step(value);
        std::cout << "x = " << value.x << " " << "y = "<< value.y << std::endl;
    }

    std::cout << "x = " << value.x << " " << "y = "<< value.y << std::endl;

    return 0;
}
