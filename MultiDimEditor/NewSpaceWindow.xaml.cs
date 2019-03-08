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
    /// Логика взаимодействия для NewSpaceWindow.xaml
    /// </summary>
    public partial class NewSpaceWindow : Window
    {
        public Users user { get; set; }
        public Spaces NewSpace { get; private set; }
        public NewSpaceWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int dimnum=0;
            bool check=int.TryParse(tbDims.Text, out dimnum);
            if(!check || dimnum<1)
            {
                MessageBox.Show("Incorrect dimention number: must be a positive integer greater than 0");
                return;
            }
            Space spc = new Space(dimnum);
            Spaces sp = new Spaces()
            {
                Name = tbSpaceName.Text,
                CreatorID = user.USER_ID,
                Content = spc.ToString(),
                EditorPassword = (cbEdit.IsChecked == true) ? tbEdPass.Text : null,
                FreePassword = (cbFView.IsChecked == true) ? tbFViewPass.Text : null,
                LockedPassword = (cbLView.IsChecked == true) ? tbLViewPass.Text : null,
                SPACE_ID = Guid.NewGuid()
            };
            NewSpace = sp;
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
