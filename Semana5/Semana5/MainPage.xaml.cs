using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Semana5
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.130:8888/moviles/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Semana5.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
        }

        async void btnGet_Clicked(System.Object sender, System.EventArgs e)
        {
            var content = await cliente.GetStringAsync(Url);
            List<Semana5.Datos> posts = JsonConvert.DeserializeObject<List<Semana5.Datos>>(content);
            _post = new ObservableCollection<Semana5.Datos>(posts);

            MyListView.ItemsSource = _post;

        }


      void btnInsertar_Clicked_1(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
       
    }
}

