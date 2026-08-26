

namespace Minesweeper;

public class MineField
{
    public bool HasMine { get; set; }
    public int Row { get; }
    public int Col { get; }

    public MineField(int row, int col)
    {
        Row = row;
        Col = col;
    }
}