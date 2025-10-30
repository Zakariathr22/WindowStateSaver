using Microsoft.UI.Xaml;
using WindowStateSaver.Helpers;

namespace WindowStateSaver;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (Content is FrameworkElement content)
        {
            content.Loaded += (_, _) => WindowStateHelper.ApplySavedState(this);
        }

        Closed += (_, _) => WindowStateHelper.Save(this);
    }
}
