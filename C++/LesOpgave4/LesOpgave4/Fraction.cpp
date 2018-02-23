#include "stdafx.h"
#include "Fraction.h"


Fraction::Fraction() {
	*this->denominator = 1;
}

Fraction::Fraction(int a) {
	*this->nominator = a;
	*this->denominator = 1;
}

Fraction::Fraction(int a, int b) {
	*this->nominator = a;
	*this->denominator = b;
}

Fraction::~Fraction() {
	if (this->nominator != NULL) {
		delete this->nominator;
		this->nominator = NULL;
	}
	if (this->denominator != NULL) {
		delete this->denominator;
		this->denominator = NULL;
	}
}

int Fraction::gcd(int a, int b) {
	if (b == 0)
		return a;
	else
		return gcd(b, a % b);
}

int Fraction::lcm(int a, int b) {
	return (a * b) / gcd(a, b);
}
