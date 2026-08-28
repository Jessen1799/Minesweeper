using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Minesweeper;
/// <summary>
/// Responsible for handling UI
/// </summary>
public partial class MainWindow : Window
{
    private readonly Stopwatch _sw = new();
    private readonly GameMaster _gameMaster;
    
    public MainWindow()
    {
        InitializeComponent();
        
        _gameMaster = new GameMaster();
        InitializeCellInGrid();
    }

    /// <summary>
    /// Initializes cells in our grid
    /// </summary>
    private void InitializeCellInGrid()
    {
        for (var row = 0; row < _gameMaster.ArrayOfMineFields.GetLength(0); row++)
        {
            for (var column = 0; column < _gameMaster.ArrayOfMineFields.GetLength(1); column++)
            {
                var mineField = _gameMaster.ArrayOfMineFields[row, column];
                var cell = new Cell(mineField, CellClicked);
                
                GameGrid.Children.Add(cell);
            }
        }
    }
    

    /// <summary>
    /// Every time a cell is clicked, it checks for a mine and ends game if it was a mine.
    /// If no mine it continues while counting opened cells to check if player has won after not hitting a mine.
    /// </summary>
    /// <param name="mineField"></param>
    /// <param name="cell"></param>
    private void CellClicked(MineField mineField, Cell cell)
    {
        var adjacentMines = _gameMaster.CheckAdjacentMineFields(mineField);

        if (mineField.HasMine)
        {
            cell.Button.IsVisible = false;
            cell.Label.Content = "Bomb";
            cell.Label.IsVisible = true;
            LblGame.Content = "You lost!";
            _sw.Stop();
            LblTime.Content = $"Time used: {_sw.Elapsed.Seconds.ToString()} seconds";
            return;
        }
        cell.Label.Content = adjacentMines.ToString();
        cell.Label.Foreground = Brushes.White;
        cell.Button.IsVisible = false;
        cell.Label.IsVisible = true;
        
        _gameMaster.RevealField();

        if (_gameMaster.GameWon())
        {
            LblGame.Content = "Game Over - You won!";
        }
    }

    /// <summary>
    /// Starts timer of game
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnStart_OnClick(object? sender, RoutedEventArgs e)
    {
        _sw.Start();
    }
}