using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Voice_Command_App.ViewModels
{
    class SecondPageViewModel
{
        public string SecondPageLabel { get; set; }
        public SecondPageViewModel()
        {
           
           SecondPageLabel = "Welcome to Second Page!";
        }
    }
}
