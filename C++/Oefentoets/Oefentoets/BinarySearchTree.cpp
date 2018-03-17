#include "stdafx.h"
#ifndef BINARYSEARCHTREE_CPP
#define BINARYSEARCHTREE_CPP
#include "BinarySearchTree.h"

template <class T>
BST<T>::BST() {
	root = NULL;
}

template <class T>
void BST<T>::insert(T x) {
	if (root == NULL) {
		root = new Node<T>();
		root->info = x;
	} else {
		insert(x, *root);
	}
}

template <class T>
void BST<T>::insert(T x, Node<T> &node) {
	if (&node == NULL) {
		return;
	} else {
		if (x > node.info) {
			if (node.right == NULL) {
				node.right = new Node<T>();
				node.right->info = x;
			} else {
				insert(x, *node.right);
			}
		} else if (x < node.info) {
			if (node.left == NULL) {
				node.left = new Node<T>();
				node.left->info = x;
			} else {
				insert(x, *node.left);
			}
		}
	}
}

template <class T>
void BST<T>::traverse() {
	if (root == NULL)
		return;
	else
		traverse(*root);
}

template <class T>
void BST<T>::traverse(Node<T> &node) {
	if (&node == NULL)
		return;
	else {
		traverse(*node.left);
		cout << node.info << endl;
		traverse(*node.right);
	}
}

template <class T>
BST<T>::~BST() {
	if (root != NULL) {
		delete root;
	}
}

#endif