// LesOpgave1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
using namespace std;

struct PlayerState {
	char name[20];
	int level;
	double health;
	int experience;
};

void Opgave1();
int Sum(int a, int b);
void IsEven(int a);
int Exponant(int base, int exponant);
bool IsPrime(int a);
int ValueAtIndex(int a[], int b, int size);
void swap(int *xp, int *yp);
void bubbleSort(int arr[], int n);
int gcd(int a, int b);
int lcm(int a, int b);

void Opgave2();
void SimplifyFraction(int &a, int &b);
void PrintNameArray(char list[][25], int sizea, int sizeb);
bool IsPalindrome(char input[], int length);
void PrintTxtToConsole(char filename[]);
void PrintPlayerStates(PlayerState players[], int length);
void SavePlayerState(char filename[], PlayerState players[], int length);
void ReadPlayerState(char infilename[], char outfilename[]);

int main() {
	//Opgave1();
	Opgave2();


	return 0;
}


#pragma region Opgave1
void Opgave1() {
	// Opgave 1
	cout << "Opgave 1 - Sum\n";
	cout << 3 << '+' << 6 << '=' << Sum(3, 6) << '\n';
	cout << Sum(15, 6) << '\n';
	cout << Sum(32, 6) << '\n';

	// Opgave 2
	cout << "Opgave 2 - IsEven\n";
	IsEven(5);
	IsEven(3);
	IsEven(10);

	// Opgave 3
	cout << "Opgave 3 - Exponant\n";
	cout << Exponant(2, 3) << '\n';
	cout << Exponant(3, 3) << '\n';
	cout << Exponant(4, 3) << '\n';

	// Opgave 4
	cout << "Opgave 4 - IsPrime\n";
	cout << IsPrime(2) << '\n';
	cout << IsPrime(9) << '\n';
	cout << IsPrime(17) << '\n';

	// Opgave 5
	cout << "Opgave 5 - ValueAtIndex\n";
	int arr[] = {4, 1, 7, 3, 2, 9, 8, 6, 5};
	cout << ValueAtIndex(arr, 5, 9) << '\n';
	cout << ValueAtIndex(arr, 32, 9) << '\n';
	cout << ValueAtIndex(arr, 1, 9) << '\n';

	// Opgave 6
	cout << "Opgave 6 - BubbleSort\n";
	bubbleSort(arr, 9);
	for (int i = 0; i < 9; i++)
		cout << arr[i] << " - ";
	cout << '\n';

	//Opgave 7
	cout << "Opgave 7 - Greatest Common Divider\n";
	cout << gcd(1071, 462) << '\n';
	cout << gcd(20, 15) << '\n';
	cout << gcd(100, 54) << '\n';

	//Opgave 8
	cout << "Opgave 8 - Least Common Multiple\n";
	cout << lcm(1071, 462) << '\n';
	cout << lcm(20, 15) << '\n';
	cout << lcm(100, 54) << '\n';
}

int Sum(int a, int b) {
	return a + b;
}

void IsEven(int a) {
	if (a % 2)
		cout << "Odd" << '\n';
	else
		cout << "Even" << '\n';
}

int Exponant(int base, int exponant) {
	if (exponant == 0)
		return 1;
	else
		return base * Exponant(base, exponant - 1);
}

bool IsPrime(int a) {
	for (int i = 2; i <= a / 2; i++) {
		if (a % i == 0) {
			return false;
		}
	}
	return true;
}

int ValueAtIndex(int a[], int b, int size) {
	for (int i = 0; i < size; i++) {
		if (a[i] == b)
			return i + 1;
	}
	return -1;
}

void swap(int *xp, int *yp) {
	int temp = *xp;
	*xp = *yp;
	*yp = temp;
}

void bubbleSort(int arr[], int n) {
	int i, j;
	for (i = 0; i < n - 1; i++)
		for (j = 0; j < n - i - 1; j++)
			if (arr[j] > arr[j + 1])
				swap(&arr[j], &arr[j + 1]);
}

int gcd(int a, int b) {
	if (b == 0)
		return a;
	else
		return gcd(b, a % b);
}

int lcm(int a, int b) {
	return (a * b) / gcd(a, b);
}
#pragma endregion

#pragma region Les2
void Opgave2() {
	// Opgave 2
	int a, b;
	a = 100;
	b = 30;
	cout << "Simplifying: " << a << " and " << b << endl;
	SimplifyFraction(a, b);
	cout << "Simplified: " << a << " and " << b << endl;

	// Opgave 3
	char nameList[10][25];
	//nameList[0] = "Daan Stout";
	strcpy_s(nameList[0], "Daan Stout");
	strcpy_s(nameList[1], "Gijs ALberts");
	strcpy_s(nameList[2], "Anne Zweers");
	strcpy_s(nameList[3], "Tim Roskam");

	//PrintNameArray(nameList, 10, 25);

	// Opgave 4
	cout << "Is \"abba\" a palindrome? " << IsPalindrome("abba", 4) << endl;
	cout << "Is \"tacocat\" a palindrome? " << IsPalindrome("tacocat", 7) << endl;
	cout << "Is \"weekend\" a palindrome? " << IsPalindrome("weekend", 7) << endl;

	// Opgave 5
	PrintTxtToConsole("test.txt");

	// Opgave 7
	PlayerState players[3];
	strcpy_s(players[0].name, "first");
	players[0].level = 5;
	players[0].health = 53.4;
	players[0].experience = 105;

	strcpy_s(players[1].name, "second");
	players[1].level = 3;
	players[1].health = 22.1;
	players[1].experience = 43;

	strcpy_s(players[2].name, "third");
	players[2].level = 1;
	players[2].health = 9.3;
	players[2].experience = 4;

	PrintPlayerStates(players, 3);

	// Opgave 8
	SavePlayerState("game.data", &players[3], 3);

	// Opgave 9
	ReadPlayerState("game.data", "game.txt");
}

void SimplifyFraction(int &a, int &b) {
	int divider = gcd(a, b);
	a /= divider;
	b /= divider;
}

void PrintNameArray(char list[][25], int sizea, int sizeb) {
	for (int i = 0; i < sizea; i++) {
		if (list[i][0] == '\0')
			continue;
		for (int j = 0; j < sizeb; j++) {
			if (list[i][j] == '\0')
				break;
			cout << list[i][j];
		}
		cout << endl;
	}
}

bool IsPalindrome(char input[], int length) {
	for (int i = 0; i < length - i - 1; i++) {
		if (input[i] != input[length - i - 1])
			return false;
	}
	return true;
}

void PrintTxtToConsole(char filename[]) {
	ifstream file;
	file.open(filename);
	if(file.is_open())
		cout << file.rdbuf() << endl;
	file.close();
}

void PrintPlayerStates(PlayerState players[], int length) {
	for (int i = 0; i < length; i++) {
		cout << "Player: " << players[i].name << " is level " << players[i].level << ", has " << players[i].health << " health and " << players[i].experience << " experience." << endl;
	}
}

void SavePlayerState(char filename[], PlayerState players[], int length) {
	ofstream file;
	file.open(filename, ios::binary);
	/*for (int i = 0; i < length; i++) {
		file.write((char *)&players[i], sizeof(PlayerState));
	}*/
	file.write((char *)&players, sizeof(players));
	file.close();
}

void ReadPlayerState(char infilename[], char outfilename[]) {
	int i;
	PlayerState localstate;
	ifstream infile;
	ofstream outfile;
	infile.open(infilename, ios::binary);
	outfile.open(outfilename);
	if (infile.is_open()) {
		for (int i = 0; i < 3; i++) {
			infile.read((char *)&localstate, sizeof(PlayerState));
			outfile << localstate.name << endl;
		}
		infile.close();
		outfile.close();
	}
}
#pragma endregion
