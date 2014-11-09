using System.Linq;
using System.Xml.Linq;
using Binarymission.WinForms.Controls.ToggleControls;
using System.Windows.Forms;
using RssDialogys.Domain.Concrete;


namespace RssDialogys.WinFormsUI.SaveAppSettings
{
    public class SettingsEngine
    {
        private XElement _xmlRoot;
        public int TimerInterval { get; set; }
        public bool UpdateAfterLoad { get; set; }
        public bool ShowDataAfterUpdate { get; set; }
        public bool ShowDialogys { get; set; }
        public bool ShowRssChannel { get; set; }

        public SettingsEngine()
        {
             XElementLoad();
             GetSettings();
        }
        public void GetSettings()
        {
            var query = _xmlRoot.Descendants("Settings").Where(x=>x.Element("id").Value == 1.ToString());
                      
            foreach (var xElement in query)
            {
                TimerInterval = int.Parse(xElement.Element("TimerInterval").Value);
                UpdateAfterLoad = bool.Parse(xElement.Element("UpdateAfterLoad").Value);
                ShowDataAfterUpdate = bool.Parse(xElement.Element("ShowDataAfterUpdate").Value);
                ShowDialogys = bool.Parse(xElement.Element("ShowDialogys").Value);
                ShowRssChannel = bool.Parse(xElement.Element("ShowRssChannel").Value);
            }
        }
        private void XElementLoad()
        {
            _xmlRoot = XElement.Load(@".\..\\..\SaveAppSettings\RssDialogysSettings.xml");

        }

        public void SaveSettings()
        {
            var updateQuery = _xmlRoot.Descendants("Settings");
            foreach (var xElement in updateQuery)
            {
                xElement.Element("TimerInterval").Value = TimerInterval.ToString();
                xElement.Element("UpdateAfterLoad").Value = UpdateAfterLoad.ToString();
                xElement.Element("ShowDataAfterUpdate").Value = ShowDataAfterUpdate.ToString();
                xElement.Element("ShowDialogys").Value = ShowDialogys.ToString();
                xElement.Element("ShowRssChannel").Value = ShowRssChannel.ToString();
            }
            NlogEngine.logger.Trace("RssDialogys.WinFormsUI.SaveAppSettings.SaveSetting");
            _xmlRoot.Save(@".\..\\..\SaveAppSettings\RssDialogysSettings.xml");
        }

        public void ApplySettings(TrackBar timerInterval,Win8ToggleSwitch updateAfterLoad,Win8ToggleSwitch showDataAfterUpdate,Win8ToggleSwitch showDialogys,Win8ToggleSwitch showRssChannel )
        {
            timerInterval.Value = TimerInterval;
            updateAfterLoad.IsChecked = UpdateAfterLoad;
            showDataAfterUpdate.IsChecked = ShowDataAfterUpdate;
            showDialogys.IsChecked = ShowDialogys;
            showRssChannel.IsChecked = ShowRssChannel;
            NlogEngine.logger.Trace("RssDialogys.WinFormsUI.SaveAppSettings.ApplySettings");
        }
    }
}
