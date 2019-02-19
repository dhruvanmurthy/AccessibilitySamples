using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;

namespace AbilitySummit2017_BugWorkshop
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // ACCESSIBILITY BUG FIX:
            // Set the descriptive information on the phone field from the nearby error string.
            var describedBy = AutomationProperties.GetDescribedBy(PhoneField);

            describedBy.Add(PhoneFieldDescription);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Show an error string near the phone field.
            PhoneFieldDescription.Visibility = Visibility.Visible;

            // Move the customer to the problem field.
            PhoneField.Focus(FocusState.Programmatic);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NameField.Text = "";
            PhoneField.Text = "";
            EmailField.Text = "";

            PhoneFieldDescription.Visibility = Visibility.Collapsed;

            var describedBy = AutomationProperties.GetDescribedBy(PhoneField);
            describedBy.Clear();
        }

        private void MyAnimalList_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Delete)
            {
                DeleteSelectedItem();
            }
        }

        private void DeleteSelectedItem()
        {
            if (MyAnimalList.SelectedItem != null)
            {
                MyAnimalList.Items.Remove(MyAnimalList.SelectedItem);

                if (MyAnimalList.Items.Count > 0)
                {
                    MyAnimalList.SelectedIndex = 0;
                }
                else
                {
                    EmptyListLabel.Visibility = Visibility.Visible;

                    // ACCESSIBILITY BUG FIX:
                    // Allow the keyboard focus to remain on the empty list, so that the customer using
                    // a screen reader knows immediately that the list is empty. So set the label just 
                    // made visible to be the list's FullDescription, so that that also gets announced.

                    MyAnimalList.IsTabStop = true;

                    AutomationProperties.SetFullDescription(MyAnimalList, EmptyListLabel.Text);
                }

                MyAnimalList.Focus(FocusState.Programmatic);
            }
        }

        private void ListViewItem_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            MyAnimalList.SelectedItem = item;

            MyMenuFlyout.ShowAt(item, e.GetPosition(item));
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedItem();
        }
    }
}
