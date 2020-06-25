using AppGetDataFromWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AppGetDataFromWebApi
{
    public class UrunlerPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public INavigation Navigation { get; set; }
        public UrunlerPageViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
        }
        //------------------------------------------------------
        bool _isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        //------------------------------------------------------
        ObservableCollection<Urun> _urunlers;
        public ObservableCollection<Urun> Urunler
        {
            get
            {
                return _urunlers;
            }
            set
            {
                _urunlers = value;
                OnPropertyChanged();
            }
        }


        //-------------------------------------------------------
        public async void UrunlerFiyataGoreTop10()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // send a GET request  
                    var uri = "http://192.168.1.14/WebApiNW/Urunler/FiyataGoreTop10";
                    var result = await client.GetStringAsync(uri);

                    //handling the answer  
                    var UrunList = JsonConvert.DeserializeObject<List<Urun>>(result);

                    Urunler = new ObservableCollection<Urun>(UrunList);
                    IsRefreshing = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        //-------------------------------------------------------










    }
}
