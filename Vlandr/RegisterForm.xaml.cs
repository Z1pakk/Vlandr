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
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : MetroWindow
    {
        public string  _folder { get; set; }
        public RegisterForm(string Folder)
        {
            InitializeComponent();
            _folder = Folder;
            Initilize();
                
        }
        public void Initilize()
        {
            imgBackground.ImageSource= new BitmapImage(new Uri(System.IO.Path.Combine(_folder, "GlobalBackground.jpg")));
        }
    }
}
