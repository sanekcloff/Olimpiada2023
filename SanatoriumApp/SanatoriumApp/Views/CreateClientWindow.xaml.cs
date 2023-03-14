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
    /// Логика взаимодействия для CreateClientWindow.xaml
    /// </summary>
    public partial class CreateClientWindow : Window
    {
        private CreateClientViewModel _viewModel;
        public CreateClientWindow()
        {
            InitializeComponent();
            _viewModel= new CreateClientViewModel();
            DataContext = _viewModel;
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            ClientService.AddClient(new Client
            {
                FirstName=_viewModel.FirstName,
                LastName=_viewModel.LastName,
                MiddleName=_viewModel.MiddleName,
                DateOfBirth=_viewModel.DateOfBirth,
                Gender = _viewModel.Gender[_viewModel.Gender.Length-1],
                PassportSeries=_viewModel.PassportSeries,
                PassportNumber=_viewModel.PassportNumber
            });
        }
    }
}
