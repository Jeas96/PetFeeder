using PetFeeder.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace PetFeeder.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Uri url = new Uri("http://192.168.100.2:8081");
        private int cantidad = 10;
        int value=0;
        int panPos = 70, 
        tiltPos = 90, 
        tiltMax = 170, 
        tiltMin = 45, 
        panMax = 170, 
        panMin = 20;
        HttpClient client;
        HttpResponseMessage response;
        Uri uri;

        public MainPageViewModel()
        {
            using (SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.ruta_db))
            {
                conexion.CreateTable<RegistroAlimentacion>();
                ListaRegistros = new ObservableCollection<RegistroAlimentacion>(conexion.Table<RegistroAlimentacion>());
            }
            if(ListaRegistros==null || ListaRegistros.Count== 0)
            {
                ListaRegistros = App.registrosSecundarios;
            }
        }

        public ObservableCollection<RegistroAlimentacion> ListaRegistros
        {
            get
            {
                return App.registrosAlimentacion;
            }

            set
            {
                App.registrosAlimentacion = value;
            }
        }

        public Uri VideoSource
        {
            get
            {
                return url;
            }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; OnPropertyChanged(nameof(Cantidad)); }
        }

        public void Agregar()
        {
            Cantidad += 1;
            funcion(10);

        }

        public void Restar()
        {
            Cantidad -= 1;
            funcion(-10);
        }

        private async Task funcion(int ajuste)
        {
            if (!((panPos >= panMax && ajuste > 0) || (panPos <= panMin && ajuste < 0)))
            {
                panPos += ajuste;
            }
            value += panPos;
            await Enviar();
        }

        public async Task Enviar(int v=10)
        {
            var registro = new RegistroAlimentacion()
            {
                cantidad = v,
                date = DateTime.Now
            };
            ListaRegistros.Add(registro);
            using (SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.ruta_db))
            {
                conexion.CreateTable<RegistroAlimentacion>();
                conexion.Insert(registro);
            }
            uri = new Uri(string.Format("192.168.100.2/servos.pry?value" + value + "P",string.Empty));

            response = await client.GetAsync(uri);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
