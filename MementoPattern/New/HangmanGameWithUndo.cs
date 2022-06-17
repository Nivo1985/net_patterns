using MementoPattern.Old;

namespace MementoPattern.New;

public class HangmanGameWithUndo: HangmanGame
{
    public HangmanMemento CreateSetPoint()
    {
        var guesses = PreviousGuesses.ToArray();
        return new HangmanMemento() { Guesses = guesses };
    }

    public void ResumeFrom(HangmanMemento memento)
    {
        var guesses = memento.Guesses;
        PreviousGuesses.Clear();
        PreviousGuesses.AddRange(guesses);
    }
}