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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using MahApps.Metro.Controls;

namespace Vlandr
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    /// 
    public class TextInputToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Always test MultiValueConverter inputs for non-null
            // (to avoid crash bugs for views in the designer)
            if (values[0] is bool && values[1] is bool)
            {
                bool hasText = !(bool)values[0];
                bool hasFocus = (bool)values[1];

                if (hasFocus || hasText)
                    return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public partial class LoginForm : MetroWindow
    {
        private string _folder;
        public LoginForm()
        {
            InitializeComponent();
            Intilize();
        }
        private void Intilize()
        {
            string temp=System.Reflection.Assembly.GetEntryAssembly().Location;
            string folder = System.IO.Path.GetDirectoryName(temp);
            _folder = folder;
          
            imgBackground.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(folder, "GlobalBackground.jpg")));
        }
        private void Btnclose_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (txtLogin.Text == string.Empty || txtPassword.Text == string.Empty)
            //{
            //    MessageBox.Show("Заповніть повністю всі дані !!!");
            //}
            //else
            //{
                this.Visibility = Visibility.Hidden;
                VlandrForm dlg = new VlandrForm(_folder);
                dlg.ShowDialog();
                this.Visibility = Visibility.Visible;
            //}
        }

        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterForm rf = new RegisterForm(_folder);
            rf.ShowDialog();


        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetPasswordForm dlg = new ResetPasswordForm(_folder);
            dlg.ShowDialog();
        }

    }
}
