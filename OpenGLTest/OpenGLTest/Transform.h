#pragma once

#include <glm\glm.hpp>
#define GLM_ENABLE_EXPERIMENTAL 
#include <glm\gtx\transform.hpp>

using namespace glm;

class Transform {
	// FUNCTIONS
public:
	Transform(const vec3& pos = vec3(), const vec3& rot = vec3(), const vec3& scale = vec3(1.0, 1.0, 1.0)) {
		m_position = pos;
		m_rotation = rot;
		m_scale = scale;
	}

	inline mat4 GetModel() const {
		mat4 positionMatrix = translate(m_position);
		mat4 rotationXMatrix = rotate(m_rotation.x, vec3(1, 0, 0));
		mat4 rotationYMatrix = rotate(m_rotation.y, vec3(0, 1, 0));
		mat4 rotationZMatrix = rotate(m_rotation.z, vec3(0, 0, 1));
		mat4 scaleMatrix = scale(m_scale);

		mat4 rotationMatrix = rotationZMatrix * rotationYMatrix * rotationXMatrix;

		return positionMatrix * rotationMatrix * scaleMatrix;
	}

	inline vec3& GetPosition() { return m_position; }
	inline vec3& GetRotation() { return m_rotation; }
	inline vec3& GetScale() { return m_scale; }

	inline void SetPosition(const vec3& pos) { m_position = pos; }
	inline void SetRotation(const vec3& rot) { m_rotation = rot; }
	inline void SetScale(const vec3& scale) { m_scale = scale; }

	// VARIABLES
private:
	vec3 m_position;
	vec3 m_rotation;
	vec3 m_scale;
};

