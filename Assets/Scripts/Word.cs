using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Word 
{
    private string wordString;
    private bool isFound = false;
    private float firstLetterXCoordinate;
    private float firstLetterYCoordinate;
    private float lastLetterXCoordinate;
    private float lastLetterYCoordinate;

    public Word(string wordString, Vector3 firstLetterCoordinates, Vector3 lastLetterCoordinates)
    {
        this.wordString = wordString;
        this.firstLetterXCoordinate = firstLetterCoordinates.x;
        this.firstLetterYCoordinate = firstLetterCoordinates.y;
        this.lastLetterXCoordinate = lastLetterCoordinates.x;
        this.lastLetterYCoordinate = lastLetterCoordinates.y;
    }

    public void wordFound(){
        this.isFound = true;
    }

    public bool getWordStatus() {
        return this.isFound;
    }

    public float[] getFirstLetterCoordinates(){
        return new float[] { this.firstLetterXCoordinate, this.firstLetterYCoordinate };
    }

    public float[] getLastLetterCoordinates(){
        return new float[] { this.lastLetterXCoordinate, this.lastLetterYCoordinate };
    }
}
