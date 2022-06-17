﻿using System.Text.RegularExpressions;
using MementoPattern.Utils.Enums;
using MementoPattern.Utils.Exceptions;

namespace MementoPattern.Old;

public class HangmanGame
{
    private readonly string _secretWord;
    private const char _maskChar = '_';
    protected const int INITIAL_GUESSES = 5;

    public HangmanGame(string secretWord = "secret")
    {
        _secretWord = secretWord.ToUpperInvariant();
    }

    public bool IsOver => this.Result > GameResult.InProgress;
    public string CurrentMaskedWord => new string(_secretWord.Select(c => PreviousGuesses.Contains(c) ? c : _maskChar).ToArray());
    public List<char> PreviousGuesses { get; } = new List<char>();
    public int GuessesRemaining => INITIAL_GUESSES - PreviousGuesses.Count(c => !CurrentMaskedWord.Contains(c));
    public GameResult Result { get; private set; }

    public void Guess(char guessChar)
    {
        if (char.IsWhiteSpace(guessChar)) throw new InvalidGuessException("Guess cannot be blank.");
        if (!Regex.IsMatch(guessChar.ToString(), "^[A-Z]$")) throw new InvalidGuessException("Guess must be a capital letter A through Z");
        if (IsOver) throw new InvalidGuessException("Can't make guesses after game is over.");

        if (PreviousGuesses.Any(g => g == guessChar)) throw new DuplicateGuessException("Guess was already made");

        PreviousGuesses.Add(guessChar);

        if (_secretWord.IndexOf(guessChar) >= 0)
        {
            if (!CurrentMaskedWord.Contains(_maskChar))
            {
                Result = GameResult.Won;
            }
            return;
        }

        if(GuessesRemaining <= 0)
        {
            Result = GameResult.Lost;
        }
    }
}