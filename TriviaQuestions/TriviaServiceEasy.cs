namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaServiceEasy : ContentPage
{
	public TriviaServiceEasy()
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