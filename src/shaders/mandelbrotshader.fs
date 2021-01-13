#version 330 core
#extension GL_ARB_gpu_shader_fp64 : enable

precision highp float;

uniform vec2 screenRes;
uniform float centerLocationX;
uniform float centerLocationY;
uniform float centerLocationXfine;
uniform float centerLocationYfine;
uniform float zoom;
uniform int max_iterations;

in vec3 pos;

out vec4 FragColor;

vec3 colour(float amount);

void main() {
	int iteration = 0;
	
	double x0 = ((double(gl_FragCoord.x)/double(screenRes.x))*2 - 1)/double(zoom) + double(double(centerLocationX) + double(centerLocationXfine));
	double y0 = ((double(gl_FragCoord.y)/double(screenRes.y))*2 - 1)/double(zoom) + double(double(centerLocationY) + double(centerLocationYfine));
	double x = x0;
	double y = y0;

	while(x*x + y*y <= 4 && iteration < max_iterations) {
		double x_t = x*x - y*y + x0;
		y = 2*x*y + y0;
		x = x_t;
		iteration++;
	}

	vec3 col = colour(float(iteration) / float(max_iterations));
	FragColor = vec4(col, 1.0);
}

vec3 colour(float amount) {
	const float[] positions = {
		0.0,
		0.16,
		0.42,
		0.6425,
		0.8425,
		1.0001
	};
	const vec3[] colours = {
		vec3(0,   0, 0),
		vec3(0,   7, 100),
		vec3(32, 107, 203),
		vec3(237, 255, 255),
		vec3(255, 170,   0),
		vec3(0,   2,   0)
	};
	for (int i = 0; i < 5; i++) {
		if (amount >= positions[i] && amount <= positions[i+1]) {
			float interped = (amount-positions[i])/(positions[i+1]-positions[i]);
			vec3 c = (colours[i+1] - colours[i]) * interped + colours[i];
			// RGB values are floats between [0, 1]
			return c/255;
		}
	}
	return vec3(0,0,0);
}
