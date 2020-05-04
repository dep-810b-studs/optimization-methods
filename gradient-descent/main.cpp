#include <iostream>
#include <math.h>
#include "GradientSpusk.h"

int main()
{
    vector value;

    value.x = 0.9;
    value.y = 0.1;

    for (int i = 0; i <  1000 ; ++i)
    {
        value = gradient_spusk::step(value);

        std::cout << "x = " << value.x << " " << "y = "<< value.y << std::endl;
//        std::cout << "x = " << std::roundf(value.x) << " " << "y = "<< std::roundf(value.y) << std::endl;
    }

    std::cout << "x = " << std::roundf(value.x) << " " << "y = "<< std::roundf(value.y) << std::endl;

    return 0;
}
