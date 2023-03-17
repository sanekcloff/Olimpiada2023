using Application2.Entities;
using Application2.Services;
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
using System.Windows.Shapes;

namespace Application2.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        internal MainWindow(string user)
        {
            InitializeComponent();
            _viewModel = (MainViewModel)DataContext;
            Title = $"Роль: {user}";
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            var canExecute = ClientService.AddClient(
                new Client(_viewModel.LastName, _viewModel.FirstName, _viewModel.MiddleName,_viewModel.DateOfBirth, _viewModel.SelectedGender[_viewModel.SelectedGender.Length-1],_viewModel.PassportNumber, _viewModel.PassportSeries));
            if (canExecute)  _viewModel.ResetValues();
        }

        private void AddContrctButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
