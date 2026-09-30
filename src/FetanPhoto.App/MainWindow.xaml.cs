using System.Windows;
using FetanPhoto.App.Models;
using FetanPhoto.App.Services;

namespace FetanPhoto.App;

public partial class MainWindow : Window
{
    private readonly ICameraService _camera = new MockCameraService();
    private PhotoPreset? _selectedPreset;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void SelectPreset(PhotoPreset preset)
    {
        _selectedPreset = preset;
        SelectedPresetText.Text = preset.Name;
        HomePanel.Visibility = Visibility.Collapsed;
        ReviewPanel.Visibility = Visibility.Collapsed;
        PrintPanel.Visibility = Visibility.Collapsed;
        CapturePanel.Visibility = Visibility.Visible;
    }

    private void Passport_Click(object sender, RoutedEventArgs e) =>
        SelectPreset(new PhotoPreset("Passport", 35, 45, 8, "White"));

    private void Visa_Click(object sender, RoutedEventArgs e) =>
        SelectPreset(new PhotoPreset("Visa", 35, 45, 8, "White"));

    private void Id_Click(object sender, RoutedEventArgs e) =>
        SelectPreset(new PhotoPreset("ID Photo", 30, 40, 8, "White"));

    private void ThreeByFour_Click(object sender, RoutedEventArgs e) =>
        SelectPreset(new PhotoPreset("3 × 4", 30, 40, 8, "White"));

    private void Cv_Click(object sender, RoutedEventArgs e) =>
        SelectPreset(new PhotoPreset("CV / Profile", 40, 50, 4, "White"));

    private void Custom_Click(object sender, RoutedEventArgs e) =>
        SelectPreset(new PhotoPreset("Custom", 35, 45, 8, "White"));

    private async void ConnectCamera_Click(object sender, RoutedEventArgs e)
    {
        await _camera.ConnectAsync();
        CameraStatusText.Text = "Camera: connected (mock)";
    }

    private async void Capture_Click(object sender, RoutedEventArgs e)
    {
        if (!_camera.IsConnected)
        {
            MessageBox.Show(
                "Connect the camera first.",
                "Fetan Photo",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
            return;
        }

        await _camera.CaptureAsync();

        CapturePanel.Visibility = Visibility.Collapsed;
        ReviewPanel.Visibility = Visibility.Visible;
    }

    private void BackToHome_Click(object sender, RoutedEventArgs e) => ShowHome();

    private void Retake_Click(object sender, RoutedEventArgs e)
    {
        ReviewPanel.Visibility = Visibility.Collapsed;
        CapturePanel.Visibility = Visibility.Visible;
    }

    private void ContinueToPrint_Click(object sender, RoutedEventArgs e)
    {
        if (_selectedPreset is null)
            return;

        PrintSummaryText.Text =
            $"{_selectedPreset.Name}\n" +
            $"{_selectedPreset.WidthMm:0.#} × {_selectedPreset.HeightMm:0.#} mm • " +
            $"{_selectedPreset.DefaultCopies} copies • {_selectedPreset.Background} background";

        ReviewPanel.Visibility = Visibility.Collapsed;
        PrintPanel.Visibility = Visibility.Visible;
    }

    private void NewCustomer_Click(object sender, RoutedEventArgs e) => ShowHome();

    private void ShowHome()
    {
        _selectedPreset = null;
        CapturePanel.Visibility = Visibility.Collapsed;
        ReviewPanel.Visibility = Visibility.Collapsed;
        PrintPanel.Visibility = Visibility.Collapsed;
        HomePanel.Visibility = Visibility.Visible;
    }
}
