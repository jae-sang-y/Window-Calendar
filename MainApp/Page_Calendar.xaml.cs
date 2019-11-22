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
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page_Calendar : Page
    {
        ServerConnector.ServerConnector sc = ServerConnector.ServerConnector.GetInstace();
        public Page_Calendar()
        {
            InitializeComponent();
        }

        private void Calender_Interface_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        void Add_Plan_Button(object sender, EventArgs e)
        {
            string title = Interaction.InputBox("일정의 제목을 적어주세요.", "", "");
            if (title == "") return;
            string startdate = Interaction.InputBox("일정의 시작기간을 적어주세요.", "", "19/11/12:1교시");
            if (startdate == "") return;
            string enddate = Interaction.InputBox("일정의 종료기간을 적어주세요.", "", "19/11/12:5교시");
            if (enddate == "") return;
            string desc = Interaction.InputBox("일정의 준비물을 적어주세요.", "", "");

            try
            {
                var tmp_not = new ServerConnector.Schedule()
                {
                    start_date = startdate,
                    end_date = enddate,
                    schedule_content = desc,
                    schedule_title = title,
                    calendar_id = sc.student.myCalendarId
                };
                System.Net.HttpStatusCode status;
                string pdata = Newtonsoft.Json.JsonConvert.SerializeObject(tmp_not);
                pdata = pdata.Replace("\"schedule_id\":0,", "");

                string res;
                (status, res) = sc.SendRequest($"schedule/{sc.student.myCalendarId}", "POST", pdata, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.Schedule> notifies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.Schedule>>(res);

                    ListView_Output.Items.Clear();
                    foreach (ServerConnector.Schedule not in notifies)
                    {
                        not.subText = $"{not.start_date}~{not.end_date}";
                        string[] datestr = not.start_date.Split(':')[0].Split('/');
                        DateTime date = new DateTime(2000 + int.Parse(datestr[0]), int.Parse(datestr[1]), int.Parse(datestr[2]));
                        not.date = date;
                        ListView_Output.Items.Add(not);
                    }
                }
                else MessageBox.Show("스케줄을 추가하는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("스케줄을 추가하는데 실패했습니다.\n" + ex.Message);
            }
        }
        void Delete_Plan_Button(object sender, EventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            try
            {
                System.Net.HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest($"schedule/{id}", "DELETE", null, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.Schedule> notifies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.Schedule>>(res);

                    ListView_Output.Items.Clear();
                    foreach (ServerConnector.Schedule sch in notifies)
                    {
                        sch.subText = $"{sch.start_date}~{sch.end_date}";
                        ListView_Output.Items.Add(sch);
                    }
                }
                else MessageBox.Show("스케줄을 삭제하는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("스케줄을 삭제하는데 실패했습니다.\n" + ex.Message);
            }
        }

        private void Calender_Interface_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        public void Refresh()
        {
            try
            {
                System.Net.HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest("myCalendar", "GET", null, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.Schedule> notifies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.Schedule>>(res);

                    ListView_Output.Items.Clear();
                    foreach (ServerConnector.Schedule sch in notifies)
                    {
                        sch.subText = $"{sch.start_date}~{sch.end_date}";
                        ListView_Output.Items.Add(sch);
                    }
                }
                else MessageBox.Show("스케줄을 불러오는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("스케줄을 불러오는데 실패했습니다.\n" + ex.Message);
            }
        }
    }
}
