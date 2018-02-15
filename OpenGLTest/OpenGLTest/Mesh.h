#pragma once

#include <glm\glm.hpp>
#include <GLEW\GL\glew.h>

using namespace glm;

class Vertex {
	// VARIABLES
public:
	Vertex(const vec3& pos) {
		this->pos = pos;
	}
protected:
private:
	vec3 pos;
};

class Mesh {
	// FUNCTIONS
public:
	Mesh(Vertex* vertices, unsigned int numVertices);
	virtual ~Mesh();

	void Draw();

private:
	Mesh(const Mesh& other);
	Mesh& operator=(const Mesh& other);

	// ENUMERATIONS

	enum {
		POSITION_VB,

		NUM_BUFFERS
	};

	// VARIABLES
private:
	GLuint m_vertexArrayObject;
	GLuint m_vertexArrayBuffers[NUM_BUFFERS];
	unsigned int m_drawCount;
};

