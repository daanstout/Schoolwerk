#pragma once

#include <glm\glm.hpp>
#include <GLEW\GL\glew.h>

using namespace glm;
using namespace std;

class Vertex {
	// FUNCTIONS
public:
	Vertex(const vec3& pos, const vec2& texCoord) {
		this->pos = pos;
		this->texCoord = texCoord;
	}

	inline vec3* GetPos() { return &pos; }
	inline vec2* GetTexCoord() { return &texCoord; }
protected:
	// VARIABLES
private:
	vec3 pos;
	vec2 texCoord;
};

class Mesh {
	// FUNCTIONS
public:
	Mesh(Vertex* vertices, unsigned int numVertices);
	virtual ~Mesh();

	void Draw();

private:

	// ENUMERATIONS

	enum {
		POSITION_VB,
		TEXCOORD_VB,

		NUM_BUFFERS
	};

	// VARIABLES
private:
	GLuint m_vertexArrayObject;
	GLuint m_vertexArrayBuffers[NUM_BUFFERS];
	unsigned int m_drawCount;
};

