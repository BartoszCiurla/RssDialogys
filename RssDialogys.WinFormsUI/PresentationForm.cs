using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using RssDialogys.Domain.Abstract;
using RssDialogys.Domain.Concrete;
using RssDialogys.Domain.Entities;
using RssDialogys.WinFormsUI.Animations;

namespace RssDialogys.WinFormsUI
{
    public partial class PresentationForm : Form
    {
        private IFeedDataRepository feedRepository;
        private IImageRepository imageRepository;
        private List<Item> _feedsForPresentation;
        private ScrollingForm _scrollingF;
        private const int ItemsPerPage = 16;
        private int _page;
        private string _currentCategory;
        private bool _checkMouseDown;
        private Point _oldPoint;

        public int TotalItems
        {
            get { return _currentCategory == null ? feedRepository.GetItems.Count() :feedRepository.GetItems.Count(x => x.Category == _currentCategory); }
        }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
        public PresentationForm()
        {
            InitializeComponent();
            button1.Enabled = false;
            button1.Visible = false;
            feedRepository = new FeedDataRepository();
            imageRepository = new ImageRepository();
            imageRepository.InitializeGetImage();
            InitializeFlpCategories();   
            _feedsForPresentation = feedRepository.GetItems.Take(ItemsPerPage).ToList();
            _page = 1;
            MetroFillItemsFlowLayout(_feedsForPresentation);

        }

        private void MetroFillItemsFlowLayout(List<Item> items)
        {
            flp.Controls.Clear();
            NlogEngine.logger.Trace(
                "RssDialogys.WinFormsUI.PresentationForm.MetroFillItemsFlowLayout count of items = {0}", items.Count);
            for (int i = 0; i < items.Count; i++)
            {
                imageRepository.SetFilesToFileInfos(i,items[i]);
                var pictureBox = new PictureBox();
                pictureBox.Size = new Size(222, 180);
                pictureBox.Image = imageRepository[i];
                pictureBox.Tag = i;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                var textLabel = new Label();
                textLabel.MouseEnter += flpControl_MouseEnter;
                textLabel.MouseLeave += flpControl_MouseLeft;
                textLabel.Tag = i;
                textLabel.Text = items[i].Title;
                textLabel.AutoSize = true;
                textLabel.MaximumSize = new Size(222, 180);
                textLabel.Dock = DockStyle.Bottom;
                textLabel.TextAlign = ContentAlignment.BottomCenter;
                SetLabelSettingsForTittleRead(textLabel);
                textLabel.Parent = pictureBox;
                flp.Controls.Add(pictureBox);
            }
            label17.Text = string.Format("strona {0}/{1}", _page, TotalPages);

        }

        private void MetroFillCategoriesFlowLayout()
        {
            flp.Controls.Clear();
            List<CategoryPubDateQuantity> allinOne = feedRepository.GetCategiesInformations().ToList();
            for (int i = 0; i < allinOne.Count(); i++)
            {
                string currentCategory = allinOne.ElementAt(i).Category;
                int currentCategoryCount = allinOne.ElementAt(i).Quantity;

                //tlo
                var imageForPresentation = new PictureBox();
                imageForPresentation.Size = new Size(222, 180);
                imageRepository.SetRandomFilesToFileInfosForCategory(i,
                    feedRepository.GetImageIdForCategory(currentCategory).ToList(), currentCategoryCount);
                imageForPresentation.Image = imageRepository[i];
                imageForPresentation.SizeMode = PictureBoxSizeMode.StretchImage;
                imageForPresentation.Tag = currentCategory;
                imageForPresentation.MouseClick += flpCategories_ChooseCategory;
                imageForPresentation.MouseEnter += MetroFlpCategories_MouseEnter;
                imageForPresentation.MouseLeave += MetroFlpCategories_MouseLeft;

                //categoria
                var textLabelCategory = new Label();
                textLabelCategory.Tag = currentCategory;
                textLabelCategory.Text = currentCategory;
                textLabelCategory.AutoSize = true;
                textLabelCategory.MaximumSize = new Size(222, 180);
                textLabelCategory.Location = new Point(0, 76);
                textLabelCategory.TextAlign = ContentAlignment.BottomCenter;
                textLabelCategory.ForeColor = Color.White;
                textLabelCategory.Font = new Font("Segoe UI", 17, FontStyle.Bold);
                textLabelCategory.BackColor = Color.FromArgb(190, Color.Black);
                textLabelCategory.MouseClick += flpCategories_ChooseCategory;
                textLabelCategory.Parent = imageForPresentation;
                textLabelCategory.MouseEnter += MetroFlpCategories_MouseEnter;
                textLabelCategory.MouseLeave += MetroFlpCategories_MouseLeft;

                //data publikacji najnowszej wiadomosci
                DateTime pubDateTime = allinOne.ElementAt(i).PubDate;
                var categoryLastUpdate = new Label
                {
                    Text = @"Najnowsze z " + pubDateTime.ToShortTimeString() + @" dnia " + pubDateTime.ToShortDateString()
                };
                categoryLastUpdate.AutoSize = true;
                categoryLastUpdate.MaximumSize = new Size(222, 0);
                categoryLastUpdate.Font = new Font("Segoe UI Light", 10, FontStyle.Bold);
                categoryLastUpdate.Tag = currentCategory;
                categoryLastUpdate.BackColor = Color.FromArgb(190, Color.Black);
                if (pubDateTime < DateTime.Now)
                {
                    categoryLastUpdate.ForeColor = Color.LawnGreen;
                }
                if (pubDateTime < DateTime.Now.AddHours(-12))
                {
                    categoryLastUpdate.ForeColor = Color.Goldenrod;
                }
                if (pubDateTime < DateTime.Now.AddHours(-24))
                {
                    categoryLastUpdate.ForeColor = Color.OrangeRed;
                }
                categoryLastUpdate.Location = new Point(0, 109);
                categoryLastUpdate.MouseClick += flpCategories_ChooseCategory;
                categoryLastUpdate.MouseEnter += MetroFlpCategories_MouseEnter;
                categoryLastUpdate.MouseLeave += MetroFlpCategories_MouseLeft;
                categoryLastUpdate.Parent = imageForPresentation;

                //labelka z iloscia itemow w kategorii
                var categoryQuantity = new Label { Text = @"Ilość " + allinOne.ElementAt(i).Quantity };
                categoryQuantity.ForeColor = Color.FloralWhite;
                categoryQuantity.MouseClick += flpCategories_ChooseCategory;
                categoryQuantity.Dock = DockStyle.Bottom;
                categoryQuantity.AutoSize = true;
                categoryQuantity.Font = new Font("Segoe UI", 17, FontStyle.Bold);
                categoryQuantity.BackColor = Color.FromArgb(190, Color.Black);
                categoryQuantity.Parent = imageForPresentation;
                categoryQuantity.MouseEnter += MetroFlpCategories_MouseEnter;
                categoryQuantity.MouseLeave += MetroFlpCategories_MouseLeft;

                flp.Controls.Add(imageForPresentation);

            }
        }
        private void MetroFlpCategories_MouseEnter(object sender, EventArgs e)
        {
            var box = sender as PictureBox;
            if (box != null)
            {
                var controlPictureBox = box;
                controlPictureBox.Size = new Size(218, 176);
            }
            else
            {
                var label = sender as Label;
                if (label != null)
                {
                    var controlLabel = label;
                    var controlPictureBox = (PictureBox)controlLabel.Parent;
                    controlPictureBox.Size = new Size(218, 176);

                }
            }
        }

        private void MetroFlpCategories_MouseLeft(object sender, EventArgs e)
        {
            var box = sender as PictureBox;
            if (box != null)
            {
                var controlPictureBox = box;
                controlPictureBox.Size = new Size(222, 180);
            }
            else
            {
                var label = sender as Label;
                if (label != null)
                {
                    var controlLabel = label;
                    var controlPictureBox = (PictureBox)controlLabel.Parent;
                    controlPictureBox.Size = new Size(222, 180);
                }
            }
        }

        //bardzo wazne eventy obsluga wyswietlania description 
        private void flpControl_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                //tutaj pobirione w zaleznosci od sendera tag ktory jest rowny indeksowi 
                int controlIndex = 0;   //ustawione na 0 bo inczej po ifach nie moge sie do tego odniesc ciekawe czy to stworzy problemy
                if (sender is PictureBox)
                {
                    var controlPictureBox = (PictureBox)sender;
                    controlIndex = (int)controlPictureBox.Tag;

                }
                else if (sender is Label)
                {
                    var controlLabel = (Label)sender;
                    controlIndex = (int)controlLabel.Tag;
                }
                //majac juz index wystarczy odniesc sie po nim do labelki           
                var labelDescription = GetLabelControl(controlIndex);
                labelDescription.Text = _feedsForPresentation[controlIndex].Content;
                SetLabelSettingsForDescriptionRead(labelDescription);
            }
            catch (ArgumentOutOfRangeException)
            {
                NlogEngine.logger.Fatal(
                    "RssDialogys.WinFormsUI.PresentationForm.flpControl_MouseEnter controlIndex = ArgumentoutOfRangeException");
                //obsluzony , gdzies w wypelnianiu controlsow jest luka i laduje to pustego pola event ... poprawione juz wszystko gra ;)
            }

        }

        private void flpControl_MouseLeft(object sender, EventArgs e)
        {
            try
            {
                int controlIndex = 0;   //ustawione na 0 bo inczej po ifach nie moge sie do tego odniesc ciekawe czy to stworzy problemy
                if (sender is PictureBox)
                {
                    var controlPictureBox = (PictureBox)sender;
                    controlIndex = (int)controlPictureBox.Tag;

                }
                else if (sender is Label)
                {
                    var controlLabel = (Label)sender;
                    controlIndex = (int)controlLabel.Tag;
                }
                //majac juz index wystarczy odniesc sie po nim do labelki           
                var labelTitle = GetLabelControl(controlIndex);
                labelTitle.Text = _feedsForPresentation[controlIndex].Title;
                SetLabelSettingsForTittleRead(labelTitle);
            }
            catch (ArgumentOutOfRangeException)
            {
                NlogEngine.logger.Fatal(
                    "RssDialogys.WinFormsUI.PresentationForm.flpControl_MouseLeft controlIndex = ArgumentoutOfRangeException");
                //obsluzony , gdzies w wypelnianiu controlsow jest luka i laduje to pustego pola event ... 
            }
        }
        
        private void SetLabelSettingsForDescriptionRead(Label labelControl)
        {
            labelControl.ForeColor = Color.FloralWhite;
            int fontSize = 10;
            if (labelControl.Text.Length > 300)
            {
                fontSize = 9;
                if (labelControl.Text.Length > 390)
                    fontSize = 8;
            }

            labelControl.Font = new Font("Segoe UI", fontSize, FontStyle.Regular);
            labelControl.TextAlign = ContentAlignment.TopLeft;
            labelControl.BackColor = Color.FromArgb(225, Color.White);
            labelControl.ForeColor = Color.Black;
        }

        //funkcja zmienia ustawienia labelki tak zeby nadawalo sie do wyswietlania tytulu 
        private void SetLabelSettingsForTittleRead(Label labelControl)
        {
            labelControl.ForeColor = Color.FloralWhite;
            labelControl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            labelControl.TextAlign = ContentAlignment.MiddleCenter;
            labelControl.BackColor = Color.FromArgb(200, Color.Black);
        }

        //funkcja do pobierania labela z flowlayoutpanela po indexie 
        private Label GetLabelControl(int indexInFlp)
        {
            //nie wiem jak mozna by to inaczejnapisać 
            return flp.Controls[indexInFlp].Controls.OfType<Label>().FirstOrDefault() == null ? flp.Controls[indexInFlp].Controls.OfType<PictureBox>()
                         .FirstOrDefault()
                         .Controls.OfType<Label>()
                         .FirstOrDefault() : flp.Controls[indexInFlp].Controls.OfType<Label>().FirstOrDefault();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //jestem bardzo dumny z tego rozwiazania 
            //tylko ze chwilowo jest powtorzony kod ale naprawie to jedna funkcja i tyle w sumie do drugiego klawisza tez sie przyda 
            // wszystko działa 
            _page += 1;
            if (_page == TotalPages)
            {
                button2.Enabled = false;
                button2.Visible = false;
                if (_page > 1)
                {
                    button1.Visible = true;
                    button1.Enabled = true;
                }
                ChangePage();
            }
            else
            {
                button2.Enabled = true;
                button2.Visible = true;
                button1.Enabled = true;
                button1.Visible = true;
                ChangePage();
            }
        }

        private void ChangePage()
        {
            if (_currentCategory == null)
            {
                _feedsForPresentation = feedRepository.GetItems
                  .OrderByDescending(x => x.PublishDate).Skip((_page - 1) * ItemsPerPage).Take(ItemsPerPage).ToList();
                MetroFillItemsFlowLayout(_feedsForPresentation);
            }
            else
            {
                {
                    _feedsForPresentation =
                        feedRepository.GetItemsForChangePagePresentation(_page, ItemsPerPage, _currentCategory).ToList();              
                    MetroFillItemsFlowLayout(_feedsForPresentation);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _page -= 1;
            if (_page == 1)
            {
                button1.Enabled = false;
                button1.Visible = false;
                button2.Enabled = true;
                button2.Visible = true;
                ChangePage();
            }
            else
            {
                button2.Enabled = true;
                button2.Visible = true;
                ChangePage();
            }
        }


        private void flpCategories_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                var panel = (Panel)sender;
                panel.BackColor = Color.FromArgb(80, 80, 80);
            }
            else if (sender is Label)
            {
                var label = (Label)sender;
                label.Parent.BackColor = Color.FromArgb(80, 80, 80);
            }


        }

        private void flpCategories_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                var panel = (Panel)sender;
                if (panel.Tag.ToString() != _currentCategory)
                    panel.BackColor = Color.Black;
            }
            else if (sender is Label)
            {
                var label = (Label)sender;
                var panel = label.Parent;
                if (panel.Tag.ToString() != _currentCategory)
                    panel.BackColor = Color.Black;
            }
        }

        //event z ktorym bedzie duzo roboty 
        private void flpCategories_ChooseCategory(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                var panel = (Panel)sender;
                _currentCategory = panel.Tag.ToString();
            }
            else if (sender is Label)
            {
                var label = (Label)sender;
                _currentCategory = label.Parent.Tag.ToString();
            }
            else if (sender is PictureBox)
            {
                //hmm pojawił się tutaj bład przy wyborze kategori ciekawe dlaczego , tak jakby przy tworzeniu nie dodało kategorii 
                //sprawdziłem i w sumie to nie wiem dlaczego tak sie stało to praktycznie niemożliwe . 
                var pictureBox = (PictureBox)sender;
                _currentCategory = pictureBox.Tag.ToString();
            }
            //jednak to tez musi byc bo znajazlem sytuacje w ktorej sa dwie strony jestem na pierwszej i button wstecz jest widoczny 
            button1.Enabled = false;
            button1.Visible = false;
            _page = 1;
            if (TotalPages > 1)
            {
                button2.Enabled = true;
                button2.Visible = true;
            }
            //ten warunek jest pewny bo jak mam tylko jedna strone to nie chce widziec buttona1 (wstecz)
            if (TotalPages == 1)
            {
                button1.Enabled = false;
                button1.Visible = false;
                button2.Enabled = false;
                button2.Visible = false;
            }
            //zauwarzylem problem kolejnoscia wyswietlanych wiadomosc to zapytanie powinno rozwiazac problem 
            _feedsForPresentation = feedRepository.GetItemsForChooseCategoryPresentation(ItemsPerPage, _currentCategory).ToList();
            MetroFillItemsFlowLayout(_feedsForPresentation);
            for (int i = 0; i < flpCategories.Controls.Count; i++)
            {
                if (flpCategories.Controls[i].Tag.ToString() == _currentCategory)
                {
                    flpCategories.Controls[i].BackColor = Color.FromArgb(80, 80, 80);
                }
                else
                {
                    flpCategories.Controls[i].BackColor = Color.Black;
                }
            }
        }
        //nie polecam zagladac tam jest dynamiczne tworzenie kontrolek niby mozna by to rozbic na 5 innych funkcji ale nie mam na to czasu i nie widze w tym sensu gdyz ciezej bedzie to zrozumiec
        private void InitializeFlpCategories()
        {
            List<CategoryPubDateQuantity> allinOne = feedRepository.GetCategiesInformations().ToList();

            for (int i = 0; i < allinOne.Count; i++)
            {
                var panel = new Panel();
                panel.Size = new Size(310, 62);
                panel.Tag = allinOne.ElementAt(i).Category;
                string currentCategory = allinOne.ElementAt(i).Category;
                int currentCategoryCount = allinOne.ElementAt(i).Quantity;    

                var imageForPresentation = new PictureBox();
                imageForPresentation.Size = new Size(62, 62);
                imageRepository.SetRandomFilesToFileInfosForCategory(i,
                    feedRepository.GetImageIdForCategory(currentCategory).ToList(), currentCategoryCount);
                imageForPresentation.Image = imageRepository[i];
                imageForPresentation.SizeMode = PictureBoxSizeMode.StretchImage;
                imageForPresentation.MouseClick += flpCategories_ChooseCategory;
                imageForPresentation.MouseEnter += flpCategories_MouseEnter;
                imageForPresentation.MouseLeave += flpCategories_MouseLeave;

                //labelka z kategoria
                var categoryName = new Label { Text = allinOne.ElementAt(i).Category.ToUpper() };
                categoryName.Font = new Font("Segoe UI", 15, FontStyle.Bold);
                categoryName.AutoSize = true;
                categoryName.Location = new Point(62, 0);
                categoryName.ForeColor = Color.FloralWhite;
                categoryName.MouseEnter += flpCategories_MouseEnter;
                categoryName.MouseLeave += flpCategories_MouseLeave;
                categoryName.MouseClick += flpCategories_ChooseCategory;

                //labelka z iloscia itemow
                var categoryQuantity = new Label { Text = allinOne.ElementAt(i).Quantity.ToString(CultureInfo.InvariantCulture) };
                categoryQuantity.Location = new Point(273, 7);
                categoryQuantity.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                categoryQuantity.ForeColor = Color.FloralWhite;
                categoryQuantity.MouseEnter += flpCategories_MouseEnter;
                categoryQuantity.MouseLeave += flpCategories_MouseLeave;
                categoryQuantity.MouseClick += flpCategories_ChooseCategory;

                //labelka z data ostatniego updata danej kategori 
                DateTime pubDateTime = allinOne.ElementAt(i).PubDate;
                var categoryLastUpdate = new Label
                {
                    Text = @"Najnowsze z " + pubDateTime.ToShortTimeString() + @" dnia " + pubDateTime.ToShortDateString()
                };
                categoryLastUpdate.AutoSize = true;
                categoryLastUpdate.Location = new Point(62, 30);
                categoryLastUpdate.Font = new Font("Segoe UI Light", 10, FontStyle.Bold);
                if (pubDateTime < DateTime.Now)
                {
                    categoryLastUpdate.ForeColor = Color.LawnGreen;
                }
                if (pubDateTime < DateTime.Now.AddHours(-12))
                {
                    categoryLastUpdate.ForeColor = Color.Goldenrod;
                }
                if (pubDateTime < DateTime.Now.AddHours(-24))
                {
                    categoryLastUpdate.ForeColor = Color.OrangeRed;
                }

                categoryLastUpdate.MouseEnter += flpCategories_MouseEnter;
                categoryLastUpdate.MouseLeave += flpCategories_MouseLeave;
                categoryLastUpdate.MouseClick += flpCategories_ChooseCategory;

                //dodanie calosc do kontenera
                panel.Controls.Add(imageForPresentation);
                panel.Controls.Add(categoryName);
                panel.Controls.Add(categoryQuantity);
                panel.Controls.Add(categoryLastUpdate);
                panel.MouseEnter += flpCategories_MouseEnter;
                panel.MouseLeave += flpCategories_MouseLeave;
                panel.MouseClick += flpCategories_ChooseCategory;

                flpCategories.Controls.Add(panel);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormTransform.Animate(this, AnimateStyle.FadeOut);
        }
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

        private void LoadScrollingForm(object sender, EventArgs e)
        {
            if (!bwScrollEffect.IsBusy)
                bwScrollEffect.RunWorkerAsync();
        }

        private void btCloseOpenCantegories_Click(object sender, EventArgs e)
        {
            if (Width == 1266)
            {           
                FormTransform.Animate(this, AnimateStyle.SlideLeft, 938);
            }
            else
            {
                FormTransform.Animate(this, AnimateStyle.SlideRight, 1266);
            }

        }

        private void btnShowMetroCategories_Click(object sender, EventArgs e)
        {
            label17.Text = @"Categorie";     
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            MetroFillCategoriesFlowLayout();
        }

        private void bwScrollEffect_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentCategory))
            {
                _scrollingF = new ScrollingForm(feedRepository.GetItems.ToList());
                NlogEngine.logger.Trace(
                    "RssDialogys.WinFormsUI.PresentationForm.bwScrrolEffect_DoWork for empty category");
                _scrollingF.ShowDialog();
            }
            else
            {
                _scrollingF = new ScrollingForm(feedRepository.GetItems.Where(x => x.Category == _currentCategory).ToList());
                NlogEngine.logger.Trace(
                    "RssDialogys.WinFormsUI.PresentationForm.bwScrrolEffect_DoWork for {0}", _currentCategory);
                _scrollingF.ShowDialog();
            }
        }

        private void bwScrollEffect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _scrollingF.ScrollingForm_MouseDoubleClick(null, null);
        }
    }
}
