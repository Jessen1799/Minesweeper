using System;

namespace Minesweeper;

public class GameMaster
{
    public readonly MineField[,] Mfarray = new MineField[9,9];
    private Random? _rnd;
    private const int NoOfBombsTotal = 50;
    


    public GameMaster()
    {
        InitMineFieldElements();
    }
    
    private void InitMineFieldElements()
    {
        for (var row = 0; row < Mfarray.GetLength(0); row++)
        {
            for(var col = 0; col < Mfarray.GetLength(1); col++) 
            {
                Mfarray[row, col] = new MineField(row, col);
            }
        }
        RandomMine();
    }

    private void RandomMine()
    {
        _rnd = new Random();
        var minesCounter = 0;
        
        while (minesCounter < NoOfBombsTotal)
        {
            var row = _rnd.Next(0, Mfarray.GetLength(0));
            var col = _rnd.Next(0, Mfarray.GetLength(1));

            if (!Mfarray[row, col].HasMine)
            {
                Mfarray[row, col].HasMine = true; //Ændrer state på entry i array ved indeks
                minesCounter++;
            }            
        }
    }
    
    public int CheckAdjacentMineFields(MineField mineField)
    {
        var row = mineField.Row;
        var col = mineField.Col;
        var neighbourMine = 0;

        for (var r = row - 1; r <= row + 1; r++)
        {
            for (var c = col - 1; c <= col + 1; c++)
            {
                if (r < 0 || r >= Mfarray.GetLength(0) || c < 0 || c >= Mfarray.GetLength(1))
                {
                    continue;
                }
                if (r == row && c == col)
                {
                    continue;
                }

                if (Mfarray[r, c].HasMine)
                {
                    neighbourMine++;
                }
            }
        }
        return neighbourMine;
    }
}