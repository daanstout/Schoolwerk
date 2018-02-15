#pragma once

#include "iostream"
#include <iostream>
using namespace std;

struct Block {
	int number;
	Block* next;
};

class Stack {
public:
	// FUNCTIONS
	Stack();
	~Stack();

	bool is_empty();
	void push(int x);
	int pop();
	void print();
	int size();
	int sum();

private:
	void Destroy(Block* block);
	void DestroyBlock(Block* block);
	void print(Block* block);
	int size(Block* block);
	int sum(Block* block);

	// VARIABLES
private:
	Block * top;
};

