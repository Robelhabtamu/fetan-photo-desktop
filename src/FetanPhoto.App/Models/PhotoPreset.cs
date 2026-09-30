namespace FetanPhoto.App.Models;

public sealed record PhotoPreset(
    string Name,
    double WidthMm,
    double HeightMm,
    int DefaultCopies,
    string Background
);
