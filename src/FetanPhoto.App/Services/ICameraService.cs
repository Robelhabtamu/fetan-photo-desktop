namespace FetanPhoto.App.Services;

public interface ICameraService
{
    bool IsConnected { get; }
    Task ConnectAsync();
    Task<string> CaptureAsync();
}
