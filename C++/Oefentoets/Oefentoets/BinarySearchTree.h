#pragma once
#ifndef BINARYSEARCHTREE_H
#define BINARYSEARCHTREE_H
#include "string.h"
#include <iostream>

using namespace std;

template <class T>
struct Node {
	T info;
	Node *left;
	Node *right;
};

template <class T>
class BST {
public:
	BST();
	~BST();
	void insert(T x);
	void traverse();

private:
	Node<T> *root;

	void insert(T x, Node<T> &node);
	void traverse(Node<T> &node);
};

#include "BinarySearchTree.cpp"
#endif