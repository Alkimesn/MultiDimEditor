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
    /// Логика взаимодействия для UserControlWindow.xaml
    /// </summary>
    public partial class UserControlWindow : Window
    {
        DBModelDataContext dc;
        Users curUser = null;
        public UserControlWindow()
        {
            InitializeComponent();
            dc = new DBModelDataContext();
            cbAllUsers.ItemsSource = dc.Users;
        }
        void SelectUser(Users user)
        {
            cbAllUsers.SelectedItem = user;
            tbFindUser.Text = user.Name;
            if (user.Access_type == 3)
            {
                MessageBox.Show("Can't edit or remove administrator level user");
                btnRemUser.IsEnabled = false;
                cbLevel.IsEnabled = false;
                return;
            }
            btnRemUser.IsEnabled=true;
            cbLevel.IsEnabled=true;
            curUser = user;
            cbLevel.SelectedItem = user.Access_type;
        }
        void UnSelectUser()
        {
        }

        private void cbAllUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbFindUser.Text = ((Users)e.AddedItems[0]).Name;
        }

        private void tbFindUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void cbLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (curUser == null) return;
            curUser.Access_type = (int)e.AddedItems[0];
            dc.SubmitChanges();
        }

        private void btnRemUser_Click(object sender, RoutedEventArgs e)
        {
            dc.Users.DeleteOnSubmit(curUser);
            dc.SubmitChanges();
        }

        private void btnSel_Click(object sender, RoutedEventArgs e)
        {
            var qu = from u in dc.Users
                     where u.Name == tbFindUser.Text
                     select u;
            if (qu.Count() == 0) MessageBox.Show("No user found with this name");
            else SelectUser(qu.Single());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DBMethods.IsLoginExist(tbNewLogin.Text)) MessageBox.Show("This name is already used");
            else DBMethods.RegisterNewUser(tbNewLogin.Text, tbNewPassword.Text, (int)cbNewLevel.SelectedValue);
        }
    }
}
