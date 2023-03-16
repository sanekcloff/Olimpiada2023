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

            var newCostPerDay = new ServiceCost 
            { 
                Cost = _viewModel.SelectedProgram.Cost + _viewModel.SelectedRoom.SanatoriumRoomCategory.Cost,
                SanatoriumProgramId = _viewModel.SelectedProgram.Id, 
                SanatoriumRoomId = _viewModel.SelectedRoom.Id
            };
            CostPerDayService.AddCostPerDay(ref newCostPerDay);
            var newTreaty = new Treaty
            {
                DateOfConclusion = DateTime.Now,
                DateOfCheckIn = _viewModel.DateOfCheckIn,
                DateOfCheckOut = _viewModel.DateOfCheckOut,
                PaymentAmount = _viewModel.PaymentAmount,
                PaymentMethodId = _viewModel.SelectedPaymentMethod.Id,
                ClientId = _viewModel.SelectedClient.Id,
                CostPerDayId = newCostPerDay.Id,
                CostPerDay = newCostPerDay
            };
            TreatiesService.AddTreaty(newTreaty);
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

        private void AddClientMenuItem_Click(object sender, RoutedEventArgs e)
        {
            new CreateClientWindow()
                .ShowDialog();
        }

        private void UpdateClientsList_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Clients=ClientService.GetAllClients();
        }

        private void RemoveClientMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ClientService.RemoveClient(_viewModel.SelectedClient);
            _viewModel.Clients = ClientService.GetAllClients();
        }
    }
}
