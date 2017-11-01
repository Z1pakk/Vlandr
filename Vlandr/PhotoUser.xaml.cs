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
    /// Логика взаимодействия для PhotoUser.xaml
    /// </summary>
    public partial class PhotoUser : MetroWindow
    {
        public PhotoUser()
        {
            InitializeComponent();
        }

        public Image mPhoto { set { Photo = value; } }

    }
}
