namespace FlanaganOranTriviaGame;

public partial class TheChase : ContentPage
{
    string Player1;
    public TheChase()
	{
		InitializeComponent();
	}
	private async void HigherOption_Clicked()
	{

        Player1 = await DisplayPromptAsync("Player one", "Enter your name");
        if (Player1 == null)
        {
            await DisplayAlert("Error", "You must enter a name to play.", "OK");
            return;
        }
    }
	private async void Middle_Clicked()
	{

	}

	private async void LowerOption_Clicked()
	{

	}
}