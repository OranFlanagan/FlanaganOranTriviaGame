namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseEasy : ContentPage
{
	public TriviaResponseEasy()
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