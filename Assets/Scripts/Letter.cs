using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Letter 
{
    private char character;
    private int RowNumber;
    private int ColNumber;

    private Vector3 firstGridSlot = new Vector3(0,0,0);

    public Letter(
        char character,
        int RowNumber,
        int ColNumber
    )
    {
        this.character = character;
        this.RowNumber = RowNumber;
        this.ColNumber = ColNumber;
    }
    

    public char getCharacter()
    {
        return this.character;
    }

    public int getRowNumber()   
    {
        return this.RowNumber;
    }

    public int getColNumber()
    {
        return this.ColNumber;
    }

    public Vector3 getCoordinates(){
        return new Vector3(firstGridSlot.x + ( 26 * this.RowNumber) ,firstGridSlot.y - ( 26 * this.ColNumber), 214.5f);
    }
}