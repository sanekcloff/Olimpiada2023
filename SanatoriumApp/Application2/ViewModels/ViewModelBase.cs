using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged; // строку можно получить нажав на INotifyPropertyChanged alt-enter и выбрав реализовать интерфейс

        // метод сравнивает новое и старое значение поля, field старое, value новое, propertyName свойство
        protected bool Set<T> (ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false; // Если новое и старое значение совпадают, то метод прерывается
            field= value; // Иначе старое значение меняется на новое
            OnPropertyChanged(propertyName);
            return true;
        }
        // метод для оповещения системы об изменении значения свойства
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
