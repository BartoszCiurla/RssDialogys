using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RssDialogys.Domain.Abstract;
using RssDialogys.WinFormsUI.RssEngine;
using RssDialogys.Domain.Concrete;
using RssDialogys.Domain.Entities;
using RssDialogys.WinFormsUI.SaveAppSettings;
using RssDialogys.WinFormsUI.Animations;

namespace RssDialogys.WinFormsUI
{
    public partial class ShadowForm : Form
    {
        private List<Item> repoRecords = new List<Item>();
        private IFeedDataRepository repository;
        private Form _secendForms;
        public ShadowForm()
        {
            InitializeComponent();
            repository = new FeedDataRepository();
            SettingsEngine tempSettings = new SettingsEngine();
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, Screen.PrimaryScreen.WorkingArea.Bottom  - Height - 56); // to jest wymiar scrooling formy nie chce zeby na siebie nachodziły 
            TopMost = true;
            timerForDownload.Interval = tempSettings.TimerInterval*60000;
            timerForDownload.Enabled = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //do przebudowy     nie bedzie czasu na to ... a mozna by tam cos fajnego wymyslic 
            string title = "Aktualna data: " + DateTime.Today.ToLongDateString();
            title += "\nDzień tygodnia: " + DateTime.Now.DayOfWeek;
            title += "\nDzień roku: " + DateTime.Now.DayOfYear;
            title += "\n(c) pechowa ławka ...";
            //bedzie trzeba jeszcze dodac czas do nastepnego updata 
            notifyIcon1.BalloonTipText = title;
            notifyIcon1.ShowBalloonTip(20 * 1000);
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIcon1.Text = @"RssDialogys";
        }

        private void timerForDownload_Tick(object sender, EventArgs e)
        {
            //aby dobrze to działało trzeba podjąc decyzje w ktorym momencie będzie szedł update na Interval przed czy po pobraniu .
            Opacity = 100;
            SettingsEngine tempSettings = new SettingsEngine();
            timerForDownload.Interval = tempSettings.TimerInterval * 60000;
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void raportTSMI_Click(object sender, EventArgs e)
        {
            if (SecondFormsCheck(_secendForms))
            {
                //to jest najglupsze mozliwe rozwiazanie , ale nie mam czasu zeby cos lepszego tutaj wprowadzić 
                _secendForms = new RaportsForm(repoRecords);
                FormTransform.Animate(_secendForms, AnimateStyle.FadeIn);
                _secendForms = null;
                
            }
        }

        private void opcjeTSMI_Click(object sender, EventArgs e)
        {
            if (SecondFormsCheck(_secendForms))
            {
                _secendForms = new OptionsForm();
                FormTransform.Animate(_secendForms,AnimateStyle.FadeIn);
                _secendForms = null;
                if (!backgroundWorker1.IsBusy)
                {
                    timerForDownload.Enabled = false;
                    SettingsEngine tempSettings = new SettingsEngine();
                    timerForDownload.Interval = tempSettings.TimerInterval * 60000;
                    timerForDownload.Enabled = true;
                }         
            }
        }

        private void zakmnijTSMI_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Close();
        }

        public Dictionary<string, string> GetRssFeedsDictionary()
        {
            return new Dictionary<string, string>
            {
                {"Fakty","http://interia.pl.feedsportal.com/c/34004/f/618045/index.rss"},
                {"Świat","http://interia.pl.feedsportal.com/c/34004/f/625098/index.rss"},
                {"Kultura","http://interia.pl.feedsportal.com/c/34004/f/650424/index.rss"},
                {"Nauka","http://interia.pl.feedsportal.com/c/34004/f/650426/index.rss"},
                {"Ciekawostki","http://interia.pl.feedsportal.com/c/34004/f/625100/index.rss"},
                {"Sport","http://interia.pl.feedsportal.com/c/34004/f/625088/index.rss"},
                {"Kobieta","http://interia.pl.feedsportal.com/c/34004/f/625123/index.rss"},
                {"Facet","http://interia.pl.feedsportal.com/c/34004/f/629189/index.rss"},
                {"Gry","http://interia.pl.feedsportal.com/c/34004/f/625120/index.rss"},
                {"Motoryzacja","http://interia.pl.feedsportal.com/c/34004/f/625092/index.rss"},
                {"Nowe technologie","http://interia.pl.feedsportal.com/c/34004/f/625109/index.rss"}
            };
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FeedParser parser = new FeedParser();
            int feedsQuantity = GetRssFeedsDictionary().Count();
            int currentFor = 0;
            foreach (KeyValuePair<string, string> keyValuePair in GetRssFeedsDictionary())
            {
                repository.SaveFeedsData(parser.Parse(keyValuePair.Key,keyValuePair.Value));
                int percentage = (currentFor + 1)*100/feedsQuantity;
                backgroundWorker1.ReportProgress(percentage);
                if (percentage == 100)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                currentFor++;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressTxt.Text = e.ProgressPercentage + @" %";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Opacity = 0;
            SettingsEngine tempSettings = new SettingsEngine();
            if (tempSettings.ShowDataAfterUpdate)
            {
                //w sumie to nie mam pomyslu co miało by się znajdować w tym raporcie przynajmniej puki co 
                raportTSMI_Click(sender, e);
            }
        }
        public bool SecondFormsCheck(Form secForms)
        {
            return secForms == null;
        }

        //tutaj musi być jeszcze jedna zmiana tzn musi sie wyzerować progres bar bo ustawia sie na 100 przy kolejnym updacie a ja sie na takie zachowanie nie bede godził 
        private void updateTSMI_Click(object sender, EventArgs e)
        {
            if(!backgroundWorker1.IsBusy)
            {
                timerForDownload.Enabled = false;
                timerForDownload.Interval = 1;
                timerForDownload.Enabled = true;
            }
        }

        private void wiadomościTSMI_Click(object sender, EventArgs e)
        {
            if (SecondFormsCheck(_secendForms))
            {
                _secendForms = new PresentationForm();
                FormTransform.Animate(_secendForms,AnimateStyle.FadeIn);
                _secendForms = null;
            }

        }
    }
}
