using Plugin.Maui.Audio;
using Microsoft.Maui.Controls;

namespace FlanaganOranTriviaGame
{
    public partial class App : Application
    {
        public App(IAudioManager audioManager)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(audioManager));

            //Application.Current.OnAppThemeChanged += OnAppThemeChanged;
        }

        /*private void OnAppThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            foreach (var page in Current.MainPage.Navigation.NavigationStack)
            {
                if (page is ContentPage contentPage)
                {
                    ApplyTheme(contentPage);
                }
            }
        }

        private void ApplyTheme(ContentPage page)
        {
            if (UserAppTheme == AppTheme.Dark)
            {
                page.Resources["PageStyle"] = Current.Resources["DarkThemeStyle"];
            }
            else
            {
                page.Resources["PageStyle"] = Current.Resources["LightThemePageStyle"];
            }
        }*/
    }
}