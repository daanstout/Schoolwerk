#pragma once
#include <string>
#include <GLEW\GL\glew.h>

using namespace std;

class Texture {
	// FUNCTIONS
public:
	Texture(const string& fileName);
	virtual ~Texture();

	void Bind(unsigned int unit);

private:

	// VARIABLES

private:
	GLuint m_texture;
};

