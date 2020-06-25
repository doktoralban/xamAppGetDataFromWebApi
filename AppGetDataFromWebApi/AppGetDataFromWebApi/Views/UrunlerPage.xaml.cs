using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGetDataFromWebApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrunlerPage : ContentPage
    {
        public UrunlerPage()
        {
            InitializeComponent();
            BindingContext = new UrunlerPageViewModel(Navigation);
        }



        protected override void OnAppearing()
        {
            (this.BindingContext as UrunlerPageViewModel).UrunlerFiyataGoreTop10();
        }


    }
}