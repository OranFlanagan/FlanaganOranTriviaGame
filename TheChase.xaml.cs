namespace FlanaganOranTriviaGame;

public partial class TheChase : ContentPage
{
    public TheChase()
    {
        InitializeComponent();
    }
    //Calls HigherOffer once the £150,000 button is clicked
    private async void HigherOffer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HigherOffer());
    }
    //Calls MiddleOffer once the button with Whatever was made in the cash builder round
    private async void MiddleOffer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MiddleOffer());
    }
    //Calls LowerOffer once the minus button is clicked
    private async void LowerOffer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LowerOffer());
    }

}