using SanatoriumApp.Models.Entities;
using SanatoriumApp.ViewModels;
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

namespace SanatoriumApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private ManagerViewModel _viewModel;
        internal ManagerWindow(Client client)
        {
            InitializeComponent();
            _viewModel = new ManagerViewModel(client);
            DataContext = _viewModel;
        }
    }
}
