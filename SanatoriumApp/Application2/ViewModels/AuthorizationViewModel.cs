using Application2.Data;
using Application2.Entities;
using Application2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Application2.ViewModels
{
    internal class AuthorizationViewModel:ViewModelBase
    {
        private string _login=null!;
        private string _password=null!;
        public string Login 
        { 
            get => _login;
            set => Set(ref _login, value, nameof(Login)); 
        }
        public string Password 
        { 
            get => _password; 
            set => Set(ref _password, value, nameof(Password)); 
        }

        public void Authorization()
        {
            if (Login == User.admin.ToString() && Password == User.admin.ToString())
                new MainWindow("Администратор").ShowDialog();
            else if (Login == User.manager.ToString() && Password == User.manager.ToString())
                new MainWindow("Управляющий").ShowDialog();
            else MessageBox.Show("Данные не верны!");
        }
    }
}
