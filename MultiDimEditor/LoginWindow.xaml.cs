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

namespace MultiDimEditor
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DBModelDataContext dc;
        public LoginWindow()
        {
            InitializeComponent();
            dc = new DBModelDataContext();
        }
        public Users User { get; private set; }
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            var qauth = from u in dc.Users
                        where (u.Name == tbLogin.Text) && (u.Password == tbPassword.Text)
                        select u;
            if (qauth.Count() == 0) MessageBox.Show("Incorrect login data");
            else
            {
                User = qauth.Single();
                if (User.Login_time == null)
                    DialogResult = true;
                else MessageBox.Show("User is already logged in");
            }
        }

        private void btnRegisterNew_Click(object sender, RoutedEventArgs e)
        {
            if(DBMethods.IsLoginExist(tbLogin.Text)) MessageBox.Show("This name is already used");
            else
            {
                DBMethods.RegisterNewUser(tbLogin.Text, tbPassword.Text, 1);
                btnLogIn_Click(this, e);
            }
        }
    }
}
