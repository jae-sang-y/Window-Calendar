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

namespace MainApp
{
    /// <summary>
    /// Interaction logic for Page_Main.xaml
    /// </summary>
    public partial class Page_Main : Page
    {
        Image[] posters;
        int now = 0;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public Page_Main()
        {
            InitializeComponent();
            posters = new Image[] { Now_Image, Prev_Image};

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();
        }

        private void Prev_Slide_Button_Click(object sender, RoutedEventArgs e)
        {
            posters[now].Visibility = Visibility.Collapsed;
            now = (now - 1 + posters.Length) % posters.Length;
            posters[now].Visibility = Visibility.Visible;
        }
        private void Next_Slide_Button_Click(object sender, RoutedEventArgs e)
        {
            posters[now].Visibility = Visibility.Collapsed;
            now = (now + 1) % posters.Length;
            posters[now].Visibility = Visibility.Visible;
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Next_Slide_Button_Click(null, null);
        }
    }
}
