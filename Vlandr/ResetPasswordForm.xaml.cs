using MahApps.Metro.Controls;
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

namespace Vlandr
{
    /// <summary>
    /// Interaction logic for ResetPasswordForm.xaml
    /// </summary>
    public partial class ResetPasswordForm : MetroWindow
    {
        private string _folder;
        public ResetPasswordForm(string folder)
        {
            _folder = folder;
            InitializeComponent();
            Intilize();
        }

        private void Intilize()
        {
            imgBackground.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "GlobalBackground.jpg")));
        }
    }
}
