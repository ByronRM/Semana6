using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;

namespace Semana5
{
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

       void btnInsertar_Clicked(Object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtId.Text);
                parametros.Add("nombre ", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.100.130:8888/moviles/post.php", "POST", parametros);
               
              DisplayAlert("Alerta", "Dato ingresado conrrectamente", "Ok");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                 DisplayAlert("Mensaje de error", "Error" + ex.Message,"Ok");
            }
            
        }

        void btnCancelar_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}

