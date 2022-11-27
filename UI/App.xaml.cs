using System.Windows;

namespace UI
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new View.ContentView().Show();
        }
    }
}
