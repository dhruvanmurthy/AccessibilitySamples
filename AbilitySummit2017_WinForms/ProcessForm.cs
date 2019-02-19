using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbilitySummit2017_WinForms
{
    public partial class ProcessForm : Form
    {
        // Note: Beware that if you set the accessible name of a WinForm control in the Properties
        // pane in VS and then remove the name, VS leaves the name set as "". As such, a regular 
        // button showing text will have lost its default accessible name.

        // Note: After creating your WinForm UI in VS, and then changing the tab order with the 
        // "Tab Order" tool, verify that order of the elements exposed through the UIA API makes
        // sense to the customer. Just because the tab order might be appropriate, does not mean
        // that the order of the element exposed through UIA is as it should be. If the programmatic
        // order needs updating, change the order in which the controls are added to the form.

        public ProcessForm()
        {
            InitializeComponent();
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            // Note: While setting the AccessibleDescription of the control leads to the MSAA data
            // for for the control being updated, that change does not get propagated through the 
            // UIA API to clients such as Narrator. So do not use AccessibleDescription. In fact, 
            // MSDN states: "Pitfall: Do Not Use AccDescription".
            // https://msdn.microsoft.com/en-us/windows/desktop/gg712256.aspx 

            // Note: The Accessibility namespace suggest that IAccPropServices can be used 
            // in a WinForms app in a similar way to how it can be used in a Win32 app. 
            // GuyBark: I can't get this to work. Maybe my GetRemotableHandle() is no good?

            var services = new Accessibility.CAccPropServices();

            Accessibility._RemotableHandle rApp = GetRemotableHandle(buttonProcess.Handle);

            Guid HelpText_Property_GUID = new Guid(
                0x08555685, 0x0977, 0x45c7, 0xa7, 0xa6, 0xab, 0xaf, 0x56, 0x84, 0x12, 0x1a);

            // This doesn't work.
            services.SetHwndPropStr(
                ref rApp,
                0xFFFFFFFC, // OBJID_CLIENT
                0, // CHILDID_SELF
                HelpText_Property_GUID,
                "Some localized helpful test");
        }

        private Accessibility._RemotableHandle GetRemotableHandle(IntPtr handle)
        {
            IntPtr address = Marshal.AllocHGlobal(IntPtr.Size);

            Marshal.WriteIntPtr(address, handle);

            return (Accessibility._RemotableHandle)Marshal.PtrToStructure(address, typeof(Accessibility._RemotableHandle));
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            // For this demo, simply present from failure string.
            labelStatus.Text = "Sorry, data processing is unavailable.";

            // ACCESSIBILITY BUG FIX:
            // We need to have this failure message announced by a screen reader. Other types 
            // of apps might be able to leverage LiveRegions here, but LiveRegions are not 
            // available in WinForms apps. One option here would be to update the Button's 
            // Help property to incorporate the new status information. But in the interests 
            // of keeping this simple, pop up a message indicating what just happened.

            //MessageBox.Show(this,
            //    labelStatus.Text,
            //    "Process data",
            //    MessageBoxButtons.OK);
        }
    }

    // ACCESSIBILITY BUG FIX:
    // Create a custom button to have helpful descriptive information programmatically accessible. In
    // this example, the Help text is set from a text label passed into the control when it's created.
    class MyProcessButton : Button
    {
        public Label labelStatus;

        public MyProcessButton(Label labelStatus)
        {
            this.labelStatus = labelStatus;
        }

        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return new MyButtonBaseAccessibleObject(this);
        }

        public class MyButtonBaseAccessibleObject : ButtonBaseAccessibleObject
        {
            MyProcessButton owner;

            public MyButtonBaseAccessibleObject(MyProcessButton owner) : base(owner)
            {
                this.owner = owner;
            }

            public override string Help
            {
                get
                {
                    return this.owner.labelStatus.Text;
                }
            }
        }
    }

}
