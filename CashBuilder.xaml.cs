namespace FlanaganOranTriviaGame;

public partial class CashBuilder : ContentPage
{
    string Player1;
    string Player2;
    string Player3;
    string Player4;

    public CashBuilder()
    {
        InitializeComponent();
    }

    private async void CashBuilder_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        Player1 = await DisplayPromptAsync("Player one", "Enter your name");
        if (Player1 == null)
        {
            await DisplayAlert("Error", "You must enter a name to play.", "OK");
            return;
        }

        Player2 = await DisplayPromptAsync("Player two", "Enter your name");
        if (Player2 == null)
        {
            await DisplayAlert("Error", "You must enter a name to play.", "OK");
            return;
        }

        Player3 = await DisplayPromptAsync("Player 3", "Enter your name");
        if (Player3 == null)
        {
            await DisplayAlert("Error", "You must enter a name to play.", "OK");
            return;
        }

        Player4 = await DisplayPromptAsync("Enter", "Enter your name");
        if (Player4 == null)
        {
            await DisplayAlert("Error", "You must enter a name to play.", "OK");
            return;

        }
    }
}