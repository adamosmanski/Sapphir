using SapphirApp.Models;
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
    /// Interaction logic for KanbanBoard.xaml
    /// </summary>
    public partial class KanbanBoard : UserControl
    {
        public KanbanBoard()
        {
            InitializeComponent();
            this.DataContext = new KanbanBoardVM();
        }

        private void SfKanban_CardTapped(object sender, Syncfusion.UI.Xaml.Kanban.KanbanTappedEventArgs e)
        {
            var viewModel = (KanbanBoardVM)DataContext;
            //viewModel.Tasks = (List<TaskProject>)e.SelectedCard.Content;
        }
    }
}
