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
using Microsoft.VisualBasic;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for Page_Notify.xaml
    /// </summary>
    public partial class Page_Notify : Page
    {
        ServerConnector.ServerConnector sc = ServerConnector.ServerConnector.GetInstace();
        public Page_Notify()
        {
            InitializeComponent();
        }


        private void Add_Notify_Button_Click(object sender, RoutedEventArgs e)
        {
            string title = Interaction.InputBox("공지의 제목을 적어주세요.", "", "");
            if (title == "") return;
            string desc = Interaction.InputBox("공지의 본문을 적어주세요.", "", "");
            string startdate = Interaction.InputBox("공지의 시작기간을 적어주세요.", "", "19/11/12:1교시");
            string enddate = Interaction.InputBox("공지의 종료기간을 적어주세요.", "", "19/11/12:5교시");

            try
            {
                var tmp_not = new ServerConnector.Notify()
                {
                    noticeTitle = title,
                    noticeContent = desc,
                    startDate = startdate,
                    endDate = enddate
                };
                System.Net.HttpStatusCode status;
                string pdata = Newtonsoft.Json.JsonConvert.SerializeObject(tmp_not);
                pdata = pdata.Replace("\"noticeId\":0,", "");

                string res;
                (status, res) = sc.SendRequest($"notice", "POST", pdata, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.Notify> notifies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.Notify>>(res);

                    ListView_Output.Items.Clear();
                    foreach (ServerConnector.Notify not in notifies)
                    {
                        not.subText = $"{not.startDate}~{not.endDate}";
                        ListView_Output.Items.Add(not);
                    }
                }
                else MessageBox.Show("공지를 삭제하는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("공지를 삭제하는데 실패했습니다.\n" + ex.Message);
            }

        }

        private void Delete_Notify_Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            try
            {
                System.Net.HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest($"notice/{id}", "DELETE", null, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.Notify> notifies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.Notify>>(res);

                    ListView_Output.Items.Clear();
                    foreach (ServerConnector.Notify not in notifies)
                    {
                        not.subText = $"{not.startDate}~{not.endDate}";
                        ListView_Output.Items.Add(not);
                    }
                }
                else MessageBox.Show("공지를 삭제하는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("공지를 삭제하는데 실패했습니다.\n" + ex.Message);
            }

        }

        private void Show_Notify_Button_Click(object sender, MouseButtonEventArgs e)
        {
            int id = (int)((TextBox)sender).Tag;
            string desc = "undefine";
            foreach (object obj in ListView_Output.Items)
            {
                if (((ServerConnector.Notify)obj).noticeId == id)
                {
                    desc = ((ServerConnector.Notify)obj).noticeContent;
                    break;
                }
            }
            MessageBox.Show(desc);
        }

        public void Refresh()
        {
            try
            {
                System.Net.HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest("notice", "GET", null, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.Notify> notifies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.Notify>>(res);

                    ListView_Output.Items.Clear();
                    foreach (ServerConnector.Notify not in notifies)
                    {
                        not.subText = $"{not.startDate}~{not.endDate}";
                        ListView_Output.Items.Add(not);                        
                    }
                }
                else MessageBox.Show("공지를 불러오는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("공지를 불러오는데 실패했습니다.\n" + ex.Message);
            }
        }
    }
}
