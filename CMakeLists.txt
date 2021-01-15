cmake_minimum_required(VERSION 3.1)

# Set project name
project(mandelbrot_viewer)

# Add executable
add_executable(${CMAKE_PROJECT_NAME} src/main.cpp src/glad.c)

## Adding OpenGL
find_package(OpenGL REQUIRED)

## Including header files
target_include_directories(${CMAKE_PROJECT_NAME} PUBLIC include)

## Adding GLFW
set(GLFW_BUILD_DOCS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_TESTS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_EXAMPLES OFF CACHE BOOL "" FORCE)
add_subdirectory(${PROJECT_SOURCE_DIR}/lib/glfw)

target_link_libraries(${CMAKE_PROJECT_NAME} PUBLIC glfw OpenGL::GL)
