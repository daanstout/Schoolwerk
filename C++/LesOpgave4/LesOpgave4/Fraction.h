#pragma once
#include "iostream"
#include <iostream>
using namespace std;

class Fraction {
private:
	int *nominator;
	int *denominator;

private:
	int gcd(int a, int b);
	int lcm(int a, int b);

public:
	Fraction();
	Fraction(int a);
	Fraction(int a, int b);
	~Fraction();

	int getNom() { return *this->nominator; }
	int getDenom() { return *this->denominator; }

	Fraction operator*(const int &a);
	Fraction operator*(const Fraction &a);
	Fraction operator/(const int &a);
	Fraction operator/(const Fraction &a);
	Fraction operator+(const int &a);
	Fraction operator+(const Fraction &a);
	Fraction operator-(const int &a);
	Fraction operator-(const Fraction &a);
};

