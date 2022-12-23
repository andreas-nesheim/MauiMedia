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

        UploadedOrSelectedImage.Source = result?.Path;
    }

    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        var options = new StoreCameraMediaOptions { CompressionQuality = 0 };
        var result = await CrossMedia.Current.TakePhotoAsync(options);

        UploadedOrSelectedImage.Source = result?.Path;

        // CompressionQuality 0: File.Length = 82050 = 82 kB

        // CompressionQuality 100: File.Length = 2398282 = 2398 kb = 2,4 MB

        var fileInfo = new FileInfo(result?.Path);
        var fileLength = fileInfo.Length;

        FileSizeLabel.Text = $"Image size: {fileLength / 1000} kB";
    }
}

