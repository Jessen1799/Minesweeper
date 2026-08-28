

namespace Minesweeper;

/// <summary>
/// Responsible for holding data for a minefield.
/// </summary>
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