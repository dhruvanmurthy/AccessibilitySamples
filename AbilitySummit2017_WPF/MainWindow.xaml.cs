using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
            StatusButton.Text = "Hello Narrator ";

            // ACCESSIBILITY BUG FIX:
            // Note: WPF does not support LiveRegions and so Narrator will not announce
            // the above change made to the static label. One option here would be to 
            // pop up a message conveying the current status. Instead, for this demo, 
            // set the UIA ItemStatus property of the button to be the current status.

            //this line of code Works Correctly in the this App.(modified and checked)
            //like the below line We have added the same to our WaterMark.xaml ,but change not replicated 
            // Shelveset User Name : V-SUNKAN
            // Shelveset  Name : Loading_Narrator_KarthickNadarajan. 

            AutomationProperties.SetItemStatus(ProcessButton, StatusButton.Text); 

            //Below snippet not working. given by alan ren.
            try
            {
                if (typeof(Label).GetProperties().Any((property) =>
                {
                    return property.Name == "LiveSetting";
                }))
                {
                    Type liveSettingEnum = typeof(Label).Assembly.GetTypes().First((type) => { return type.Name == "AutomationLiveSetting"; });
                    var values = Enum.GetValues(liveSettingEnum);
                    object enumValue = null;
                    foreach (object val in values)
                    {
                        if (val.ToString() == "Polite")
                        {
                            enumValue = val;
                            break;
                        }
                    }
                    typeof(Label).InvokeMember("LiveSetting", BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, Type.DefaultBinder, "Narrator Reading Snippet Label", new object[] { enumValue });
                }
            }
            catch(Exception ex)
            {

            }
           
        }

        private void doubleclick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (typeof(Label).GetProperties().Any((property) =>
                {
                    return property.Name == "LiveSetting";
                }))
                {
                    Type liveSettingEnum = typeof(Label).Assembly.GetTypes().First((type) => { return type.Name == "AutomationLiveSetting"; });
                    var values = Enum.GetValues(liveSettingEnum);
                    object enumValue = null;
                    foreach (object val in values)
                    {
                        if (val.ToString() == "Polite")
                        {
                            enumValue = val;
                            break;
                        }
                    }
                    typeof(Label).InvokeMember("LiveSetting", BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, Type.DefaultBinder, MyLabel, new object[] { enumValue });
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
