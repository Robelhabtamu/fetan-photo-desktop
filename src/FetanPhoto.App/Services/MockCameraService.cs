namespace FetanPhoto.App.Services;

public sealed class MockCameraService : ICameraService
{
    public bool IsConnected { get; private set; }

    public Task ConnectAsync()
    {
        IsConnected = true;
        return Task.CompletedTask;
    }

    public Task<string> CaptureAsync()
    {
        if (!IsConnected)
            throw new InvalidOperationException("Camera is not connected.");

        var folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
            "FetanPhoto",
            "Captures"
        );

        Directory.CreateDirectory(folder);

        var path = Path.Combine(folder, $"capture-{DateTime.Now:yyyyMMdd-HHmmss}.jpg");
        File.WriteAllBytes(path, Array.Empty<byte>());

        return Task.FromResult(path);
    }
}
