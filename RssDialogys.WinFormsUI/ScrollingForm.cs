using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RssDialogys.Domain.Entities;

namespace RssDialogys.WinFormsUI
{
    public partial class ScrollingForm : Form
    {
        private bool _checkMouseDown;
        private Point _oldPoint;
        private int _formWidth;
        private int _scroolHeight = 1;
        private int _scroolLabelPositionY = 4;
        private int _scroolLabelFontSize = 30;
        private Label _scroolLabel1;
        private Label _scroolLabel2;

        public int ItemTakenCounter = 0;
        public List<Item> Feeds;

        //potrzebny mechanizm ktory wypelnie tekstem labelke ...
        private void ApendTextToNewLabel(Label scroolLabel)
        {
            //tutaj oczywiście można by to jakoś lepiej rozwiązac , ale czasu nie mam PROBLEMEM JEST TO ZE ZBYT SZYBKO JEST ZAMYKANY CALY FORM 
            if (ItemTakenCounter == Feeds.Count)
            { 
                Close();
            }
            else if (scroolLabel.Text == "")
            {
                scroolLabel.Text = @"""" + Feeds[ItemTakenCounter].Title + @""""+ @" : " + Feeds[ItemTakenCounter].Content + @" ";
                ItemTakenCounter++;
            }         
        }

        public ScrollingForm(List<Item> feedsList)
        {
            InitializeComponent();
            Feeds = feedsList;
            //pobieram szerokośc glownego ekranu i inicjalizuje nim forma 
            Location = new Point(0, Screen.PrimaryScreen.WorkingArea.Bottom - Height);
            Width = Screen.PrimaryScreen.Bounds.Width;
            TopMost = true;
            panel1.Width = Width;
            _formWidth = Width;
            _scroolLabel1 = CreateLabel();
        }

        private Label CreateLabel()
        {
            //dynamiczne tworzenie i formatowanie labelki 
            var scrolingLabel = new Label();
            scrolingLabel.Location = new Point(_formWidth, _scroolLabelPositionY);
            scrolingLabel.Font = new Font("Segoe UI",_scroolLabelFontSize, FontStyle.Bold);
            scrolingLabel.AutoSize = true;
            scrolingLabel.ForeColor = Color.White;
            //nie testowane , ale na 90 nie bedzie problemu 
            scrolingLabel.DoubleClick += (sender, args) => Close();
            //wypelnienie tabelki odpowiednią treścią 
            ApendTextToNewLabel(scrolingLabel);
            //dodanie labelki do controlsow , inaczej nie byla by widoczna ;)
            Controls.Add(scrolingLabel);
            return scrolingLabel;
        }

        //napisanie tego zajeło mnustwo czasu ale udalo sie dziala bardzo dobrze ;)
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
            //ten form jest tylko po to zeby przyspieszyc efekt scroola 
            //sprawdzalem wszystkie mozliwośći i najbardziej czystelne sa takie ustawienia time interval powyzej 1 nei sprawdza sie zbyt dobrze czym mniejszy tym lepiej
            //szkoda ze 1 to minimum ...
            for (int i = 0; i < 2; i++)
            {
                //za kazdym razem sprawdzam czy labelka nie jest nullem , jak jest to oczywiście znaczy ze jej zycie juz sie skonczylo tzn zrobila swoje i teraz czeka az 
                //obecna labelka czyli druga skonczy swoj zywot 
                if (_scroolLabel1 != null)
                {
                    //manipuluje odlegloscia labelki od lewej strony parenta , jedyne sluszne wyjscie .Jest jeszcze opcja rysowania ale mysle ze ten efekt jest dosc dobry 
                    _scroolLabel1.Left -= _scroolHeight;
                    //jesli odleglosc poczatku labelki + miara przesunecia + 1 jest mniejsza od szerookści formy to tworze nowa labelke 
                    //czyli w sytuacji gdy caly tekst jest na formie wpuszczam nastepna labelke proste jak drut
                    if (_scroolLabel1.Right + _scroolHeight + 1 < _formWidth)
                    {
                        //weryfikacja , bo moze byc sytuacja ze labelka 2 jeszcze spelnai swoja funkcje . Dodanie nowej labelki i oczywiście refresh 
                        if (_scroolLabel2 == null)
                        {
                            _scroolLabel2 = CreateLabel();
                            Refresh();
                        }
                    }
                    //w sumie to zastanawiam sie jak to moze dzialac .Jestem przekonany ze jak sie pojawi tekst ktory bedzie 2 razy wiekszy od szerokosci formy to sie posypie
                    //jesli faktycznie tak bedzie to hmm scroolLabel1.Right + scroolLabel1.Width < 0 moze taki warunek 
                    if (_scroolLabel1.Right < 0)
                    {
                        Controls.Remove(_scroolLabel1);
                        _scroolLabel1 = null;
                        Refresh();
                    }
                }
                //analogicznie 
                if (_scroolLabel2 != null)
                {
                    _scroolLabel2.Left -= _scroolHeight;
                    if (_scroolLabel2.Right + _scroolHeight + 1 < _formWidth)
                    {
                        if (_scroolLabel1 == null)
                        {
                            _scroolLabel1 = CreateLabel();
                            Refresh();
                        }
                    }
                    //scroolLabel1.Right + scroolLabel1.Width < 0 moze taki warunek w razie blędów 
                    if (_scroolLabel2.Right < 0)
                    {
                        Controls.Remove(_scroolLabel2);
                        _scroolLabel2 = null;
                        Refresh();
                    }
                }
            }
        }

        //przesuwanie apki 
        private void PF_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _checkMouseDown = true;
                _oldPoint = new Point(e.X, e.Y);
            }
            else
            {
                _checkMouseDown = false;
            }
        }

        private void PF_MouseMove(object sender, MouseEventArgs e)
        {
            if (_checkMouseDown)
            {
                Point pointMoveTo;
                pointMoveTo = PointToScreen(new Point(e.X, e.Y));
                pointMoveTo.Offset(-_oldPoint.X, -_oldPoint.Y);
                Location = pointMoveTo;
            }
        }

        private void PF_MouseUp(object sender, MouseEventArgs e)
        {
            _checkMouseDown = false;
        }

        public void ScrollingForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }

    }
}
