using System.Windows.Input;
using Voice_Command_App.Views;
using Xamarin.Forms;

namespace Voice_Command_App.ViewModels
{
    public class MainPageViewModel
    {
        public ICommand ButtonClickCommand { get; set; }

        public string MainPageLabel { get; set; }
        public MainPageViewModel()
        {
            ButtonClickCommand = new Command(OnGotoNextPageButtonClicked);
            MainPageLabel = "Welcome to Voice based App!";
        }

        private void OnGotoNextPageButtonClicked()
        {
            var nextPage = new SecondPage();
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(nextPage);
        }
    }
}
