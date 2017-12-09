using PCComponentes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace PCComponentes
{
    public partial class ClientPage : ContentPage
    {
        public ClientPage(Usuario usuario)
        {
            InitializeComponent();
            
            
            //btnStart.Clicked += comprobarUsuario;
        }

        /*private async Task comprobarUsuarioAsync()
        {
            List<Usuario> usuarios = new List<Usuario>(await App.usuariosRepository.GetAllProductosAsync);
        }*/
    }
}
