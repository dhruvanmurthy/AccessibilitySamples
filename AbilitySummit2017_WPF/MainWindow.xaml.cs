using System.Windows;
using System.Windows.Automation;

namespace AbilitySummit2017_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Note: WPF apps can create custom AutomationPeers to enhance the 
        // accessibility of their UI. 

        // Note: All text exposed programmatically must be as localized as
        // text displayed visually.

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            StatusButton.Text = "Sorry Im a Narrator.";

            // ACCESSIBILITY BUG FIX:
            // Note: WPF does not support LiveRegions and so Narrator will not announce
            // the above change made to the static label. One option here would be to 
            // pop up a message conveying the current status. Instead, for this demo, 
            // set the UIA ItemStatus property of the button to be the current status.
            AutomationProperties.SetItemStatus(ProcessButton, StatusButton.Text);
        }
    }
}
