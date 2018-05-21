using PetFeeder.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetFeeder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeedList : ContentPage
	{
		public FeedList ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new FeedListViewModel();
            InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            //Atualizar la lista de acuerdo a la fecha
            
            base.OnAppearing();
        }

        private void SelectedDate(object sender, DateChangedEventArgs eventArgs)
        {
            FeedListViewModel feedListViewModel = (FeedListViewModel)BindingContext;
            feedListViewModel.SelectedDate(eventArgs.NewDate);
        }
    }
}