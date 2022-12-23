using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MauiMedia;

public partial class MainPage : ContentPage
{
    private int selectedCompressionQuality;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnPickPhotoClicked(object sender, EventArgs e)
    {
        var result = await CrossMedia.Current.PickPhotoAsync();
        if (result is null) return;

        UploadedOrSelectedImage.Source = result?.Path;

        var fileInfo = new FileInfo(result?.Path);
        var fileLength = fileInfo.Length;

        FileSizeLabel.Text = $"Image size: {fileLength / 1000} kB";
    }

    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        var options = new StoreCameraMediaOptions { CompressionQuality = selectedCompressionQuality };
        var result = await CrossMedia.Current.TakePhotoAsync(options);
        if (result is null) return;

        UploadedOrSelectedImage.Source = result?.Path;

        var fileInfo = new FileInfo(result?.Path);
        var fileLength = fileInfo.Length;

        FileSizeLabel.Text = $"Image size: {fileLength / 1000} kB";
    }

    private void Slider_DragCompleted(object sender, EventArgs e)
    {
        selectedCompressionQuality = (int)((sender as Slider).Value * 100);
        CompressionLabel.Text = $"Compression: {selectedCompressionQuality}";
    }
}

