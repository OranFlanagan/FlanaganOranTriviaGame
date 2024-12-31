using Microsoft.Maui.Controls;
namespace FlanaganOranTriviaGame;

public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();
    }

    //this is a simple dark mode button that changes all the background colours and the text colours to black
    //which is automatically in dark mode
    private void DarkMode_Clicked(object sender, EventArgs e)
    {
        Application.Current.UserAppTheme = AppTheme.Dark;
    }

    //The exact same as the dark mode button but all it does is change the colour of both the background and text to white
    private void LightMode_Clicked(object sender, EventArgs e)
    {
        Application.Current.UserAppTheme = AppTheme.Light;
    }
}