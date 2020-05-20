using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voice_Command_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Voice_Command_App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class SecondPage : ContentPage
{
    public SecondPage()
    {
        InitializeComponent();
        BindingContext = new SecondPageViewModel();
    }
}
}