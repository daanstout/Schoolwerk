#pragma once

#include "iostream"
#include <iostream>
using namespace std;

struct node {
	int info;
	node* left;
	node* right;
};

class BinarySearchTree {
	// FUNCTIONS
public:
	BinarySearchTree();
	~BinarySearchTree();

	void insert(int x);
	int depth();
	bool is_present(int x);
	void travers();
	void print();

private:
	void Destroy(node* n);
	void insert(int x, node* n);
	node* Create(int x);
	int depth(node* n);
	bool is_present(int x, node* n);
	void travers(node* n);
	void print(node* n, int depth);

	// VARIABLES
private:
	node * root;
};

