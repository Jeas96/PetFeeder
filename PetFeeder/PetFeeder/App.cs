using PetFeeder.Models;
using PetFeeder.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PetFeeder
{
    public partial class App : Application
    {
        public static ObservableCollection<RegistroAlimentacion> registrosAlimentacion = new ObservableCollection<RegistroAlimentacion>();
        public static ObservableCollection<RegistroAlimentacion> registrosSecundarios = new ObservableCollection<RegistroAlimentacion>
        {
            new RegistroAlimentacion()
            {
                cantidad =10,
                date =new System.DateTime(2010,10,6)
            },
            new RegistroAlimentacion()
            {
                cantidad =15,
                date =new System.DateTime(2010,11,5)
            },
            new RegistroAlimentacion()
            {
                cantidad =20,
                date =new System.DateTime(2010,12,4)
            },
            new RegistroAlimentacion()
            {
                cantidad =10,
                date =new System.DateTime(2010,05,3)
            },
            new RegistroAlimentacion()
            {
                cantidad =16,
                date =new System.DateTime(2010,06,2)
            },
            new RegistroAlimentacion()
            {
                cantidad =50,
                date =new System.DateTime(2010,07,1)
            }
        };
        public static string ruta_db;

        public App()
        {
            MainPage = new NavigationPage(new TabView());
        }

        public App(string rutadb)
        {
            ruta_db = rutadb;
            MainPage = new NavigationPage(new TabView());
        }

        protected override void OnStart()
        {
            //Cargar desde la BD
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
