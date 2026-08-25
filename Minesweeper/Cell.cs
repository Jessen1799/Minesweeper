using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Minesweeper;

public class Cell : Grid
{
    private Button _button;
    private readonly Label _label;
    private MineField _mineField;
    public Cell(MineField mineField)
    { 
        _button = new Button
        {
            Content = "?",
            Width = 63,
            Height = 63
        };
        
        _label = new Label
        {
            Content = "",
            IsVisible = false
        };
        
        _mineField = mineField;

        _button.Tag = mineField;
        _button.Click += Reveal;
        
        Children.Add(_label);
        Children.Add(_button);
    }
    
    private void Reveal(object? sender, RoutedEventArgs e)
    {
        if (_mineField.HasMine == true)
        {
            _label.Content = "Bomb";
        }
        else
        {
            _label.Content = "W";
        }
        
        _label.IsVisible = true;
        _button.IsVisible = false;
    }
}