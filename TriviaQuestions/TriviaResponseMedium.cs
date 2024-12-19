namespace FlanaganOranTriviaGame.TriviaQuestions;

public class TriviaResponseMedium : ContentPage
{
	public TriviaResponseMedium()
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