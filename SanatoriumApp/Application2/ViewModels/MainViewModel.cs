using Application2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Application2.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }
        public Page SelectPage(string user)
        {
            if (user == "Администратор")
                return (new AdminPage());
            else
                return(new ManagerPage());
        }
    }
}
