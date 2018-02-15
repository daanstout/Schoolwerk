#include "stdafx.h"
#include "BinarySearchTree.h"


BinarySearchTree::BinarySearchTree() {
	root = NULL;
}

BinarySearchTree::~BinarySearchTree() {
	Destroy(root);
}

void BinarySearchTree::Destroy(node* n) {
	if (n == NULL)
		return;

	Destroy(n->left);
	Destroy(n->right);

	delete n;
}

void BinarySearchTree::insert(int x) {
	if (root == NULL)
		root = Create(x);
	else
		insert(x, root);
}

void BinarySearchTree::insert(int x, node* n) {
	if (n == NULL)
		return;

	if (x > n->info)
		if (n->right == NULL)
			n->right = Create(x);
		else
			insert(x, n->right);
	else if (x < n->info)
		if (n->left == NULL)
			n->left = Create(x);
		else
			insert(x, n->left);
}

node* BinarySearchTree::Create(int x) {
	node* n = new node();
	n->info = x;
	return n;
}

int BinarySearchTree::depth() {
	return depth(root);
}

int BinarySearchTree::depth(node* n) {
	if (n == NULL)
		return 0;
	else {
		int left = depth(n->left);
		int right = depth(n->right);

		if (left > right)
			return 1 + left;
		else
			return 1 + right;
	}
}

bool BinarySearchTree::is_present(int x) {
	return is_present(x, root);
}

bool BinarySearchTree::is_present(int x, node* n) {
	if (n == NULL)
		return false;
	else if (x == n->info)
		return true;
	else if (x > n->info)
		return is_present(x, n->right);
	else if (x < n->info)
		return is_present(x, n->left);
	return false;
}

void BinarySearchTree::travers() {
	travers(root);
	cout << endl;
}

void BinarySearchTree::travers(node* n) {
	if (n == NULL)
		return;

	travers(n->left);
	cout << n->info << "\t";
	travers(n->right);
}

void BinarySearchTree::print() {
	print(root, 0);
}

void BinarySearchTree::print(node* n, int depth) {
	if (n == NULL)
		return;

	print(n->right, depth + 1);

	for (int i = 0; i < depth; i++)
		cout << "\t";

	cout << n->info << endl;

	print(n->left, depth + 1);
}