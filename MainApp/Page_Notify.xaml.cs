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
    public class Notify
    {
        public int id { get; set; }
        public string title { get; set; }
        public string desc { get; set; }

    }

    /// <summary>
    /// Interaction logic for Page_Notify.xaml
    /// </summary>
    public partial class Page_Notify : Page
    {
        public Page_Notify()
        {
            InitializeComponent();

            ListView_Output.Items.Add(new Notify()
            {
                title = "경쟁게임의 등급이 곧 발표됩니다.",
                desc="자세한 정보는 leagueoflegends.co.kr 에서 확인하세요.",
                id = 0
            });

            ListView_Output.Items.Add(new Notify()
            {
                title = "택견 단증, 단기 속성반 모집합니다.",
                desc = "희망자는 아침 6시까지 대니산 정상에서 한국택견 부회장님을 찾아주세요. ",
                id = 1
            });

            ListView_Output.Items.Add(new Notify()
            {
                title = "학생참여 졸업식 행사 진행 위원회 모집안내",
                desc = "학생참여 행사 진행 위원회 위원을 모집하고 있습니다.\n연락처 011-0111-11110\n우대사항: 이전에 행사 진행을 해본 자.",
                id = 2
            });
        }


        private void Add_Notify_Button_Click(object sender, RoutedEventArgs e)
        {
            string title = Interaction.InputBox("공지의 제목을 적어주세요.", "", "");
            if (title == "") return;
            string desc = Interaction.InputBox("공지의 본문을 적어주세요.", "", "");
            ListView_Output.Items.Add(new Notify()
            {
                title = title,
                desc = desc,
                id = ListView_Output.Items.Count
            });
        }

        private void Delete_Notify_Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            foreach (object obj in ListView_Output.Items)
            {
                if (((Notify)obj).id == id)
                {
                    ListView_Output.Items.Remove(obj);
                    break;
                }
            }
        }

        private void Show_Notify_Button_Click(object sender, MouseButtonEventArgs e)
        {
            int id = (int)((TextBox)sender).Tag;
            string desc = "undefine";
            foreach (object obj in ListView_Output.Items)
            {
                if (((Notify)obj).id == id)
                {
                    desc = ((Notify)obj).desc;
                    break;
                }
            }
            MessageBox.Show(desc);

        }
    }
}
