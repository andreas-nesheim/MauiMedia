using Plugin.Media;

namespace MauiMedia;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		var result = await CrossMedia.Current.PickPhotoAsync();
		var stuff = 1;
	}
}

