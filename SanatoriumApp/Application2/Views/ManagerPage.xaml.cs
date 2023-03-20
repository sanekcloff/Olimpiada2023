using Application2.ViewModels;
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

namespace Application2.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        private ManagerViewModel _viewModel;
        public ManagerPage()
        {
            InitializeComponent();
            _viewModel=(ManagerViewModel)DataContext;
        }

        private void CheckOutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ChangeRoomStatus();
        }
    }
}
