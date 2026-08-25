namespace Minesweeper;

public class GameMaster
{
    public MineField[,] Mfarray = new MineField[3,3];


    public GameMaster()
    {
        InitMineFieldElements();
        Mfarray[0,0].HasMine = true;
    }
    
    private void InitMineFieldElements()
    {
        for (int row = 0; row < 3; row++)
        {
            for(int col = 0; col < 3; col++) 
            {
                Mfarray[row,col] = new MineField();
            }
        }
    }
}