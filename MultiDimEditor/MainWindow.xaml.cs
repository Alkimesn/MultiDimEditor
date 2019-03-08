using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MultiDimEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TransformList tlist;
        Space currentspace;
        DBModelDataContext dc;
        ObservableCollection<Views> userViews = new ObservableCollection<Views>();
        ObservableCollection<Spaces> userSpaces = new ObservableCollection<Spaces>();
        Users currentuser = null;
        Views currentview = null;
        List<Control> lvl1Controls;
        List<Control> lvl2Controls;
        DrawingRules currules;
        public MainWindow()
        {
            InitializeComponent();
            dc = new DBModelDataContext();
            cbViews.ItemsSource = userViews;
            cbSpaces.ItemsSource = userSpaces;
            lvl2Controls = new List<Control>();
            lvl2Controls.Add(btnNewSpace);

            lvl1Controls = new List<Control>();
            lvl1Controls.Add(cbViews);
            lvl1Controls.Add(cbSpaces);
            lvl1Controls.Add(btnOpenSpace);
            lvl1Controls.Add(btnOpenView);
            lvl1Controls.AddRange(lvl2Controls);
            SwitchControls(0);
            SwitchDrawControls(-1);
            currules = new DrawingRules();
            cbPointNormal.ItemsSource = DrawingRules.AllColors;
            cbPointSelected.ItemsSource = DrawingRules.AllColors;
            cbLineNormal.ItemsSource = DrawingRules.AllColors;
            cbLineNormal.ItemsSource = DrawingRules.AllColors;
            cbFaceNormal.ItemsSource = DrawingRules.AllColors;
            cbFaceSelected.ItemsSource = DrawingRules.AllColors;
        }
        void SwitchControls(int access_type)
        {
            if (access_type == 0)
                foreach (var c in lvl1Controls) c.IsEnabled = false;
            else if(access_type==1)
            {
                foreach (var c in lvl1Controls) c.IsEnabled = true;
                foreach (var c in lvl2Controls) c.IsEnabled = false;
            }
            else if(access_type>=2)
                foreach (var c in lvl1Controls) c.IsEnabled = true;
        }
        void SwitchDrawControls(int access_type)
        {//-1 means no view loaded
            foreach (var ctrl in grDrawOptions.Children) ((Control)ctrl).IsEnabled = (access_type > -1);
            foreach (var ctrl in grViewOptions.Children) ((Control)ctrl).IsEnabled = (access_type > 0);
            foreach (var ctrl in grSpaceOptions.Children) ((Control)ctrl).IsEnabled = (access_type > 1);
        }
        void Draw()
        {
            DrawSame();
            cbPickPoint.Items.Clear();
            cbPickEdgePoint1.Items.Clear();
            cbPickEdgePoint2.Items.Clear();
            for (int i = 0; i < currentspace.points.Count; i++)
            {
                cbPickPoint.Items.Add(i);
                cbPickEdgePoint1.Items.Add(i);
                cbPickEdgePoint2.Items.Add(i);
            }
            cbPickEdge.Items.Clear();
            for (int i = 0; i < currentspace.edges.Count; i++)
            {
                cbPickEdge.Items.Add(i);
            }
            cbPickFace.Items.Clear();
            for (int i = 0; i < currentspace.faces.Count; i++)
            {
                cbPickFace.Items.Add(i);
            }
        }
        void DrawSame()
        {
            if (currentview == null) return;
            DrawingVisual dv = new DrawingVisual();
            Point center = new Point(cnvDraw.ActualWidth / 2, cnvDraw.ActualHeight / 2);
            using (DrawingContext dc = dv.RenderOpen())
            {
                currentspace.Draw(dc, center, tlist, currules, cbPickPoint.SelectedIndex, cbPickEdge.SelectedIndex);
            }
            VisualHost vh = new VisualHost() { visual = dv };
            cnvDraw.Children.Clear();
            cnvDraw.Children.Add(vh);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void cbViews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dc.Connection.Close();
        }
        void UpdateUserLists()
        {
            foreach (var view in currentuser.Views)
                userViews.Add(view);
            foreach (var sp in dc.Spaces)
                if (sp.Creator.USER_ID == currentuser.USER_ID || sp.EditorPassword != null || sp.FreePassword != null || sp.LockedPassword != null)
                    userSpaces.Add(sp);
        }
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            userViews.Clear();
            userSpaces.Clear();
            SwitchControls(0);
            var logwnd = new LoginWindow();
            if(logwnd.ShowDialog()==true)
            {
                var us = logwnd.User;
                currentuser = us;
                int access = us.Access_type;
                SwitchControls(access);
                if(access==0)
                {
                    MessageBox.Show("You were banned");
                    return;
                }
                if(access>=1)
                {
                    UpdateUserLists();
                }
                if(access>=2)
                {
                }
                if(access==3)
                {
                    UserControlWindow ucw = new UserControlWindow();
                    ucw.Show();
                }
                SwitchDrawControls(-1);
            }
        }
        void ViewOpen()
        {
            currentspace = Space.Parse(currentview.Space.Content);
            tlist = new TransformList(Space.Parse(currentview.Space.Content).dimnum);
            tlist.AddLast(TransformDouble.Parse(currentview.Transform));
            UpdateUserLists();
            SwitchDrawControls(currentview.Access_type);
            cbRotStart.Items.Clear();
            cbRotEnd.Items.Clear();
            cbScaleCoord.Items.Clear();
            cbShiftCoord.Items.Clear();
            cbPickPointCoord.Items.Clear();
            for (int i = 0; i < currentspace.dimnum; i++)
            {
                cbRotStart.Items.Add(i + 1);
                cbRotEnd.Items.Add(i + 1);
                cbScaleCoord.Items.Add(i + 1);
                cbShiftCoord.Items.Add(i + 1);
                cbPickPointCoord.Items.Add(i + 1);
            }
            Draw();
        }
        private void btnOpenSpace_Click(object sender, RoutedEventArgs e)
        {
            if(cbSpaces.SelectedItem==null)
            {
                MessageBox.Show("No space chosen");
                return;
            }
            OpenSpaceWindow osw = new OpenSpaceWindow(currentuser, (Spaces)cbSpaces.SelectedItem);
            if(osw.ShowDialog()==true)
            {
                Spaces cursp=(Spaces)cbSpaces.SelectedItem;
                //Views view = new Views(){Name=osw.Name, Access_type=osw.Level, SpaceID=cursp.SPACE_ID, UserID=currentuser.USER_ID, Transform=TransformDouble.GetIdentityTransform(Space.Parse(cursp.Content).dimnum).ToString(), VIEW_ID=Guid.NewGuid()};
                Views view = osw.Resultview;
                currentview = view;
                dc.Views.InsertOnSubmit(view);
                
                dc.SubmitChanges();
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dc.Views);
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dc.Users);
                ViewOpen();
            }
        }

        private void btnOpenView_Click(object sender, RoutedEventArgs e)
        {
            if (cbViews.SelectedItem == null)
            {
                MessageBox.Show("No space chosen");
                return;
            }
            Views view = (Views)cbViews.SelectedItem;
            currentview = view;
            ViewOpen();
        }

        private void btnNewSpace_Click(object sender, RoutedEventArgs e)
        {
            NewSpaceWindow nsw = new NewSpaceWindow();
            nsw.user = currentuser;
            if(nsw.ShowDialog()==true)
            {
                dc.Spaces.InsertOnSubmit(nsw.NewSpace);
                dc.SubmitChanges();
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dc.Views);
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dc.Users);
                UpdateUserLists();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double angle = 0;
            if(!double.TryParse(tbAngle.Text, out angle))
            {
                MessageBox.Show("Turn angle must be a number");
                return;
            }
            if(cbRotStart.SelectedIndex<0||cbRotEnd.SelectedIndex<0||cbRotStart.SelectedIndex==cbRotEnd.SelectedIndex)
            {
                MessageBox.Show("Select a start and end axis. They must not be equal");
                return;
            }
            TransformMatrix tm = new TransformMatrix(DMatrix.GetRotMatrix(currentspace.dimnum, cbRotStart.SelectedIndex, cbRotEnd.SelectedIndex, angle));
            tlist.AddLast(tm);
            Draw();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var q = from v in dc.Views
                    where v.VIEW_ID == currentview.VIEW_ID
                    select v;
            q.First().Transform = tlist.ToString();
            dc.SubmitChanges();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            double scale = 0;
            if (!double.TryParse(tbScaleVal.Text, out scale))
            {
                MessageBox.Show("Scale must be a number");
                return;
            }
            if(cbScaleCoord.SelectedIndex<0)
            {
                MessageBox.Show("Incorrect coordinate for scaling");
                return;
            }
            TransformScale ts = new TransformScale(currentspace.dimnum, cbScaleCoord.SelectedIndex,scale);
            tlist.AddLast(ts);
            Draw();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            double shift = 0;
            if (!double.TryParse(tbShiftVal.Text, out shift))
            {
                MessageBox.Show("Shift must be a number");
                return;
            }
            if (cbShiftCoord.SelectedIndex < 0)
            {
                MessageBox.Show("Incorrect coordinate for shifting");
                return;
            }
            TransformVector tv = new TransformVector(DVector.GetOrt(cbShiftCoord.SelectedIndex, currentspace.dimnum)*shift);
            tlist.AddLast(tv);
            Draw();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            double val = 0;
            if (!double.TryParse(tbSetPointCoord.Text, out val))
            {
                MessageBox.Show("Coordinate value must be a number");
                return;
            }
            if (cbPickPointCoord.SelectedIndex < 0)
            {
                MessageBox.Show("Incorrect coordinate selection");
                return;
            }
            if (cbPickPoint.SelectedIndex < 0)
            {
                MessageBox.Show("Incorrect point selection");
                return;
            }
            currentspace.points[cbPickPoint.SelectedIndex][cbPickPointCoord.SelectedIndex] = val;
            Draw();
        }

        private void cbPickPointCoord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPickPoint.SelectedIndex >=0)
                tbSetPointCoord.Text = currentspace.points[cbPickPoint.SelectedIndex][cbPickPointCoord.SelectedIndex].ToString();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            currentspace.points.Add(new DVector(currentspace.dimnum));
            Draw();
        }

        private void cbPickEdge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPickEdge.SelectedIndex < 0) return;
            cbPickEdgePoint1.SelectedIndex = currentspace.edges[cbPickEdge.SelectedIndex].point1;
            cbPickEdgePoint2.SelectedIndex = currentspace.edges[cbPickEdge.SelectedIndex].point2;
            DrawSame();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            currentspace.edges.Add(new Edge(cbPickEdgePoint1.SelectedIndex, cbPickEdgePoint2.SelectedIndex));
            Draw();
        }

        private void cbPickFace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = "";
            foreach (var p in currentspace.faces[cbPickFace.SelectedIndex].points)
                str += p + " ";
            tbFacePoints.Text = str;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string[] spoints = tbFacePoints.Text.Split(new char[]{' ',','}, StringSplitOptions.RemoveEmptyEntries);
            int[] points;
            try
            {
                points = spoints.Select(x => int.Parse(x)).ToArray();
            }
            catch
            {
                MessageBox.Show("Incorrect number input");
                return;
            }
            currentspace.faces.Add(new Face(points));
        }

        private void cbPickPoint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPickPointCoord.SelectedIndex >= 0&&cbPickPoint.SelectedIndex>=0)
                tbSetPointCoord.Text = currentspace.points[cbPickPoint.SelectedIndex][cbPickPointCoord.SelectedIndex].ToString();
            DrawSame();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            currentspace.edges.Remove(currentspace.edges[cbPickEdge.SelectedIndex]);
            Draw();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            var q = from s in dc.Spaces
                    where s.SPACE_ID == currentview.SpaceID
                    select s;
            q.First().Content = currentspace.ToString();
            dc.SubmitChanges();
        }
    }
}
