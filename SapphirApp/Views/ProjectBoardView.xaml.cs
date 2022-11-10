using SapphirApp.ViewModels;
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

namespace SapphirApp.Views
{
    /// <summary>
    /// Interaction logic for ProjectBoard.xaml
    /// </summary>
    public partial class ProjectBoardView : UserControl
    {
        public ProjectBoardView()
        {
            InitializeComponent();
            DataContext = new ProjectBoardVM();
        }
    }
}
