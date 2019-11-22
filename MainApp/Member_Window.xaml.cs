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
using System.Windows.Shapes;

namespace MainApp
{
    public class Member
    {
        public int id { get; set; }
        public int right { get; set; }
        public int uid { get; set; }
        public string state { get; set; }
        public string  name { get; set; }
        public string classof { get; set; }
    }

    /// <summary>
    /// Interaction logic for Member_Window.xaml
    /// </summary>
    public partial class Member_Window : Window
    {
        private int groupid;
        public Member_Window(int gid)
        {
            InitializeComponent();
            groupid = gid;

            ListView_Output.Items.Add(
                    new Member()
                    {
                        id = 4,
                        right = 3,
                        uid = 7,
                        name = "김민수",
                        state = "관리자",
                        classof = "4학년 5반"
                    }
                );

            ListView_Output.Items.Add(
                    new Member()
                    {
                        id = 5,
                        right = 0,
                        uid = 4,
                        name = "신민수",
                        state = "쓰기가능",
                        classof = "6학년 3반"
                    }
                );

            ListView_Output.Items.Add(
                    new Member()
                    {
                        id = 0,
                        right = 1,
                        uid = 0,
                        name = "하민수",
                        state = "읽기가능",
                        classof = "2학년 2반"
                    }
                );
            ListView_Output.Items.Add(
                    new Member()
                    {
                        id = 1,
                        right = 0,
                        uid = 3,
                        name = "구인수",
                        state = "가입 대기중",
                        classof = "1학년 1반"
                    }
                );
        }

        void Kick_Member_Menu(object sender, EventArgs e)
        {
            int id = (int)(((MenuItem)sender).Tag);
            foreach (Member m in ListView_Output.Items)
            {
                if (m.id == id)
                {
                    ListView_Output.Items.Remove(m);
                    break;
                }
            }
        }
        void Manage_Permission_Menu(object sender, EventArgs e)
        {
            int level = int.Parse(Interaction.InputBox("새 권한수준을 적어주세요.\n없음:0, 보기:1, 쓰기:2, 관리자:3", "", ""));
            int id = (int)(((MenuItem)sender).Tag);
            foreach (Member m in ListView_Output.Items)
            {
                if (m.id == id)
                {
                    m.right = level;
                    switch (level)
                    {
                        case 0:
                            m.state = "없음";
                            break;
                        case 1:
                            m.state = "보기가능";
                            break;
                        case 2:
                            m.state = "쓰기가능";
                            break;
                        case 3:
                            m.state = "관리자";
                            break;
                    }
                    break;
                }
            }

            ICollectionView view = CollectionViewSource.GetDefaultView(ListView_Output.Items);
            view.Refresh();
        }

        void Add_Member_Button(object sender, EventArgs e)
        {
            ListView_Output.Items.Add(
                    new Member()
                    {
                        id = 2,
                        right = 0,
                        uid = 2,
                        name = "누구나",
                        state = "가입 대기중",
                        classof = "1학년 1반"
                    }
                );
        }
    }
}
