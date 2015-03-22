using System.Windows;
using System.Windows.Input;

using ReflectSoftware.Insight;

namespace Watches_Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = e.GetPosition(this);
            RILogManager.Default.ViewerSendWatch("Mouse Position", "({0},{1})", mousePoint.X, mousePoint.Y);         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // This will clear Watches in the viewer
            RILogManager.Default.ViewerClearWatches();
        }
    }
}
