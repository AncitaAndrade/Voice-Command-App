using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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
            System.Diagnostics.Debug.WriteLine("hey");
        }
    }
}
