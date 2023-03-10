using Microsoft.EntityFrameworkCore;
using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using SanatoriumApp.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SanatoriumApp.ViewModels
{
    internal class AuthorizationViewModel : ViewModelBase
    {
        #region Fields & Properties
        private string _login=null!;
        private string _password = null!;
        public string Login
        {
            get => _login;
            set =>Set(ref _login, value, nameof(Login));
        }
        public string Password
        {
            get => _password;
            set => Set(ref _password, value, nameof(Password));
        }
        #endregion

        public AuthorizationViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                #region Create Database
                //var role1 = new Role { Title = "Admin" };
                //var role2 = new Role { Title = "Manager" };
                //var user1 = new User { Login = "admin", Password = "admin", Role = role1 };
                //var user2 = new User { Login = "manager", Password = "manager", Role = role2 };
                //var client1 = new Client { LastName = "Аксёнов", FirstName = "Александр", MiddleName = "Игоревич", DateOfBirth = new DateTime(2003, 03, 20), Gender = 'М', Passport = "кам", User = user1 };
                //var client2 = new Client { LastName = "Иж", FirstName = "Пётр", MiddleName = "Алексеевич", DateOfBirth = new DateTime(2004, 03, 20), Gender = 'Ж', Passport = "кам1", User = user2 };
                //var sanatoriumProgram1 = new SanatoriumProgram { Title = "Стандартная", QuantityOfProcedures = 3, MinDays = 4, Description = "Отсутсвует", Cost = 5999.99M };
                //var sanatoriumRoomCategory1 = new SanatoriumRoomCategory { Title = "Бизнес - комфорт", Cost = 3000m };
                //var sanatoriumRoom1 = new SanatoriumRoom { SanatoriumRoomCategory = sanatoriumRoomCategory1, RoomSize = 4, QuantityOfSeats = 3, QuantityOfRooms = 2, RoomAmenities = "Удобства не указаны", WindowView = "Вид на океан", Description = "Отсутсвует", Status = "Не занят" };
                //var costPerDay1 = new CostPerDay { Cost = sanatoriumProgram1.Cost + sanatoriumRoom1.SanatoriumRoomCategory.Cost, SanatoriumProgram = sanatoriumProgram1, SanatoriumRoom = sanatoriumRoom1 };
                //var treaty1 = new Treaty { DateOfConclusion = DateTime.Now, DateOfCheckIn = DateTime.Now.AddDays(1), DateOfCheckOut = DateTime.Now.AddDays(1).AddMonths(1), PaymentAmount = costPerDay1.Cost, PaymentMethod = "MasterCard", Client = client1, CostPerDay = costPerDay1 };

                //context.Roles.AddRange(role1, role2);
                //context.Users.AddRange(user1, user2);
                //context.Clients.AddRange(client1, client2);
                //context.SanatoriumPrograms.Add(sanatoriumProgram1);
                //context.SanatoriumRoomCategories.Add(sanatoriumRoomCategory1);
                //context.SanatoriumRooms.Add(sanatoriumRoom1);
                //context.CostsPerDays.Add(costPerDay1);
                //context.Treaties.Add(treaty1);
                //context.SaveChanges();
                #endregion
            }
        }

        #region Authorization Methods
        internal void Authorization()
        {
            using (var context = new ApplicationDbContext())
            {
                var currentClient = context.Clients.Include(u=>u.User).Where(c=>c.User.Login==Login && c.User.Password==Password).First();
                if (currentClient!=null)
                {
                    if (currentClient.User.RoleId==1)
                    {
                        new AdministratorWindow(currentClient)
                        .ShowDialog();
                    }
                    else
                    {
                        new ManagerWindow(currentClient)
                            .ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь отсутсвует!");
                }
            }
        }
        #endregion

    }
}
