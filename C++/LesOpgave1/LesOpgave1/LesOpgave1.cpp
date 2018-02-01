// LesOpgave1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
using namespace std;

int Sum (int a, int b);
void IsEven (int a);
int Exponant (int base, int exponant);
bool IsPrime (int a);
int ValueAtIndex (int a[], int b, int size);
void swap (int *xp, int *yp);
void bubbleSort (int arr[], int n);
int gcd (int a, int b);
int lcm (int a, int b);

int main () {
	int a, b;

	// Opgave 1
	cout << "Opgave 1 - Sum\n";
	cout << Sum (3, 6) << '\n';
	cout << Sum (15, 6) << '\n';
	cout << Sum (32, 6) << '\n';

	// Opgave 2
	cout << "Opgave 2 - IsEven\n";
	IsEven (5);
	IsEven (3);
	IsEven (10);

	// Opgave 3
	cout << "Opgave 3 - Exponant\n";
	Exponant (2, 3);
	Exponant (3, 3);
	Exponant (4, 3);

	// Opgave 4
	cout << "Opgave 4 - IsPrime\n";
	cout << IsPrime (2) << '\n';
	cout << IsPrime (9) << '\n';
	cout << IsPrime (17) << '\n';

	// Opgave 5
	cout << "Opgave 5 - ValueAtIndex\n";
	int arr[] = { 4, 1, 7, 3, 2, 9, 8, 6, 5 };
	cout << ValueAtIndex (arr, 5, 9) << '\n';
	cout << ValueAtIndex (arr, 32, 9) << '\n';
	cout << ValueAtIndex (arr, 1, 9) << '\n';

	// Opgave 6
	cout << "Opgave 6 - BubbleSort\n";
	bubbleSort (arr, 9);
	for (int i = 0; i < 9; i++)
		cout << arr[i] << " - ";
	cout << '\n';

	//Opgave 7
	cout << "Opgave 7 - Greatest Common Divider\n";
	cout << gcd (1071, 462) << '\n';
	cout << gcd (20, 15) << '\n';
	cout << gcd (100, 54) << '\n';

	//Opgave 8
	cout << "Opgave 8 - Least Common Multiple\n";
	cout << lcm (1071, 462) << '\n';
	cout << lcm (20, 15) << '\n';
	cout << lcm (100, 54) << '\n';

	return 0;
}

int Sum (int a, int b) {
	return a + b;
}

void IsEven (int a) {
	if (a % 2)
		cout << "Odd" << '\n';
	else
		cout << "Even" << '\n';
}

int Exponant (int base, int exponant) {
	if (exponant == 0)
		return 1;
	else
		return base * Exponant (base, exponant - 1);
}

bool IsPrime (int a) {
	for (int i = 2; i <= a / 2; i++) {
		if (a % i == 0) {
			return false;
		}
	}
	return true;
}

int ValueAtIndex (int a[], int b, int size) {
	for (int i = 0; i < size; i++) {
		if (a[i] == b)
			return i + 1;
	}
	return -1;
}

void swap (int *xp, int *yp) {
	int temp = *xp;
	*xp = *yp;
	*yp = temp;
}

void bubbleSort (int arr[], int n) {
	int i, j;
	for (i = 0; i < n - 1; i++)

		// Last i elements are already in place   
		for (j = 0; j < n - i - 1; j++)
			if (arr[j] > arr[j + 1])
				swap (&arr[j], &arr[j + 1]);
}

int gcd (int a, int b) {
	if (b == 0)
		return a;
	else
		return gcd (b, a % b);
}

int lcm (int a, int b) {
	return (a * b) / gcd (a, b);
}