#include <iostream>
#include <math.h>

struct Vector_st{
    double x1;
    double x2;

    Vector_st(){
        x1 = 0;
        x2 = 0;
    };

    Vector_st(double _x1, double _x2){
        x1 = _x1;
        x2 = _x2;
    };

    Vector_st(const Vector_st & vectorIn){
        x1 = vectorIn.x1;
        x2 = vectorIn.x2;
    }



};

Vector_st findDerivative(const Vector_st & vec, const double & tk){

    //return Vector_st(8*vec.x1-40, 12*vec.x2-72);
    return Vector_st(-1+tk*2*(-3*vec.x1+-2*vec.x2-6)*2,-4+4*vec.x2*tk*2*(-3*vec.x1+-2*vec.x2-6)*3);
    //return Vector_st(2*vec.x1, 2*vec.x2);

}

double S_x(const Vector_st & vec){

    return (3*vec.x1+2*vec.x2-6)*(3*vec.x1+2*vec.x2-6);
}


double F(const Vector_st & vec, const double & tk){

    //return 4*(vec.x1-5)*(vec.x1-5)+6*(vec.x2-6)*(vec.x2-6);
    return -1*(vec.x1+4*vec.x2-2*vec.x2*vec.x2)+tk*S_x(vec);
    //return(vec.x1*vec.x1+vec.x2*vec.x2);
}
Vector_st operator *(const double & number, const Vector_st & vector ){
    return Vector_st(number* vector.x1,number * vector.x2);
};

Vector_st operator -(const Vector_st & vecLeft, const Vector_st & vecRight ){
    return Vector_st(vecLeft.x1 - vecRight.x1, vecLeft.x2 - vecRight.x2);
};

Vector_st Gradient_descent_optimizator(
        const Vector_st & startPoint,
        const int & stepLimit,
        const double & oneStep,
        const double & residue,
        const double & tk){

    int count = 0;
    Vector_st nextVec;
    Vector_st sP = startPoint;
    double resTemp = 0;
    while(count<stepLimit){


        nextVec =  sP - (oneStep*findDerivative(sP,tk));
        resTemp =  abs(F(sP,tk)-F(nextVec,tk));

        if(resTemp<=residue){
            break;
        }
        else{
            sP = nextVec;
        }

        ++count;
    }
    if (count<stepLimit){
        std::cout<<"Solution found with residue:  "<<resTemp<<std::endl;
        return nextVec;
    }
    else{

        std::cout<<"Maximum step limit reached. No solution found"<<std::endl;
        return Vector_st(0,0);
    }

}


int main() {
    //start params


    double epsilon = 1e-3;
    Vector_st cur(-3.05,-3.05);
    double delimeter = 1.1;
    double tk = 5.05;
    int step = 0;

    do{
        std::cout<<"Step "<<step<<std::endl;
        std::cout<<"Graient descent input: "<<"X1 : "<<cur.x1<<"  X2 : "<<cur.x2<<std::endl;
        cur = Gradient_descent_optimizator(
                cur,
                1000,
                0.001,
                1e-3,
                tk);
        std::cout<<"Graient descent result: "<<"X1 : "<<cur.x1<<"  X2 : "<<cur.x2<<std::endl;
        std::cout<<"S(x) = "<<S_x(cur)<<std::endl<<"Delimeter = "<<tk<<std::endl;
        tk*=delimeter;
        step++;
    }
    while(S_x(cur)>=epsilon);

    std::cout<<"Final result: "<< "X1 = "<<cur.x1<<"X2 = "<<cur.x2<<" with residue = "<<S_x(cur)<<std::endl;
    return 0;
}
