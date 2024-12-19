namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaServiceMedium : ContentPage
{
	public TriviaServiceMedium()
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