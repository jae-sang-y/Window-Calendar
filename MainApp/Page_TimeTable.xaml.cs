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
    /// Interaction logic for Page_TimeTable.xaml
    /// </summary>
    public partial class Page_TimeTable : Page
    {
        ServerConnector.ServerConnector sc = ServerConnector.ServerConnector.GetInstace();
        Label[][] table;
        public Page_TimeTable()
        {
            InitializeComponent();
            table = new Label[5][]{ new Label[9]{
                table1_1,
                table1_2,
                table1_3,
                table1_4,
                table1_5,
                table1_6,
                table1_7,
                table1_8,
                table1_9},
                 new Label[9]{
                table2_1,
                table2_2,
                table2_3,
                table2_4,
                table2_5,
                table2_6,
                table2_7,
                table2_8,
                table2_9},
                 new Label[9]{
                table3_1,
                table3_2,
                table3_3,
                table3_4,
                table3_5,
                table3_6,
                table3_7,
                table3_8,
                table3_9},
                 new Label[9]{
                table4_1,
                table4_2,
                table4_3,
                table4_4,
                table4_5,
                table4_6,
                table4_7,
                table4_8,
                table4_9},
                 new Label[9]{
                table5_1,
                table5_2,
                table5_3,
                table5_4,
                table5_5,
                table5_6,
                table5_7,
                table5_8,
                table5_9}};

            for (int x = 0; x <5; ++x)
            {
                for (int y = 0; y < 9; ++y)
                {
                    table[x][y].Content = "";
                }
            }


            //table[0][0].Content = "자율";
            //table[0][1].Content = "C#";
            //table[0][2].Content = "->";
            //table[0][3].Content = "->";
            //table[0][4].Content = "->";
            //table[0][5].Content = "체육";
            //table[0][6].Content = "자구";
            //table[0][7].Content = "->";
            //table[0][8].Content = "역사";


            //table[1][0].Content = "운체";
            //table[1][1].Content = "->";
            //table[1][2].Content = "체육";
            //table[1][3].Content = "DB";
            //table[1][4].Content = "->";
            //table[1][5].Content = "국어";
            //table[1][6].Content = "국사";
            //table[1][7].Content = "->";
            //table[1][8].Content = "영어";


            //table[2][0].Content = "수학";
            //table[2][1].Content = "->";
            //table[2][2].Content = "영어";
            //table[2][3].Content = "리눅";
            //table[2][4].Content = "->";
            //table[2][5].Content = "->";
            //table[2][6].Content = "->";
            //table[2][7].Content = "국사";
            //table[2][8].Content = "국어";

            //table[3][0].Content = "공작";
            //table[3][1].Content = "->";
            //table[3][2].Content = "->";
            //table[3][3].Content = "임베\n디드";
            //table[3][4].Content = "->";
            //table[3][5].Content = "->";
            //table[3][6].Content = "->";
            //table[3][7].Content = "토익";
            //table[3][8].Content = "->";

            //table[4][0].Content = "진로";
            //table[4][1].Content = "->";
            //table[4][2].Content = "동아리";
            //table[4][3].Content = "->";
            //table[4][4].Content = "->";
            //table[4][5].Content = "->";
            //table[4][6].Content = "체육";
            //table[4][7].Content = "청소";
            //table[4][8].Content = "->";
        }
        public void Refresh()
        {
            try
            {
                System.Net.HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest("timeTable", "GET", null, $"loginUserId: {sc.student.loginUserId}");

                if (status == System.Net.HttpStatusCode.OK)
                {
                    List<ServerConnector.SchoolClass> classes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConnector.SchoolClass>>(res);

                    for (int x = 0; x < 5; ++x)
                    {
                        for (int y = 0; y < 9; ++y)
                        {
                            table[x][y].Content = "";
                        }
                    }

                    foreach (ServerConnector.SchoolClass cls in classes)
                    {
                        if (cls.schoolName == sc.student.schoolName && (cls.timeTableIndex / 100 == sc.student.classOf / 100))
                        {
                            table[(cls.timeTableIndex / 10) % 10 - 1][cls.timeTableIndex % 10 - 1].Content = cls.subject;
                        }
                    }
                }
                else MessageBox.Show("시간표를 불러오는데 실패했습니다.");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("시간표를 불러오는데 실패했습니다.\n" + ex.Message);
            }
        }
    }
}
