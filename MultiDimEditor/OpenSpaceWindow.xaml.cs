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
    /// Логика взаимодействия для OpenSpaceWindow.xaml
    /// </summary>
    public partial class OpenSpaceWindow : Window
    {
        Users curuser;
        Spaces curspace;
        public Views Resultview { get; private set; }
        public OpenSpaceWindow(Users user, Spaces space)
        {
            InitializeComponent();
            curuser = user;
            curspace = space;
            if (space.CreatorID == user.USER_ID)
            {
                cbEdit.IsEnabled = true;
                cbFree.IsEnabled = true;
                cbLocked.IsEnabled = true;
                lblDesc.Content = "You are the owner of this space";
            }
            else
            {
                if (space.EditorPassword == null) cbEdit.IsEnabled = false;
                if (space.FreePassword == null) cbFree.IsEnabled = false;
                if (space.LockedPassword == null) cbLocked.IsEnabled = false;
                lblDesc.Content = "Edit mode " + (space.EditorPassword == null ? "can't be entered; " : space.EditorPassword == " " ? "is free to enter; " : "requires password") + "\n" +
                    "Free view mode " + (space.FreePassword == null ? "can't be entered; " : space.FreePassword == "" ? "is free to enter; " : "requires password") + "\n" +
                    "Locked view mode " + (space.LockedPassword == null ? "can't be entered; " : space.LockedPassword == " " ? "is free to enter; " : "requires password");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string curpass = cbEdit.IsChecked==true ? curspace.EditorPassword : cbFree.IsChecked==true ? curspace.FreePassword : cbLocked.IsChecked==true ? curspace.LockedPassword : null;
            if (curpass == null && curspace.CreatorID != curuser.USER_ID) MessageBox.Show("Can't open this space with chosen access type");
            else if (curpass == "" || curpass == tbPassword.Text || curspace.CreatorID == curuser.USER_ID)
            {
                Views v = new Views() { Access_type = cbEdit.IsChecked == true ? 2 : cbFree.IsChecked == true ? 1 : cbLocked.IsChecked == true ? 0 : -1, Name=tbViewName.Text, UserID=curuser.USER_ID, SpaceID=curspace.SPACE_ID, VIEW_ID=Guid.NewGuid(), Transform=new TransformVector(new DVector(Space.Parse(curspace.Content).dimnum)).ToString() };
                Resultview = v;
                //Name = tbViewName.Text;
                //Level = cbEdit.IsChecked == true ? 2 : cbFree.IsChecked == true ? 1 : cbLocked.IsChecked == true ? 0 : -1;
                DialogResult = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
