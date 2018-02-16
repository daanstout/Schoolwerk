#pragma once

#include <string>
#include <fstream>
#include <iostream>

#include <GLEW\GL\glew.h>
#include "Transform.h"
#include "Camera.h"

using namespace std;

class Shader {
	//FUNCTIONS
public:
	Shader(const string& filename);
	virtual ~Shader();

	void Bind();
	void Update(const Transform& transform, const Camera& camera);
private:

	//ENUMERATIONS

	enum {
		TRANSFORM_U,

		NUM_UNIFORMS
	};

	//VARIABLES
private:
	static const unsigned int NUM_SHADERS = 2;

	GLuint m_program;
	GLuint m_shaders[NUM_SHADERS];
	GLuint m_uniforms[NUM_UNIFORMS];
};

