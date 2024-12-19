namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseCashBuilder : ContentPage
{
	public TriviaResponseCashBuilder()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}