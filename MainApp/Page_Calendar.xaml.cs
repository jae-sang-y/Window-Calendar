using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class Plan
    {
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string desc { get; set; }
    }

    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page_Calendar : Page
    {
        ServerConnector.ServerConnector sc = ServerConnector.ServerConnector.GetInstace();
        public Page_Calendar()
        {
            InitializeComponent();
            ListView_Output.Items.Add(
                new Plan() { name = "학교 대청소", date = "11-27:5~7교시", desc = "", id = 0 }
                );
            ListView_Output.Items.Add(
                new Plan() { name = "기말고사", date = "11-26:1~4교시", desc = "", id = 1 }
                );
            ListView_Output.Items.Add(
                new Plan() { name = "4차산업 특강", date = "11-28:8~9교시", desc = "필기구 필요", id = 2 }
                );

            UpdateCalendar();

            //string test = JsonConvert.SerializeObject(sc.student);

            //HttpStatusCode status;
            //string res;
            //(status, res) = sc.SendRequest("join", "POST", test);

            //if (status == HttpStatusCode.OK)
            //{
            //}
        }

        void UpdateCalendar()
        {
            foreach (Plan p in ListView_Output.Items)
            {
                Calender_Interface.SelectedDates.Add(DateTime.Parse(p.date.Split(':')[0]));
            }
        }

        private void Calender_Interface_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCalendar();
        }

        void Add_Plan_Button(object sender, EventArgs e)
        {
            string title = Interaction.InputBox("일정의 제목을 적어주세요.", "", "");
            if (title == "") return;

            string time = Interaction.InputBox("일정의 날짜을 적어주세요.", "", "19/02/10");
            if (time == "") return;
            string[] datestr = time.Split(':')[0].Split('/');
            DateTime date = new DateTime(2000 + int.Parse(datestr[0]), int.Parse(datestr[1]), int.Parse(datestr[2]));

            string desc = Interaction.InputBox("일정의 준비물을 적어주세요.", "", "");
            ListView_Output.Items.Add(new Plan()
            {
                name = title,
                date = time,
                desc = desc,
                id = ListView_Output.Items.Count
            });
            UpdateCalendar();
        }
        void Delete_Plan_Button(object sender, EventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            foreach (object obj in ListView_Output.Items)
            {
                if (((Plan)obj).id == id)
                {
                    ListView_Output.Items.Remove(obj);
                    break;
                }
            }
            UpdateCalendar();
        }

        private void Calender_Interface_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            UpdateCalendar();
        }
    }
}
