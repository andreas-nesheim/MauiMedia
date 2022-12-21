using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MauiMedia;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnPickPhotoClicked(object sender, EventArgs e)
    {
        var result = await CrossMedia.Current.PickPhotoAsync();
        var stuff = 1;
    }

    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        var result = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions { CompressionQuality = 50 });
        var stuff = 1;
    }
}

