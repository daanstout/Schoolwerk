// LesOpgave2.cpp : Defines the entry point for the console application.
//


#include "stdafx.h"
#include <string>
#include <iostream>
using namespace std;

void WordGuesser();

int main()
{
	WordGuesser();

	
	
	cin.get();

    return 0;
}

void WordGuesser() {
	cout << "What word should be guessed?" << '\n';
	string word;
	string guess;
	cin >> word;

	for (int i = 0; i < word.length(); i++) {
		guess += ". ";
	}
	bool wordGuessed = false;
	int tries = 0;
	cout << "Let player 2 guess" << '\n';
	cout << guess << '\n';

	while (!wordGuessed && tries < 10) {
		char guessedchar;
		cin >> guessedchar;
		tries++;
		for (int i = 0; i < word.length(); i++) {
			if (word.at(i) == guessedchar) {
				guess[i * 2] = word.at(i);
			}
		}
		wordGuessed = true;
		for (int i = 0; i < guess.length(); i++) {
			if (guess.at(i) == '.') {
				wordGuessed = false;
			}
		}
		cout << guess << '\n';
	}

	if (wordGuessed) {
		cout << "You guessed it!" << '\n';
	}


	
	
}
