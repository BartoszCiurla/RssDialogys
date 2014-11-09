using System;
using System.Windows.Forms;
using RssDialogys.WinFormsUI.SaveAppSettings;

namespace RssDialogys.WinFormsUI
{
    public partial class OptionsForm : Form
    {
        private SettingsEngine settings;
        public OptionsForm()
        {
            InitializeComponent();
            maskedTextBox1.DataBindings.Add("Text", trackBar1, "Value");
            settings = new SettingsEngine();
            settings.ApplySettings(trackBar1,win8ToggleSwitch1,win8ToggleSwitch2,win8ToggleSwitch3,win8ToggleSwitch4);

        }
  
        private void TemporarySave(object sender, EventArgs e)
        {
            settings.TimerInterval = trackBar1.Value;
            settings.UpdateAfterLoad = win8ToggleSwitch1.IsChecked;
            settings.ShowDataAfterUpdate = win8ToggleSwitch2.IsChecked;
            settings.ShowDialogys = win8ToggleSwitch3.IsChecked;
            settings.ShowRssChannel = win8ToggleSwitch4.IsChecked;
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.SaveSettings();
        }

    }
}
