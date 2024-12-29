using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Word 
{
    private string wordString;
    private bool isFound = false;
    private List<Letter> letters = new List<Letter>();
    private Direction direction;

    private int startingRowNumber;
    private int startingColNumber;
    public enum Direction
    {
        Horizontal,
        Vertical,
        Diagonal
    }

    public Word(string wordString, Direction direction, int startingRow, int startingCol)
{
    this.wordString = wordString;
    this.direction = direction;
    this.startingRowNumber = startingRow;
    this.startingColNumber = startingCol;

    char[] characters = wordString.ToCharArray();

    for (int i = 0; i < characters.Length; i++)
    {
        Letter letter = null;
        startingRowNumber = startingRow;
        startingColNumber = startingCol;

        if (this.direction == Direction.Horizontal)
        {
            letter = new Letter(
                characters[i],
                startingRowNumber +i,
                startingColNumber
            );
        }
        else if (this.direction == Direction.Vertical)
        {
            letter = new Letter(
                characters[i],
                startingRowNumber,
                startingColNumber + i
            );
        }
        else if (this.direction == Direction.Diagonal)
        {
            letter = new Letter(
                characters[i],
                startingRowNumber + i,
                startingColNumber + i
            );
        }

        if (letter != null)
        {
            letters.Add(letter);
        }
    }
    }

    public void wordFound(){
        this.isFound = true;
    }

    public bool getWordStatus() {
        return this.isFound;
    }

    public string getWordString()
    {
        return this.wordString;
    }

    public List<Letter> getLetters()
    {
        return this.letters;
    }

}
