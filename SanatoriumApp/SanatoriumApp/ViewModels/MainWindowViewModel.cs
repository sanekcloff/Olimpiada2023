using Microsoft.EntityFrameworkCore;
using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SanatoriumApp.ViewModels
{
    internal class MainWindowViewModel:ViewModelBase
    {
        
        public MainWindowViewModel(Client client)
        {
            using (var context = new ApplicationDbContext())
            {
                
            }
        }

    }
}
