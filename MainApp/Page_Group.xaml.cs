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
    public class Group
    {
        public int id { get; set; }
        public string title { get; set; }
    }


    /// <summary>
    /// Interaction logic for Page_Group.xaml
    /// </summary>
    public partial class Page_Group : Page
    {
        public Page_Group()
        {
            InitializeComponent();
            ListView_Output.Items.Add(new Group()
            {
                id = 0,
                title = "마동석과 친구들"
            });
        }

        void Manage_Group_Member_Menu(object sender, EventArgs e)
        {
            new Member_Window((int)((MenuItem)sender).Tag).ShowDialog();
        }
        void Edit_Group_Name_Menu(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("그룹의 새 이름을 적어주세요.", "", "");
            if (name == "") return;
            int id = (int)(((MenuItem)sender).Tag);

            foreach (Group g in ListView_Output.Items)
            {
                if (g.id == id)
                {
                    g.title = name;
                    break;
                }
            }

            ICollectionView view = CollectionViewSource.GetDefaultView(ListView_Output.Items);
            view.Refresh();
        }
        void Delete_Group_Menu(object sender, EventArgs e)
        {
            int id = (int)(((MenuItem)sender).Tag);

            foreach (Group g in ListView_Output.Items)
            {
                if (g.id == id)
                {
                    ListView_Output.Items.Remove(g);
                    break;
                }
            }
        }

        void Add_Group_Button(object sender, EventArgs e)
        {

            string name = Interaction.InputBox("만들 그룹의 이름을 적어주세요.", "", "");
            if (name == "") return;
            ListView_Output.Items.Add(new Group()
            {
                id = 1,
                title = name
            });
        }
    }
}
