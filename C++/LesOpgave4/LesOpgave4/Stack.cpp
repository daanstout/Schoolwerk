#include "stdafx.h"
#include "Stack.h"

Stack::Stack() {
	top = NULL;
}

Stack::~Stack() {
	Destroy(top);
}

void Stack::Destroy(Block* block) {
	if (block == NULL)
		return;

	Destroy(block->next);

	delete block;
}

void Stack::DestroyBlock(Block* block) {
	if (block == NULL)
		return;

	delete block;
}

bool Stack::is_empty() {
	if (top == NULL)
		return true;
	else
		return false;
}

void Stack::push(int x) {
	Block *newBlock = new Block();
	newBlock->next = top;
	newBlock->number = x;
	top = newBlock;
}

int Stack::pop() {
	if (top == NULL)
		return 0;

	//Block* next = top->next;
	int number = top->number;
	Block* old = top;
	top = top->next;

	DestroyBlock(old);

	return number;
}

void Stack::print() {
	print(top);
}

void Stack::print(Block* block) {
	if (block == NULL)
		return;

	cout << "number = " << block->number << endl;

	print(block->next);
}

int Stack::size() {
	return size(top);
}

int Stack::size(Block* block) {
	if (block == NULL)
		return 0;
	else
		return 1 + size(block->next);
}

int Stack::sum() {
	return sum(top);
}

int Stack::sum(Block* block) {
	if (block == NULL)
		return 0;
	else
		return block->number + sum(block->next);
}