using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Minesweeper;

public class Cell : Grid
{
    public  readonly Button Button;
    public readonly Label Label;
    private readonly MineField _mineField;
    private readonly Action<MineField, Cell> _onCellClick;
    
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
        

        Button.Tag = mineField;
        Button.Click += OnCellClicked;
        
        Children.Add(Label);
        Children.Add(Button);
    }
    
    private void OnCellClicked(object? sender, RoutedEventArgs e)
    {
        _onCellClick.Invoke(_mineField, this);
    }
    
}