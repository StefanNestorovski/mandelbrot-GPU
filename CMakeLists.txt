cmake_minimum_required(VERSION 3.1)

# Set project name
project(mandelbrot_viewer)

set(GLFW_BUILD_EXAMPLES OFF CACHE INTERNAL "Build the GLFW example programs")
set(GLFW_BUILD_TESTS OFF CACHE INTERNAL "Build the GLFW test programs")
set(GLFW_BUILD_DOCS OFF CACHE INTERNAL "Build the GLFW documentation")
set(GLFW_INSTALL OFF CACHE INTERNAL "Generate installation target")

# Add executable
add_executable(${CMAKE_PROJECT_NAME} src/main.cpp src/glad.c)

## Adding OpenGL
find_package(OpenGL REQUIRED)
target_link_libraries(${CMAKE_PROJECT_NAME} PUBLIC OpenGL::GL)

## Including header files
target_include_directories(${CMAKE_PROJECT_NAME} PUBLIC include)

## Adding GLFW
add_subdirectory(lib/glfw)
include_directories(${PROJECT_SOURCE_DIR}/lib/glfw)
