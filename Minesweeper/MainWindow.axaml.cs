using Avalonia.Controls;

namespace Minesweeper;

public partial class MainWindow : Window
{
    public GameMaster GameMaster;
    
    public MainWindow()
    {
        InitializeComponent();
        GameMaster = new GameMaster();
        InitializeCellInGrid();
        
    }

    private void InitializeCellInGrid()
    {
        for (var row = 0; row < 3; row++)
        {
            for (var column = 0; column < 3; column++)
            {
                var mineField = GameMaster.Mfarray[row, column];
                var cell = new Cell(mineField);
                
                Grid.SetRow(cell, row);
                Grid.SetColumn(cell, column);
                
                GameGrid.Children.Add(cell);
            }
        }
    }
}