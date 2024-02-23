using BusinessObject.Models;
using Service;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private readonly IUserService userService;

        public WindowLogin()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_Username.Text.Trim();
            string password = txt_Password.Password.Trim();

            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password!!!");
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter username!!!");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter password!!!");
                return;
            }

            User AuthenUser = userService.GetUserByUsernameAndPassword(txt_Username.Text, txt_Password.Password);

            if(AuthenUser != null)
            {

                switch (AuthenUser.UserRole)
                {
                    case 1:
                        WindowAdmin adminWindow = new WindowAdmin();
                        adminWindow.Show();
                        break;
                    case 2:
                        WindowStaff staffWindow = new WindowStaff();
                        staffWindow.Show();
                        break;
                    case 3:
                        WindowCustomer customerWindow = new WindowCustomer();
                        customerWindow.Show();
                        break;
                    default:
                        MessageBox.Show("Unknown user role.");
                        break;
                }
                Close();
            }
            else
            {
                MessageBox.Show("Login failed - Please check your username or password correctly.");
            }
        }
    }
}

