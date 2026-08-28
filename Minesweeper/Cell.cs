using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Minesweeper;

/// <summary>
/// UI Component container responsible for holding a reference to MineField.
/// </summary>
public class Cell : Grid
{
    public  readonly Button Button;
    public readonly Label Label;
    //Reference to MineField Object
    private readonly MineField _mineField;
    private readonly Action<MineField, Cell> _onCellClick;
    
    /// <summary>
    /// Construcs a Cell object/container holding a Button and a Label.
    /// Cell holds a reference to Minefield
    /// Method from delegate is being added to click event on button.
    /// </summary>
    /// <param name="mineField"></param>
    /// <param name="onCellClick"></param>
    public Cell(MineField mineField, Action<MineField, Cell> onCellClick)
    {
        Button = new Button
        {
            Classes = { "layout" },
            Content = "?"
        };
        
        Label = new Label
        {
            Classes = { "layout" },
            Content = "",
            IsVisible = false
        };
        
        _mineField = mineField;
        
        _onCellClick = onCellClick;
        
        Button.Click += OnCellClicked;
        
        Children.Add(Label);
        Children.Add(Button);
    }
    
    /// <summary>
    /// Invokes delegate with ref to minefield and cell.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnCellClicked(object? sender, RoutedEventArgs e)
    {
        _onCellClick.Invoke(_mineField, this);
    }
    
}