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
        private string _lastName = null!;
        private string _firstName = null!;
        private string? _middleName = null!;
        private DateTime _dateOfBirth;
        private string? _gender;
        private string? _passport = null!;
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
        public string LastName 
        { 
            get => _lastName;
            set => Set(ref _lastName, value, nameof(LastName));
        }
        public string FirstName 
        { 
            get => _firstName;
            set => Set(ref _firstName, value, nameof(FirstName)); 
        }
        public string? MiddleName 
        { 
            get => _middleName;
            set => Set(ref _middleName, value, nameof(MiddleName));
        }
        public DateTime DateOfBirth 
        { 
            get => _dateOfBirth;
            set => Set(ref _dateOfBirth, value, nameof(DateOfBirth));
        }
        public string? Gender 
        { 
            get => _gender;
            set => Set(ref _gender, value, nameof(Gender));
        }
        public string? Passport 
        { 
            get => _passport;
            set => Set(ref _passport, value, nameof(Passport));
        }
        #endregion

        #region Lists
        //public List<Role> Roles { get; set; }
        //public List<User> Users { get; set; }
        //public List<Client> Clients { get; set; }
        //public List<SanatoriumProgram> SanatoriumPrograms { get; set; }
        //public List<SanatoriumRoomCategory> SanatoriumRoomCategories { get; set; }
        //public List<SanatoriumRoom> SanatoriumRooms { get; set; }
        //public List<CostPerDay> CostPerDays { get; set; }
        //public List<Treaty> Treaties { get; set; }
        #endregion

        public AuthorizationViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                #region Create Database
                //var role1 = new Role { Title = "Admin" };
                //var role2 = new Role { Title = "Manager" };
                //var role3 = new Role { Title = "User" };
                //var user1 = new User { Login = "admin", Password = "admin", Role = role1 };
                //var user2 = new User { Login = "manager", Password = "manager", Role = role2 };
                //var user3 = new User { Login = "guest", Password = "guest", Role = role3 };
                //var client1 = new Client { LastName = "Аксёнов", FirstName = "Александр", MiddleName = "Игоревич", DateOfBirth = new DateTime(2003, 03, 20), Gender = 'М', Passport = "кам", User = user1 };
                //var client2 = new Client { LastName = "Иж", FirstName = "Пётр", MiddleName = "Алексеевич", DateOfBirth = new DateTime(2004, 03, 20), Gender = 'Ж', Passport = "кам1", User = user2 };
                //var client3 = new Client { LastName = "Номов", FirstName = "Василий", MiddleName = "Андреевич", DateOfBirth = new DateTime(2006, 03, 20), Gender = 'М', Passport = "кам2", User = user3 };
                //var sanatoriumProgram1 = new SanatoriumProgram { Title = "Стандартная", QuantityOfProcedures = 3, MinDays = 4, Description = "Отсутсвует", Cost = 5999.99M };
                //var sanatoriumRoomCategory1 = new SanatoriumRoomCategory { Title = "Бизнес - комфорт", Cost = 3000m };
                //var sanatoriumRoom1 = new SanatoriumRoom { SanatoriumRoomCategory = sanatoriumRoomCategory1, RoomSize = 4, QuantityOfSeats = 3, QuantityOfRooms = 2, RoomAmenities = "Удобства не указаны", WindowView = "Вид на океан", Description = "Отсутсвует", Status = "Не занят" };
                //var costPerDay1 = new CostPerDay { Cost = sanatoriumProgram1.Cost + sanatoriumRoom1.SanatoriumRoomCategory.Cost, SanatoriumProgram = sanatoriumProgram1, SanatoriumRoom = sanatoriumRoom1 };
                //var treaty1 = new Treaty { DateOfConclusion = DateTime.Now, DateOfCheckIn = DateTime.Now.AddDays(1), DateOfCheckOut = DateTime.Now.AddDays(1).AddMonths(1), PaymentAmount = costPerDay1.Cost, PaymentMethod = "MasterCard", Client = client1, CostPerDay = costPerDay1 };

                //context.Roles.Add(role1);
                //context.Roles.Add(role2);
                //context.Roles.Add(role3);
                //context.Users.Add(user1);
                //context.Users.Add(user2);
                //context.Users.Add(user3);
                //context.Clients.Add(client1);
                //context.Clients.Add(client2);
                //context.Clients.Add(client3);
                //context.SanatoriumPrograms.Add(sanatoriumProgram1);
                //context.SanatoriumRoomCategories.Add(sanatoriumRoomCategory1);
                //context.SanatoriumRooms.Add(sanatoriumRoom1);
                //context.CostsPerDays.Add(costPerDay1);
                //context.Treaties.Add(treaty1);
                //context.SaveChanges();

                //Roles = new List<Role>(context.Roles);
                //Users = new List<User>(context.Users.Include(r => r.Role));
                //Clients = new List<Client>(context.Clients.Include(u => u.User).ThenInclude(r => r.Role));
                //SanatoriumPrograms = new List<SanatoriumProgram>(context.SanatoriumPrograms);
                //SanatoriumRoomCategories = new List<SanatoriumRoomCategory>(context.SanatoriumRoomCategories);
                //SanatoriumRooms = new List<SanatoriumRoom>(context.SanatoriumRooms.Include(sr => sr.SanatoriumRoomCategory));
                //CostPerDays = new List<CostPerDay>(context.CostsPerDays.Include(sp => sp.SanatoriumProgram).Include(sr => sr.SanatoriumRoom).ThenInclude(src => src.SanatoriumRoomCategory));
                //Treaties = new List<Treaty>(
                //    context.Treaties.
                //    Include(c => c.Client).
                //        ThenInclude(u => u.User).
                //        ThenInclude(r => r.Role).
                //    Include(cpd => cpd.CostPerDay).
                //        ThenInclude(sr => sr.SanatoriumRoom).
                //        ThenInclude(src => src.SanatoriumRoomCategory).
                //    Include(cpd => cpd.CostPerDay).
                //        ThenInclude(sp => sp.SanatoriumProgram)
                //        );
                #endregion
            }
        }

        #region Authorization Methods
        internal void Authorization()
        {
            using (var context = new ApplicationDbContext())
            {
                if (context.Users.Where(u=>u.Login==Login && u.Password==Password).Count()!=0)
                {
                    new MainWindow(context.Clients.Include(u => u.User).First(c => c.User.Login == Login && c.User.Password == Password)).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Пользователь отсутсвует!");
                }
            }
        }
        #endregion

        #region Register Methods
        internal void Registration()
        {
            using (var context = new ApplicationDbContext())
            {
                var IsExist = context.Clients
                    .Include(u => u.User)
                    .Any(c=>c.User.Login==Login && c.User.Password==Password);
                if ((Login == null || Login == string.Empty)
                    || (Password == null || Password == string.Empty)
                    || (FirstName == null || FirstName == string.Empty)
                    || (LastName == null || LastName == string.Empty)
                    || (Gender==null)
                    || (DateOfBirth==null)
                    || (Passport==null)) MessageBox.Show("Все поля должны быть заполнены!");
                else if (!IsExist)
                {
                    var newUser = new User { Login = Login, Password = Password, RoleId=3};
                    context.Users.Add(newUser);
                    context.Clients.Add(new Client
                    {
                        LastName = LastName,
                        FirstName = FirstName,
                        MiddleName = MiddleName,
                        Gender = Gender[0],
                        DateOfBirth = DateOfBirth,
                        User = newUser,
                        Passport = Passport
                    });
                    context.SaveChanges();
                    MessageBox.Show($"Клиент успешно добавлен");
                }
                else
                {
                    MessageBox.Show("Пользователь уже существует");
                }
            }
        }
        #endregion
    }
}
