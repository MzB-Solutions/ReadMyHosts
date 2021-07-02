using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ReadMyHosts.Views
{
    public class HostListView : UserControl
    {
        #region Public Constructors

        public HostListView()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        #endregion Private Methods
    }
}
