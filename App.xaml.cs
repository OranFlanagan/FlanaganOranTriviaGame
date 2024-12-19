namespace FlanaganOranTriviaGame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

        }

        /*protected override void OnAppThemeChanged(AppThemeChangedEventArgs args)
        {
            base.OnAppThemeChanged(args);

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
            if(UserAppTheme == AppTheme.Dark) 
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
