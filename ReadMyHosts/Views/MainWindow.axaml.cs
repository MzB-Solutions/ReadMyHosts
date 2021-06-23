using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ReadMyHosts.Views
{
    public partial class MainWindow : Window
    {
        #region Public Constructors

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
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
