// See https://aka.ms/new-console-template for more information

using MementoPattern.New;
using MementoPattern.Old;
using MementoPattern.Utils.Enums;
using MementoPattern.Utils.Exceptions;

Console.WriteLine("Hello, Hangman");
NewWay();

void OldWay()
{
    var game = new HangmanGame();

    while (!game.IsOver)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Welcome to Hangman");

        Console.WriteLine(game.CurrentMaskedWord);
        Console.WriteLine($"Previous Guesses: {String.Join(',', game.PreviousGuesses.ToArray())}");
        Console.WriteLine($"Guesses Left: {game.GuessesRemaining}");


        Console.WriteLine("Guess (a-z): ");

        var entry = char.ToUpperInvariant(Console.ReadKey().KeyChar);


        try
        {
            game.Guess(entry);

            Console.WriteLine();
        }
        catch (DuplicateGuessException)
        {
            OutputError("You already guessed that.");
        }
        catch (InvalidGuessException)
        {
            OutputError("Sorry, invalid guess.");
        }
    }

    if (game.Result == GameResult.Won)
    {
        Console.WriteLine("CONGRATS! YOU WON!");
        Console.WriteLine("The result was: " + game.CurrentMaskedWord);
    }

    if (game.Result == GameResult.Lost)
    {
        Console.WriteLine("SORRY, You lost this time. Try again!");
    }
}

void NewWay()
{
    var game = new HangmanGameWithUndo();
    var gameHistory = new Stack<HangmanMemento>();
    gameHistory.Push(game.CreateSetPoint());

    while (!game.IsOver)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Welcome to Hangman");

        Console.WriteLine(game.CurrentMaskedWord);
        Console.WriteLine($"Previous Guesses: {String.Join(',', game.PreviousGuesses.ToArray())}");
        Console.WriteLine($"Guesses Left: {game.GuessesRemaining}");

        Console.WriteLine("Guess (a-z or '-' to undo last guess): ");

        var entry = char.ToUpperInvariant(Console.ReadKey().KeyChar);


        if(entry == '-')
        {
            if(gameHistory.Count > 1)
            {
                gameHistory.Pop();
                game.ResumeFrom(gameHistory.Peek());
                Console.WriteLine();
                continue;
            }
        }

        try
        {
            game.Guess(entry);
            gameHistory.Push(game.CreateSetPoint());

            Console.WriteLine();
        }
        catch (DuplicateGuessException)
        {
            OutputError("You already guessed that.");
            continue;
        }
        catch (InvalidGuessException)
        {
            OutputError("Sorry, invalid guess.");
            continue;
        }
    }

    if (game.Result == GameResult.Won)
    {
        Console.WriteLine("CONGRATS! YOU WON!");
    }

    if (game.Result == GameResult.Lost)
    {
        Console.WriteLine("SORRY, You lost this time. Try again!");
    }
}

void OutputError(string message)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
    Thread.Sleep(3000);
}