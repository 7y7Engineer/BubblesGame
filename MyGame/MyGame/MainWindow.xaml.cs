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
using System.Windows.Media.Animation;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public int _score = 0;
        public int _maxScore = 0;
        public int score
        {
            get { return _score; }
            set
            {
                _score = value;                        
                if (_score >= _maxScore)
                {
                    _maxScore = _score;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        } 
    }
}
