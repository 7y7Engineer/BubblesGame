using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для game.xaml
    /// </summary>
    public partial class game : Page
    {        
        int caseStartDuration = 0;
        public double speedKoef = 2;
        public Random rand = new Random(); 
        public game()
        {
            InitializeComponent();
            ShowsNavigationUI = false;            
            ((MainWindow)System.Windows.Application.Current.MainWindow).score=0;
            pushImg("first");
            pushImg("second");            
            pushImg("third");
            pushImg("fourth");
            pushImg("fifth");
        }
        public void pushImg(string name)
        {
            Image bubbleImg = new Image
            {
                Source = new BitmapImage(new Uri(@"C:\Users\Админ\Desktop\books\3йкурс2йсеместр\СПО С#\LAB\MyGameLera2\MyGame\Images\soapbubble.png", UriKind.Absolute)),
                Height = 100,
                Width = 100,
                Name = name
            };

            if (name == "first")
            {                
                Canvas.SetLeft(bubbleImg, 30);
            } else
            if (name == "second")
            {
                Canvas.SetLeft(bubbleImg, 210);
            } else
            if (name == "third")
                Canvas.SetLeft(bubbleImg, 390);
            else
            if (name == "fourth")
                Canvas.SetLeft(bubbleImg, 570);
            else
                Canvas.SetLeft(bubbleImg, 750);

            bubbleImg.MouseDown += Img_MouseDown;
            var anim = new DoubleAnimation
            {
                From = -(double)bubbleImg.Height,
                To = 640 - bubbleImg.Height
            };

            if (name == "first")
            {
                anim.Duration = TimeSpan.FromSeconds(rand.Next(4, 7) * speedKoef);
            }
            else
            if (name == "second")
            {
                anim.Duration = TimeSpan.FromSeconds(rand.Next(4, 12) * speedKoef);
            }
            if (name == "third")
            {
                anim.Duration = TimeSpan.FromSeconds(rand.Next(4, 8) * speedKoef);
            }
            if (name == "fourth")
            {
                anim.Duration = TimeSpan.FromSeconds(rand.Next(6, 10) * speedKoef);
            }
            else
                anim.Duration = TimeSpan.FromSeconds(rand.Next(4,12) * speedKoef);


            anim.Completed += Anim_Completed;
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(anim);            
            Storyboard.SetTarget(anim, bubbleImg);
            Storyboard.SetTargetProperty(anim, new PropertyPath("(Canvas.Bottom)"));
            cv_Main.Children.Add(bubbleImg);            
            cv_Main.Resources.Add("sb_"+name, storyboard);
            storyboard.Begin();
        }

        private void Anim_Completed(object sender, EventArgs e)
        {
            ((Storyboard)cv_Main.Resources["sb_first"]).Stop();
            ((Storyboard)cv_Main.Resources["sb_second"]).Stop();
            ((Storyboard)cv_Main.Resources["sb_third"]).Stop();
            ((Storyboard)cv_Main.Resources["sb_fourth"]).Stop();
            ((Storyboard)cv_Main.Resources["sb_fifth"]).Stop();
            var a = NavigationService.GetNavigationService(this);
            a.Navigate(new Uri("fail.xaml", UriKind.Relative));
        }

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).score++;
            speedKoef -= 0.05;
            string tempName = ((Image)sender).Name;
            ((Storyboard)cv_Main.Resources["sb_"+tempName]).Stop();
            cv_Main.Resources.Remove("sb_"+tempName);
            cv_Main.Children.Remove((Image)sender);
            pushImg(tempName);
        }
    }
}
