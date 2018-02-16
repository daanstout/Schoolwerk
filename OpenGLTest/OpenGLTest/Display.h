#pragma once

#include <string>
#include <iostream>

#include <SDL2/SDL.h>
#include <GLEW\GL\glew.h>

using namespace std;

class Display {
	// FUNCTIONS
public:
	Display(int width, int height, const string& title);
	virtual ~Display();

	void Update();
	bool IsClosed();
	void Clear(float r, float g, float b, float a);
private:

	// VARIABLES
private:
	SDL_Window * m_window;
	SDL_GLContext m_glContext;
	bool m_isClosed;
	int width;
	int height;
};

