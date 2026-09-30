# Fetan Photo Desktop

Simple Windows desktop application for REDBOOTH's Fetan Photo operator workflow.

## V1 goal

Select photo type → capture → review → print.

## Stack

- C#
- .NET 8
- WPF
- MVVM
- Camera integration abstraction (Canon SDK later)
- OpenCV / ONNX later for automated processing
- SQLite later for local records

## Current milestone

Milestone 1 builds the application shell and operator workflow with a mock camera service so the UI can be developed before the Canon SDK is wired in.

### Screens
- Home / photo type selection
- Capture
- Review
- Print placeholder

## Run

1. Install Visual Studio with **.NET desktop development**.
2. Open `FetanPhoto.sln`.
3. Build and run the `FetanPhoto.App` project.

## Next milestones

1. Canon live view and capture
2. Face detection + auto crop
3. 10×15 print sheet generation
4. Direct printer integration
5. Configurable photo presets
