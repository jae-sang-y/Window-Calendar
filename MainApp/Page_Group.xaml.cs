using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Page_Group.xaml
    /// </summary>
    public partial class Page_Group : Page
    {
        ServerConnector.ServerConnector sc = ServerConnector.ServerConnector.GetInstace();
        public Page_Group()
        {
            InitializeComponent();
        }

        void Manage_Group_Member_Menu(object sender, EventArgs e)
        {
            new Member_Window((int)((MenuItem)sender).Tag).ShowDialog();
        }
        void Edit_Group_Name_Menu(object sender, EventArgs e)
        {
            int id = (int)(((Button)sender).Tag);
            try
            {
                string title = Interaction.InputBox("그룹의 새 이름을 적어주세요.", "", "");
                if (title == "") return;
                var obj = new ServerConnector.Room()
                {
                    calendarId = sc.student.myCalendarId,
                    roomTitle = title,
                    roomId = id
                };
                string pdata = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                System.Net.HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest("room", "POST", pdata, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.Room> rooms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.Room>>(res);

                    ListView_Output.Items.Clear();
                    foreach (ServerConnector.Room not in rooms)
                    {
                        ListView_Output.Items.Add(not);
                    }
                }
                else MessageBox.Show("그룹들을 갱신하는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("그룹들을 갱신하는데 실패했습니다.\n" + ex.Message);
            }
        }

        void Add_Group_Button(object sender, EventArgs e)
        {
            try
            {
                string title = Interaction.InputBox("그룹의 이름을 적어주세요.", "", "");
                if (title == "") return;
                var obj = new ServerConnector.Room()
                {
                    calendarId = sc.student.myCalendarId,
                    roomTitle = title
                };
                string pdata = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                pdata = pdata.Replace("\"roomId\":0,", "");

                System.Net.HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest("room", "POST", pdata, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.Room> rooms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.Room>>(res);

                    ListView_Output.Items.Clear();
                    foreach (ServerConnector.Room not in rooms)
                    {
                        ListView_Output.Items.Add(not);
                    }
                }
                else MessageBox.Show("그룹들을 추가하는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("그룹들을 추가하는데 실패했습니다.\n" + ex.Message);
            }
        }
        public void Refresh()
        {
            try
            {
                System.Net.HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest("room", "GET", null, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.Room> rooms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.Room>>(res);

                    ListView_Output.Items.Clear();
                    foreach (ServerConnector.Room not in rooms)
                    {
                        ListView_Output.Items.Add(not);
                    }
                }
                else MessageBox.Show("그룹들을 불러오는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("그룹들을 불러오는데 실패했습니다.\n" + ex.Message);
            }
        }
    }
}
