#pragma once

#include <string>
#include <fstream>
#include <iostream>

#include <GLEW\GL\glew.h>

using namespace std;

class Shader {
	//FUNCTIONS
public:
	Shader(const string& filename);

	void Bind();

	virtual ~Shader();
private:
	Shader(const Shader& other) {}
	Shader& operator=(const Shader& other) {}

	//VARIABLES
private:
	static const unsigned int NUM_SHADERS = 2;

	GLuint m_program;
	GLuint m_shaders[NUM_SHADERS];
};

