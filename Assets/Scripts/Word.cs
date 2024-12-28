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
    
    public void wordFound(){
        this.isFound = true;
    }

    public bool getWordStatus() {
        return this.isFound;
    }

    public float[] getFirstLetterCoordinates(){
        float[] coordinates = {this.firstLetterXCoordinate, this.firstLetterYCoordinate};
        return coordinates;
    
    }

    public float[] getLastLetterCoordinates(){
        float[] coordinates = {this.lastLetterXCoordinate, this.lastLetterYCoordinate};
        return coordinates;
    }

}
