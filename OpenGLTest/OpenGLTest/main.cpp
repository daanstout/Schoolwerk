#include <iostream>
#include <GLEW\GL\glew.h>
#include <cstdio>
#include <ctime>
#include "display.h"
#include "shader.h"
#include "Mesh.h"
#include "Texture.h"
#include "Transform.h"
#include "camera.h"
#undef main

#define WIDTH 800
#define HEIGHT 600

int main(int argc, char * args[]) {
	Display display(WIDTH, HEIGHT, "Hello World!");

	Shader shader("./res/basicShader");

	Vertex vertices1[] = {
		Vertex(vec3(-0.5, -0.5, 0), vec2(1.0, 1.0)),
		Vertex(vec3(-0.5, 0.5, 0), vec2(1.0, 0.0)),
		Vertex(vec3(0.5, 0.5, 0), vec2(0.0, 0.0))
	};

	Mesh mesh1(vertices1, sizeof(vertices1) / sizeof(vertices1[0]));

	Vertex vertices2[] = {
		Vertex(vec3(-0.5, -0.5, 0), vec2(1.0, 1.0)),
		Vertex(vec3(0.5, 0.5, 0), vec2(0.0, 0.0)),
		Vertex(vec3(0.5, -0.5, 0), vec2(0.0, 1.0))
	};

	Mesh mesh2(vertices2, sizeof(vertices2) / sizeof(vertices2[0]));

	Texture texture("./res/tijn.jpg");

	Camera camera(vec3(0, 0, -6), 70.0f, (float)WIDTH/(float)HEIGHT, 0.01f, 1000.0f);

	Transform transform;

	float counter = 0;

	clock_t start = clock();

	double duration;

	while (!display.IsClosed()) {
		display.Clear(0.0f, 0.15f, 0.3f, 0.1f);

		float sinCounter = sinf(counter);
		float cosCounter = cosf(counter);

		transform.GetPosition().x = sinCounter;
		transform.GetPosition().y = cosCounter;
		transform.GetPosition().z = cosCounter;
		transform.GetRotation().x = counter;
		transform.GetRotation().y = counter;
		transform.GetRotation().z = counter;
		//transform.SetScale(vec3(cosCounter, cosCounter, cosCounter));

		shader.Bind();
		shader.Update(transform, camera);
		texture.Bind(0);
		mesh1.Draw();
		mesh2.Draw();

		display.Update();

		counter += 1 * ((clock() - start) / (double) CLOCKS_PER_SEC);

		start = clock();
	}

	return 0;
}