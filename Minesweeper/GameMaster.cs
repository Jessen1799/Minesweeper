using System;

namespace Minesweeper;

/// <summary>
/// Responsible for upholding game state and rules
/// </summary>
public class GameMaster
{
    public readonly MineField[,] ArrayOfMineFields = new MineField[9,9];
    private Random? _rnd;
    private int _revealedFieldsInGame;
    
    private const int NoOfBombsTotal = 10;
    

    
    public GameMaster()
    {
        InitMineFieldElements();
    }
    
    /// <summary>
    /// Initializing our minefields in array and adds mines to random mines afterwards.
    /// </summary>
    private void InitMineFieldElements()
    {
        for (var row = 0; row < ArrayOfMineFields.GetLength(0); row++)
        {
            for(var col = 0; col < ArrayOfMineFields.GetLength(1); col++) 
            {
                ArrayOfMineFields[row, col] = new MineField(row, col);
            }
        }
        RandomMine();
    }

    /// <summary>
    /// Sets a predetermined amount of bombs randomly into our Array.
    /// </summary>
    private void RandomMine()
    {
        _rnd = new Random();
        var minesCounter = 0;
        
        while (minesCounter < NoOfBombsTotal)
        {
            var row = _rnd.Next(0, ArrayOfMineFields.GetLength(0));//9
            var col = _rnd.Next(0, ArrayOfMineFields.GetLength(1));//9

            if (!ArrayOfMineFields[row, col].HasMine)
            {
                ArrayOfMineFields[row, col].HasMine = true; //Ændrer state på entry i array ved indeks
                minesCounter++;
            }            
        }
    }
    
    /// <summary>
    /// Checks adjacent minefields from argument(Minefield, mineField) to figure out
    /// if adjacent minefields contains a mine.
    /// </summary>
    /// <param name="mineField"></param>
    /// <returns>Number of bombs adjacent</returns>
    public int CheckAdjacentMineFields(MineField mineField)
    {
        var row = mineField.Row;
        var col = mineField.Col;
        var neighbourMine = 0;

        for (var r = row - 1; r <= row + 1; r++)
        {
            for (var c = col - 1; c <= col + 1; c++)
            {
                //Out of bounds checks
                if (r < 0 || r >= ArrayOfMineFields.GetLength(0) || c < 0 || c >= ArrayOfMineFields.GetLength(1))
                {
                    continue;
                }
                //No need to check current pos
                if (r == row && c == col)
                {
                    continue;
                }

                if (ArrayOfMineFields[r, c].HasMine)
                {
                    neighbourMine++;
                }
            }
        }
        return neighbourMine;
    }

    /// <summary>
    /// Player wins if its true
    /// </summary>
    /// <returns></returns>
    public bool GameWon()
    {
        return _revealedFieldsInGame == ArrayOfMineFields.Length - NoOfBombsTotal;
    }

    /// <summary>
    /// A counter for opened cells
    /// </summary>
    public void RevealField()
    {
        _revealedFieldsInGame++;
    }
}