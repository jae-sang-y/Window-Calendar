
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
using Newtonsoft.Json;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServerConnector.ServerConnector sc = ServerConnector.ServerConnector.GetInstace();
        public MainWindow()
        {

            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            Register();
        }

        private void Login() 
        { 
            sc.student.id = ID_input.Text;
            sc.student.password = PWD_Input.Password;
            sc.student.admin = true;

            string test = JsonConvert.SerializeObject(sc.student);

            try
            {
                HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest("loginUser", "POST", test);

                if (status == HttpStatusCode.OK)
                {
                    sc.student = JsonConvert.DeserializeObject<ServerConnector.Student>(res);
                    LoginError_Output.Content = "로그인 성공";
                    
                    var ExampleWindowObject = new WorkWindow();
                    ExampleWindowObject.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    ExampleWindowObject.Show();
                    this.Close();
                }
                else LoginError_Output.Content = "로그인에 실패했습니다.\n아이디와 비밀번호를 확인해주세요.";
            }
            catch (WebException ex)
            {
                LoginError_Output.Content = "로그인에 실패했습니다.\n아이디와 비밀번호를 확인해주세요.\n" + ex.Message;
            }
            catch (TimeoutException)
            {
                LoginError_Output.Content = "응답시간을 초과했습니다.\n인터넷 상태를 확인해주세요.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Register()
        {
            sc.student.id = Register_ID_input.Text;
            sc.student.password = Register_PWD_Input.Password;
            sc.student.admin = true;

            if (Register_PWD_Input.Password != Register_Repeat_PWD_Input.Password)
            {
                Register_PWD_Input.Clear();
                Register_Repeat_PWD_Input.Clear();
                RegisterError_Output.Content = "비밀번호와 비밀번호 재입력이 일치하지 않습니다.";
                return;
            }

            string test = JsonConvert.SerializeObject(sc.student);

            try
            {
                HttpStatusCode status;
                string res;
                (status, res) = sc.SendRequest("join", "POST", test);

                if (status == HttpStatusCode.OK)
                {
                    sc.student = JsonConvert.DeserializeObject<ServerConnector.Student>(res);
                    RegisterError_Output.Content = "회원가입에 성공했습니다";
                }
                else RegisterError_Output.Content = "회원가입에 실패했습니다.";
            }
            catch (WebException ex)
            {
                RegisterError_Output.Content = "회원가입에 실패했습니다.\n" + ex.Message;
            }
            catch (TimeoutException)
            {
                RegisterError_Output.Content = "응답시간을 초과했습니다.\n인터넷 상태를 확인해주세요.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
