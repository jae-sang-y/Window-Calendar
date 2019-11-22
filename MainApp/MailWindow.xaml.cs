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
using System.Windows.Shapes;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for MailWindow.xaml
    /// </summary>
    public partial class MailWindow : Window
    {
        public class Mail
        {
            public int id { get; set; }
            public string desc { get; set; }
            public string who { get; set; }
            public string date { get; set; }
        }

        public MailWindow()
        {
            InitializeComponent();
            ListView_Output.Items.Add(new Mail()
            {
                id = 0,
                desc = "2020년 꿈키움장학금 대상에 선정된것을 축하합니다\nbit.ly/janghakgum 에서 확인하세요.",
                date = "2019/11/11"
            });
            ListView_Output.Items.Add(new Mail()
            {
                id = 1,
                desc = "김윤수님이 당신을 유니티 그룹에 초대했습니다. \ninvite.dsm.go.kr/unity",
                date = "2019/10/23"
            });
        }

        void Show_Mail_Button_Click(object sender, EventArgs e)
        {

        }
        void Delete_Mail_Button_Click(object sender, EventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            foreach (Mail m in ListView_Output.Items)
            {
                if (m.id == id)
                {
                    ListView_Output.Items.Remove(m);
                    break;
                }
            }
        }
    }
}
