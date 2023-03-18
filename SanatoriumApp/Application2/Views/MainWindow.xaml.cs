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
            var canExecute = _viewModel.ClientService.Insert(
                new Client(_viewModel.LastName, _viewModel.FirstName, _viewModel.MiddleName,_viewModel.DateOfBirth, _viewModel.SelectedGender[_viewModel.SelectedGender.Length-1],_viewModel.PassportNumber, _viewModel.PassportSeries));
            if (canExecute)
            {
                _viewModel.ResetValues();
                _viewModel.UpdateLists();
            }
        }

        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            var canExecute = _viewModel.ContractService.Insert
                (new Contract(DateTime.Now, _viewModel.DateOfCheckIn, _viewModel.DateOfCheckOut, _viewModel.PaymentAmount, _viewModel.SelectedPaymentMethod, _viewModel.SelectedClient, _viewModel.SelectedSanatoriumProgram, _viewModel.SelectedSanatoriumRoom));
            if (!canExecute) MessageBox.Show("Все полядолжны быть заполнены!");
            else MessageBox.Show("Договор оформлен!");
        }
    }
}
