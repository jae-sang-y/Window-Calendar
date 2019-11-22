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
using System.Windows.Shapes;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for ExampleWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        Page_Calendar page_calendar = new Page_Calendar();
        Page_Main page_main = new Page_Main();
        Page_Notify page_notify = new Page_Notify();
        Page_TimeTable page_timetable = new Page_TimeTable();
        Page_Group page_group = new Page_Group();
        MailWindow wind_mail = new MailWindow();

        ServerConnector.ServerConnector sc = ServerConnector.ServerConnector.GetInstace();

        public WorkWindow()                      
        {
            InitializeComponent();
            Main_Panel.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            Main_Panel.Navigate(page_main);

            sc.student.schoolName = "dsm";

            wind_mail.IsEnabled = false;
        }
        
        
        void Show_Main_Button(object sender, EventArgs e)
        {
            Main_Panel.Navigate(page_main);
        }
        void Show_Plan_Button(object sender, EventArgs e)
        {
            Main_Panel.Navigate(page_calendar);
            page_calendar.Refresh();
        }
        void Show_Notify_Button(object sender, EventArgs e)
        {
            Main_Panel.Navigate(page_notify);
            page_notify.Refresh();
        }
        void Show_Time_Button(object sender, EventArgs e)
        {
            Main_Panel.Navigate(page_timetable);
            page_timetable.Refresh();
        }
        void Show_Group_Button(object sender, EventArgs e)
        {
            Main_Panel.Navigate(page_group);
            page_group.Refresh();
        }

        private void Open_Mail_Button(object sender, RoutedEventArgs e)
        {
            if (wind_mail.IsEnabled)
            {
                wind_mail.Close();
                wind_mail.IsEnabled = false;
            }
            else
            {
                wind_mail = new MailWindow();
                wind_mail.Owner = this;
                wind_mail.Show();
            }
        }
    }
}
