using SanatoriumApp.Models.Entities;
using SanatoriumApp.Services;
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
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        private AdministratorViewModel _viewModel;
        internal AdministratorWindow(User user)
        {
            InitializeComponent();
            _viewModel = (AdministratorViewModel)DataContext;
        }

        private void AddTreatyButton_Click(object sender, RoutedEventArgs e)
        {
            var newCostPerDay = new CostPerDay
            {
                Cost = _viewModel.CostPerDay,
                SanatoriumRoom = _viewModel.SelectedRoom,
                SanatoriumProgram = _viewModel.SelectedProgram
            };
            CostPerDayService.AddCostPerDay(newCostPerDay);
            TreatiesService.AddTreaty(new Treaty
            {
                DateOfConclusion = DateTime.Now,
                DateOfCheckIn = _viewModel.DateOfCheckIn,
                DateOfCheckOut = _viewModel.DateOfCheckOut,
                PaymentMethod = _viewModel.SelectedPaymentMethod,
                CostPerDay = newCostPerDay,
                Client = _viewModel.SelectedClient,
                PaymentAmount = _viewModel.PaymentAmount
            }); ;
        }

        private void RemoveFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SelectedClient = null!;
            _viewModel.SelectedProgram = null!;
            _viewModel.SelectedRoom = null!;
            _viewModel.DateOfCheckIn= DateTime.Now;
            _viewModel.DateOfCheckOut= DateTime.Now;
            _viewModel.PaymentMethods = null!;
        }
    }
}
