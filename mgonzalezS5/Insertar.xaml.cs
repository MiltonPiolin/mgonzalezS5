using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mgonzalezS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        private string url = "http://192.168.100.62/ws_uisrael/post.php";
        public Insertar()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            //para insertar datos

            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection(); //contenedor de los datos como un vector
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues(url, "POST", parametros);

                var mensaje = "Dato ingresado con exito";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta",ex.Message,"Cerrar");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {

        }
    }
}