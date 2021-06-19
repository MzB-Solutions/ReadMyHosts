using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ReadMyHosts.Views
{
    public partial class HostListView : UserControl
    {
        public HostListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}