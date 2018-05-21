using PetFeeder.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace PetFeeder.ViewModel
{
    class FeedListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<RegistroAlimentacion> _feederList;
        private DateTime _date;

        public FeedListViewModel()
        {
            _feederList = App.registrosAlimentacion;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<RegistroAlimentacion> ListaRegistros
        {
            get
            {
                return _feederList;
            }
            set
            {
                _feederList = value;
                OnPropertyChanged(nameof(ListaRegistros));
            }
        }

        public void SelectedDate(DateTime date)
        {
            _date = date;
            ListaRegistros = new ObservableCollection<RegistroAlimentacion>(App.registrosAlimentacion.Where(x => x.date.Date == _date.Date));
        }

        public DateTime MaxDate
        {
            get
            {
                return DateTime.Now.Date;
            }
        }


        //GetDateChanged
        //GedDate


    }
}
