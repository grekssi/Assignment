using Movies.Controls;
using Movies.ViewModels;

namespace Movies;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        var newStep = Math.Round(e.NewValue);

        ((Slider)sender).Value = newStep;
    }
}

