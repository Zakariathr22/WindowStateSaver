using Microsoft.Windows.Storage;
using WindowStateSaver.Models;

namespace WindowStateSaver.Services;

public static class WindowStateService
{
    private static readonly ApplicationDataContainer Local = ApplicationData.GetDefault().LocalSettings;

    public static void Save(WindowState state)
    {
        Local.Values["MainWindowPositionX"] = state.PositionX;
        Local.Values["MainWindowPositionY"] = state.PositionY;
        Local.Values["MainWindowWidth"] = state.Width;
        Local.Values["MainWindowHeight"] = state.Height;
        Local.Values["MainWindowScale"] = state.Scale;
        Local.Values["IsMainWindowMaximized"] = state.IsMaximized;
    }

    public static WindowState? Load()
    {
        if (!(
            Local.Values.TryGetValue("MainWindowWidth", out var wObj) &&
            Local.Values.TryGetValue("MainWindowHeight", out var hObj) &&
            Local.Values.TryGetValue("MainWindowPositionX", out var xObj) &&
            Local.Values.TryGetValue("MainWindowPositionY", out var yObj) &&
            Local.Values.TryGetValue("MainWindowScale", out var sObj)
        )) return null;

        return new WindowState
        {
            PositionX = (int)xObj,
            PositionY = (int)yObj,
            Width = (int)wObj,
            Height = (int)hObj,
            Scale = (double)sObj,
            IsMaximized = Local.Values.TryGetValue("IsMainWindowMaximized", out var maxObj) && (bool)maxObj
        };
    }
}
