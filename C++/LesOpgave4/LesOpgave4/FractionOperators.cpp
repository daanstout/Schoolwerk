#include "stdafx.h"
#include "Fraction.h"

Fraction Fraction::operator*(const int &a) {
	Fraction f;

	*f.nominator = *this->nominator * a;
	*f.denominator = *this->denominator * a;

	return f;
}

Fraction Fraction::operator*(const Fraction &a) {
	Fraction f;

	*f.nominator = *this->nominator * *a.nominator;
	*f.denominator = *this->denominator * *a.denominator;

	return f;
}

Fraction Fraction::operator/(const int &a) {
	return *this / Fraction(a);
}

Fraction Fraction::operator/(const Fraction &a) {
	return *this * Fraction(*a.denominator, *a.nominator);
}

Fraction Fraction::operator+(const int &a) {
	Fraction f;

	f.denominator = this->denominator;
	f.nominator = this->nominator + (*f.denominator * a);

	return f;
}

Fraction Fraction::operator+(const Fraction &a) {
	int lowest = lcm(*this->denominator, *a.denominator);
	int own = *this->nominator * (lowest / *this->denominator);
	int other = *a.nominator * (lowest / *a.denominator);
	int divider = gcd(own + other, lowest);

	Fraction f((own + other) / divider, lowest / divider);

	return f;
}

Fraction Fraction::operator-(const int &a) {
	Fraction f;
	
	f.denominator = this->denominator;
	f.nominator = this->nominator - (*f.denominator * a);

	return f;
}

Fraction Fraction::operator-(const Fraction &a) {
	int lowest = lcm(*this->denominator, *a.denominator);
	int own = *this->nominator * (lowest / *this->denominator);
	int other = *a.nominator * (lowest / *a.denominator);
	int divider = gcd(own - other, lowest);

	Fraction f((own - other) / divider, lowest / divider);

	return f;
}