cmake_minimum_required(VERSION 3.15)
project(penalties_method)

set(CMAKE_CXX_STANDARD 20)

add_executable(penalties_method main.cpp  GradientDescent.cpp GradientDescent.h Vector.h)