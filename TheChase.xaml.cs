namespace FlanaganOranTriviaGame;

public partial class TheChase : ContentPage
{
    string Player1;
    private int cashBuilder = 0;
    public TheChase()
    {
        InitializeComponent();
    }
    private async void HigherOffer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HigherOffer());
    }
    private async void MiddleOffer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MiddleOffer());
        middleOfferButton.Text = $"CashBuilder: {cashBuilder}";
    }

    private async void LowerOffer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LowerOffer());
    }

}