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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для fail.xaml
    /// </summary>
    public partial class fail : Page
    {
        public fail()
        {
            InitializeComponent();
            int t = ((MainWindow)System.Windows.Application.Current.MainWindow).score;
            tb_score.Text = "Ваш счёт: "+ t.ToString();
        }

        private void Bt_replay_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).score=0;
            var a = NavigationService.GetNavigationService(this);
            a.Navigate(new Uri("game.xaml", UriKind.Relative));
        }

        private void bt_goToMenu_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).score = 0;
            var a = NavigationService.GetNavigationService(this);
            a.Navigate(new Uri("menu.xaml", UriKind.Relative));
        }
    }
}
