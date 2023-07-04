using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mgonzalezS5
{
    public partial class MainPage : ContentPage
    {
        //Variables globales para el url, cliente y donde almacenamos temporalmente
        private string url = "http://10.2.9.198/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiante> post;


        public MainPage()
        {
            InitializeComponent();
            obtenerDatos();
        }


        public async void obtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(url);
            List<Estudiante> listaPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            post = new ObservableCollection<Estudiante>(listaPost);
            listaEstudiante.ItemsSource = post;
        }
        //metodo asincrono agregando async
        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }

        private void listaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objeto = (Estudiante)e.SelectedItem;
            var codigoTem = objeto.codigo.ToString();
            int codigo = Convert.ToInt32(codigoTem);

            string nombre = objeto.nombre.ToString();
            string apellido = objeto.apellido.ToString();

            var edadTem = objeto.edad.ToString();
            int edad = Convert.ToInt32(edadTem);

            Navigation.PushAsync(new ActualizarEliminar(codigo, nombre, apellido, edad));
        }
    }
}
