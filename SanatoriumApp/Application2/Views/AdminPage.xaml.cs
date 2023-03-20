using Application2.Entities;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private AdminViewModel _viewModel;
        public AdminPage()
        {
            InitializeComponent();
            _viewModel = (AdminViewModel)DataContext;
        }
        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            var canExecute = _viewModel.ClientService.Insert(
                new Client(_viewModel.LastName, _viewModel.FirstName, _viewModel.MiddleName, _viewModel.DateOfBirth, _viewModel.SelectedGender[_viewModel.SelectedGender.Length - 1], _viewModel.PassportNumber, _viewModel.PassportSeries));
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
