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
    /// Логика взаимодействия для menu.xaml
    /// </summary>
    public partial class menu : Page
    {
        public menu()
        {
            InitializeComponent();
        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            var a = NavigationService.GetNavigationService(this);
            a.Navigate((Uri)(new Uri("game.xaml", UriKind.Relative)));
        }

        private void Btn_Score_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ваш максимальный счет за несколько игр: " + ((MainWindow)System.Windows.Application.Current.MainWindow)._maxScore, "Максимальный счет");
        }

        private void Btn_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Простая игра, нажимайте на яргоды и получйте очки, а иначе проигрыш ))","Инструкция");
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }        
    }
}
