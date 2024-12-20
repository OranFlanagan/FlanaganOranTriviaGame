using Microsoft.Maui.Controls;
namespace FlanaganOranTriviaGame;

public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();
    }

    private void DarkMode_Clicked(object sender, EventArgs e)
    {
        Application.Current.UserAppTheme = AppTheme.Dark;
    }

    private void LightMode_Clicked(object sender, EventArgs e)
    {
        Application.Current.UserAppTheme = AppTheme.Light;
    }
}