#include "Shader.h"

static void CheckShaderError(GLuint shader, GLuint flag, bool isProgram, const string& errorMessage);
static std::string LoadShader(const string& filename);
static GLuint CreateShader(const string& text, GLenum shaderType);

Shader::Shader(const string& filename) {
	m_program = glCreateProgram();

	m_shaders[0] = CreateShader(LoadShader(filename + ".vs"), GL_VERTEX_SHADER);
	m_shaders[1] = CreateShader(LoadShader(filename + ".fs"), GL_FRAGMENT_SHADER);

	for (unsigned int i = 0; i < NUM_SHADERS; i++)
		glAttachShader(m_program, m_shaders[i]);

	glBindAttribLocation(m_program, 0, "position");
	glBindAttribLocation(m_program, 1, "texCoord");

	glLinkProgram(m_program);
	CheckShaderError(m_program, GL_LINK_STATUS, true, "Error: Program linking failed!");

	glValidateProgram(m_program);
	CheckShaderError(m_program, GL_VALIDATE_STATUS, true, "Error: Program is invalid!");

	m_uniforms[TRANSFORM_U] = glGetUniformLocation(m_program, "transform");
}

Shader::~Shader() {
	for (unsigned int i = 0; i < NUM_SHADERS; i++) {
		glDetachShader(m_program, m_shaders[i]);
		glDeleteShader(m_shaders[i]);
	}

	glDeleteProgram(m_program);
}

void Shader::Bind() {
	glUseProgram(m_program);
}

void Shader::Update(const Transform& transform) {
	mat4 model = transform.GetModel();

	glUniformMatrix4fv(m_uniforms[TRANSFORM_U], 1, GL_FALSE, &model[0][0]);
}

static GLuint CreateShader(const string& text, GLenum shaderType) {
	GLuint shader = glCreateShader(shaderType);

	if (shader == 0)
		cerr << "Error: Shader creation failed" << endl;

	const GLchar* shaderSourceStrings[1];
	GLint shaderSourceStringLength[1];

	shaderSourceStrings[0] = text.c_str();
	shaderSourceStringLength[0] = text.length();

	glShaderSource(shader, 1, shaderSourceStrings, shaderSourceStringLength);
	glCompileShader(shader);

	CheckShaderError(shader, GL_COMPILE_STATUS, false, "Error: Shader compilation failed!");

	return shader;
}

static string LoadShader(const string& filename) {
	ifstream file;
	file.open((filename).c_str());

	string output;
	string line;

	if (file.is_open()) {
		while (file.good()) {
			getline(file, line);
			output.append(line + "\n");
		}
	} else {
		cerr << "Unable to load shader: " << filename << endl;
	}

	return output;
}

static void CheckShaderError(GLuint shader, GLuint flag, bool isProgram, const string& errorMessage) {
	GLint succes = 0;
	GLchar error[1024] = {0};

	if (isProgram)
		glGetProgramiv(shader, flag, &succes);
	else
		glGetShaderiv(shader, flag, &succes);

	if (succes == GL_FALSE) {
		if (isProgram)
			glGetProgramInfoLog(shader, sizeof(error), NULL, error);
		else
			glGetShaderInfoLog(shader, sizeof(error), NULL, error);

		cerr << errorMessage << ": '" << error << "'" << endl;
	}
}