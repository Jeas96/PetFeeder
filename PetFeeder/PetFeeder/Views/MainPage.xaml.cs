using PetFeeder.ViewModel;
using System;
using Xamarin.Forms;

namespace PetFeeder.Views
{
    public partial class MainPage : ContentPage
	{
    MainPageViewModel viewModel;
		public MainPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
            BindingContext = viewModel = new MainPageViewModel();
        }
        private void Add(object sender, EventArgs args)
        {
            viewModel.Agregar();
        }
        private void Sub(object sender, EventArgs args)
        {
            viewModel.Restar();
        }

    }
}
