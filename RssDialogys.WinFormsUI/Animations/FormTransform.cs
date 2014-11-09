using System;
using System.Drawing;
using System.Windows.Forms;

namespace RssDialogys.WinFormsUI.Animations
{
    //uff 30 minut i mam wlasna uniwersalna clase do robienia animacji , juz nigdy nie bede musiał pisać tego od zera ;) 
    public static class FormTransform
    {
        public static Form CurrentForm;
        public static AnimateStyle Style;
        public static Size FormSize;
        public static Timer Timer;


        public static void Animate(Form form, AnimateStyle style, int x, int y=0)
        {
            CurrentForm = null;
            CurrentForm = form;
            Size formSize = new Size(form.Width, form.Height);
            Timer = new Timer();
            switch (style)
            {
                case AnimateStyle.SlideLeft:
                    Timer.Interval = 1;
                    Timer.Tag = new AnimateForms(formSize, style, x, y);
                    break;
                case AnimateStyle.SlideRight:
                    Timer.Interval = 1;
                    Timer.Tag = new AnimateForms(formSize, style, x, y);
                    break;
            }
            Timer.Tick += timerForAnimations_Tick;
            Timer.Start();

        }
        public static void Animate(Form form, AnimateStyle style)
        {
            CurrentForm = null;
            CurrentForm = form;
            Size formSize = new Size(form.Width, form.Height);
            Timer = new Timer();
            switch (style)
            {
                case AnimateStyle.SlideDown:
                    CurrentForm.Size = new Size(formSize.Width, 0);
                    Timer.Interval = 10;
                    Timer.Tag = new AnimateForms(formSize, style);
                    break;

                case AnimateStyle.FadeIn:
                    CurrentForm.Size = formSize;
                    CurrentForm.Opacity = 0;
                    Timer.Interval = 50;    //wydaje mi sie ze taka czestotliwośc jest najbardziej odpowiednia do animacji przynajmniej tego typu 
                    Timer.Tag = new AnimateForms(formSize, style);
                    break;

                case AnimateStyle.FadeOut:
                    CurrentForm.Size = formSize;
                    CurrentForm.Opacity = 50;
                    Timer.Interval = 45;
                    Timer.Tag = new AnimateForms(formSize, style);
                    break;

                case AnimateStyle.SlideUp:
                    CurrentForm.Size = FormSize;
                    Timer.Interval = 50;
                    Timer.Tag = new AnimateForms(formSize, style);
                    break;

                case AnimateStyle.ZoomIn:
                    CurrentForm.Size = new Size(formSize.Width + 100, formSize.Height + 100);
                    Timer.Tag = new AnimateForms(formSize, style);
                    Timer.Interval = 1;
                    break;
            }
            Timer.Tick += timerForAnimations_Tick;
            Timer.Start();
            if (style != AnimateStyle.FadeOut && style != AnimateStyle.SlideUp)
                CurrentForm.ShowDialog();
            else
            {
                CurrentForm.Invalidate();
            }


        }
        public static void timerForAnimations_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            AnimateForms animate = (AnimateForms)timer.Tag;

            switch (animate.Style)
            {
                case AnimateStyle.SlideLeft:
                    if (CurrentForm.Width > animate.X)
                    {
                        CurrentForm.Width -= 10;
                    }
                    else
                    {
                        Timer.Stop();
                        Timer.Dispose();
                    }
                    break;
                case AnimateStyle.SlideRight:
                    if (CurrentForm.Width < animate.X)
                    {
                        CurrentForm.Width += 10;
                    }
                    else
                    {
                        Timer.Stop();
                        Timer.Dispose();
                    }
                    break;
                case AnimateStyle.SlideDown:
                    if (CurrentForm.Height < animate.FormSize.Height)
                    {
                        CurrentForm.Height += 17;
                        CurrentForm.Invalidate();
                    }
                    else
                    {
                        Timer.Stop();
                        Timer.Dispose();
                    }
                    break;
                case AnimateStyle.SlideUp:
                    if (CurrentForm.Height > 200)
                    {
                        CurrentForm.Height -= 17;
                        CurrentForm.Invalidate();
                    }
                    else
                    {
                        Timer.Stop();
                        Timer.Dispose();
                    }
                    break;
                case AnimateStyle.FadeIn:
                    if (CurrentForm.Opacity < 1)
                    {
                        CurrentForm.Opacity += 0.1;
                        CurrentForm.Invalidate();
                    }
                    else
                    {
                        Timer.Stop();
                        Timer.Dispose();
                    }
                    break;


                case AnimateStyle.FadeOut:
                    if (CurrentForm.Opacity > 0)
                    {
                        CurrentForm.Opacity -= 0.1;
                       // CurrentForm.Invalidate(); //dziwne bo bez tego tez dziala 
                    }
                    else
                    {
                        Timer.Stop();
                        Timer.Dispose();
                        CurrentForm.Close();//i po problemie ale to nie jest dobre rozwiazanie 
                    }
                    break;

                case AnimateStyle.ZoomIn:
                    if (CurrentForm.Width > animate.FormSize.Width)
                    {
                        CurrentForm.Width -= 17;
                        CurrentForm.Invalidate();
                    }
                    if (CurrentForm.Height > animate.FormSize.Height)
                    {
                        CurrentForm.Height -= 17;
                        CurrentForm.Invalidate();
                    }
                    break;
            }
        }
    }

    class AnimateForms
    {
        public Size FormSize;
        public AnimateStyle Style;
        public int X;
        public int Y;
        public AnimateForms(Size formSize, AnimateStyle style,int x=0,int y=0)
        {
            FormSize = formSize;
            Style = style;
            X = x;
            Y = y;
        }
    }

    public enum AnimateStyle
    {
        SlideDown = 1,
        FadeIn = 2,
        ZoomIn = 3,
        FadeOut = 4,
        SlideUp = 5,
        SlideLeft = 6,
        SlideRight = 7
    }
}
