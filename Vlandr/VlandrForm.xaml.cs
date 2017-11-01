using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Threading;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace Vlandr
{
    /// <summary>
    /// Interaction logic for VlandrForm.xaml
    /// </summary>
    public class Friends
    {
        public string  Name { get; set; }
        public string From { get; set; }
        public BitmapImage FromImage { get; set; }
    }

    public class PeopleMessage
    {
        public string Name { get; set; }
        public BitmapImage FromImage { get; set; }
        public int Id { get; set; }


    }

    public class Records
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public BitmapImage FromImage { get; set; }
    }

    public class MyPhoto
    {
        public BitmapImage FromImage { get; set; }
    }

    public class Items
    {
        public string Text { get; set; }
        public string timeSend { get; set; }
        public string timeRead { get; set; }
        public bool SentByMe { get; set; }
    }

    public partial class VlandrForm : MetroWindow
    {
        bool check = false;
        private string _folder;

        public VlandrForm(string Folder)
        {

            
            InitializeComponent();

           
            _folder = Folder;
            Initilize();
        }

        private void Initilize()
        {
            SVMessages.ScrollToEnd();
            #region Images
            imgBackground.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "GlobalBackground.jpg")));
            userPhoto.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "NaFz7avVKVY.jpg")));
           
            
            userPhotoMini.ImageSource= new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "user.png")));
            BackgroundMessage.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "weather.png")));

            #endregion
            #region TestAdd
            Friends friends = new Friends()
            {
                Name = "Vlad Shumskiy",
                From = "Rivne",
                FromImage = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "user.png")))
            };
            Friends friends2 = new Friends()
            {
                Name = "Andriy Riabuy",
                From = "Rivne",
                FromImage = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "user.png")))
            };

            Records news = new Records()
            {
                Name = "Andriy Riabuy",
                Text = "Windows Presentation Foundation (WPF) — система для построения клиентских приложений Windows с визуально привлекательными возможностями взаимодействия с пользователем, графическая (презентационная) подсистема в составе .NET Framework (начиная с версии 3.0), использующая язык XAML.",
                FromImage = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "user.png")))
            };

            MyPhoto MyPhoto = new MyPhoto()
            {
               FromImage = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "79aOACVFyn0.jpg")))
            };
            MyPhoto MyPhoto1 = new MyPhoto()
            {
                FromImage = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "lnIt5ZWw5PQ.jpg")))
            };
            lvPhoto.Items.Add(MyPhoto);
            lvPhoto.Items.Add(MyPhoto1);
            lvPhoto.Items.Add(MyPhoto);
            lvPhoto.Items.Add(MyPhoto1);
            lvPhoto.Items.Add(MyPhoto);
            lvPhoto.Items.Add(MyPhoto1);


            lbRecords.Items.Add(news);
            lbRecords.Items.Add(news);




            PeopleMessage user = new PeopleMessage()
            {
                Name = "Влад Шумський",
                FromImage = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "79aOACVFyn0.jpg"))),
                Id = 1
            };

            PeopleMessage user1 = new PeopleMessage()
            {
                Name = "Андрій Рябий",
                FromImage = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "lnIt5ZWw5PQ.jpg"))),
                Id = 2
            };

            lvFriends.Items.Add(user);
            lvFriends.Items.Add(user1);
          




            tcMessage.Items.Add(user);
            tcMessage.Items.Add(user);
            tcMessage.Items.Add(user);

            lbFriends.Items.Add(friends);
            Items item = new Items()
            {
                Text = "Курсач готов?",
                timeSend = DateTime.Now.ToLocalTime().ToString(),
                timeRead = DateTime.UtcNow.Subtract(TimeSpan.FromDays(1.3)).ToShortDateString(),
                SentByMe=false
            };
            Items item2 = new Items()
            {
                Text = "Ага)Конешно",
                timeSend = DateTime.Now.ToLocalTime().ToString(),
                timeRead = DateTime.UtcNow.Subtract(TimeSpan.FromDays(1.3)).ToShortDateString(),
                SentByMe = true
            };
            myItemsControl.Items.Add(item);
            myItemsControl.Items.Add(item2);
            myItemsControl.Items.Add(item);
            #endregion

        }
        #region Menu
        //Метод по анімації вихода
        private void ShowHideMenu(string Storyboard, TextBlock btnShow, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        //Анімація ухода
        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Storyboard sb;
            sb = Resources["sbHideLeftMenu"] as Storyboard;
            sb.Completed += new EventHandler(sb_Completed);
            if (check == true)
            {
                sb.Begin(pnlLeftMenu);
                check = false;
            }
        }

        void sb_Completed(object sender, EventArgs e)
        {
            btnLeftMenuShow.Visibility = Visibility.Visible;
            MEnuBorder.Visibility = Visibility.Hidden;
            Logo.Visibility = Visibility.Hidden;
            Logo2.Visibility = Visibility.Hidden;

            UserPhotoMini.Visibility = Visibility.Hidden;

            MyFriens.Visibility = Visibility.Hidden;
            MyMessge.Visibility = Visibility.Hidden;
            MyProfile.Visibility = Visibility.Hidden;
            Setting.Visibility = Visibility.Hidden;
            tbExit.Visibility = Visibility.Hidden;
        }

        //Анімація вихода
        private void btnLeftMenuShow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MEnuBorder.Visibility = Visibility.Visible;
            Logo.Visibility = Visibility.Visible;
            Logo2.Visibility = Visibility.Visible;

            UserPhotoMini.Visibility = Visibility.Visible;

            MyFriens.Visibility = Visibility.Visible;
            MyMessge.Visibility = Visibility.Visible;
            MyProfile.Visibility = Visibility.Visible;
            Setting.Visibility = Visibility.Visible;
            tbExit.Visibility = Visibility.Visible;
            ShowHideMenu("sbShowLeftMenu", btnLeftMenuShow, pnlLeftMenu);
            check = true;
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            GridMyfriends.Visibility = System.Windows.Visibility.Hidden;
            GridMyProfile.Visibility = System.Windows.Visibility.Hidden;
            GridSettings.Visibility = System.Windows.Visibility.Visible;
            GridMyMessage.Visibility = Visibility.Hidden;
            GridMyFriend.Visibility = System.Windows.Visibility.Hidden;


        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            GridMyProfile.Visibility = System.Windows.Visibility.Visible;
            GridSettings.Visibility = System.Windows.Visibility.Hidden;
            GridMyfriends.Visibility = System.Windows.Visibility.Hidden;
            GridMyMessage.Visibility = Visibility.Hidden;
            GridMyFriend.Visibility = System.Windows.Visibility.Hidden;



        }

        private void btnExit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ви точно бажаєте вийти з аккаунта?", "Підтвердження", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void MyFriens_Click(object sender, RoutedEventArgs e)
        {
            GridMyfriends.Visibility = System.Windows.Visibility.Visible;
            GridSettings.Visibility = System.Windows.Visibility.Hidden;
            GridMyProfile.Visibility = System.Windows.Visibility.Hidden;
            GridMyMessage.Visibility = Visibility.Hidden;
            GridMyFriend.Visibility = System.Windows.Visibility.Hidden;



        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void MyMessge_Click(object sender, RoutedEventArgs e)
        {
            GridMyMessage.Visibility = Visibility.Visible;
            GridMyfriends.Visibility = System.Windows.Visibility.Hidden;
            GridSettings.Visibility = System.Windows.Visibility.Hidden;
            GridMyProfile.Visibility = System.Windows.Visibility.Hidden;
            GridMyFriend.Visibility = System.Windows.Visibility.Hidden;

        }
        #endregion
       

        private void Grid_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                userPhoto.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(openFileDialog.FileName)));
        }

        private void lvPhoto_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PhotoUser dlg = new PhotoUser();
            dlg.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditProfile dlg = new EditProfile();
            dlg.ShowDialog();
        }

        #region EditSettings
        private void tbEditPassword_Click(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Text = tbPassword.Text;
            txtPassword.Visibility = Visibility.Visible;
            tbPassword.Visibility = Visibility.Hidden;
            tbEditPassword.Visibility = Visibility.Hidden;
            tbEditCancelPassword.Visibility = Visibility.Visible;
            tbEditOKPassword.Visibility = Visibility.Visible;
        }

        private void tbEditPasswordCancel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Visibility = Visibility.Hidden;
            tbPassword.Visibility = Visibility.Visible;
            tbEditPassword.Visibility = Visibility.Visible;
            tbEditCancelPassword.Visibility = Visibility.Hidden;
            tbEditOKPassword.Visibility = Visibility.Hidden;
        }

        private void tbEditPasswordOK_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbPassword.Text = txtPassword.Text;
            txtPassword.Visibility = Visibility.Hidden;
            tbPassword.Visibility = Visibility.Visible;
            tbEditPassword.Visibility = Visibility.Visible;
            tbEditCancelPassword.Visibility = Visibility.Hidden;
            tbEditOKPassword.Visibility = Visibility.Hidden;
        }

        private void tbEditEmail_Click(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Text = tbEmail.Text;
            txtEmail.Visibility = Visibility.Visible;
            tbEmail.Visibility = Visibility.Hidden;
            tbEditEmail.Visibility = Visibility.Hidden;
            tbEditCancelEmail.Visibility = Visibility.Visible;
            tbEditOKEmail.Visibility = Visibility.Visible;
        }

        private void tbEditEmailCancel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Visibility = Visibility.Hidden;
            tbEmail.Visibility = Visibility.Visible;
            tbEditEmail.Visibility = Visibility.Visible;
            tbEditCancelEmail.Visibility = Visibility.Hidden;
            tbEditOKEmail.Visibility = Visibility.Hidden;
        }

        private void tbEditEmailOK_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbEmail.Text = txtEmail.Text;
            txtEmail.Visibility = Visibility.Hidden;
            tbEmail.Visibility = Visibility.Visible;
            tbEditEmail.Visibility = Visibility.Visible;
            tbEditCancelEmail.Visibility = Visibility.Hidden;
            tbEditOKEmail.Visibility = Visibility.Hidden;
        }

        private void tbEditPhone_Click(object sender, MouseButtonEventArgs e)
        {
            txtPhone.Text = tbPhone.Text;
            txtPhone.Visibility = Visibility.Visible;
            tbPhone.Visibility = Visibility.Hidden;
            tbEditPhone.Visibility = Visibility.Hidden;
            tbEditCancelPhone.Visibility = Visibility.Visible;
            tbEditOKPhone.Visibility = Visibility.Visible;
        }

        private void tbEditPhoneCancel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbPhone.Text = txtPhone.Text;
            txtPhone.Visibility = Visibility.Hidden;
            tbPhone.Visibility = Visibility.Visible;
            tbEditPhone.Visibility = Visibility.Visible;
            tbEditCancelPhone.Visibility = Visibility.Hidden;
            tbEditOKPhone.Visibility = Visibility.Hidden;
        }

        private void tbEditPhoneOK_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbPhone.Text = txtPhone.Text;
            txtPhone.Visibility = Visibility.Hidden;
            tbPhone.Visibility = Visibility.Visible;
            tbEditPhone.Visibility = Visibility.Visible;
            tbEditCancelPhone.Visibility = Visibility.Hidden;
            tbEditOKPhone.Visibility = Visibility.Hidden;
        }
        #endregion
    }

    

}
