using Avalonia.Controls;
using Avalonia.Media;

namespace Minesweeper;

public partial class MainWindow : Window
{
    private readonly GameMaster _gameMaster;
    
    public MainWindow()
    {
        InitializeComponent();
        _gameMaster = new GameMaster();
        InitializeCellInGrid();
        
    }

    private void InitializeCellInGrid()
    {
        for (var row = 0; row < _gameMaster.Mfarray.GetLength(0); row++)
        {
            for (var column = 0; column < _gameMaster.Mfarray.GetLength(1); column++)
            {
                var mineField = _gameMaster.Mfarray[row, column];
                var cell = new Cell(mineField, CellClicked);
                
                GameGrid.Children.Add(cell);
            }
        }
    }

    private void CellClicked(MineField mineField, Cell cell)
    {
        var adjacentMines = _gameMaster.CheckAdjacentMineFields(mineField);

        if (mineField.HasMine)
        {
            cell.Button.IsVisible = false;
            cell.Label.Content = "Bomb";
            cell.Label.IsVisible = true;
            return;
        }
        cell.Label.Content = adjacentMines.ToString();
        cell.Label.Foreground = Brushes.Black;
        cell.Button.IsVisible = false;
        cell.Label.IsVisible = true;
    }
}