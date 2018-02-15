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
	Texture(const Texture & other) {}
	Texture& operator=(const Texture& other) {}

	// VARIABLES

private:
	GLuint m_texture;
};

