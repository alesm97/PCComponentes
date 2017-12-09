using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PCComponentes
{
    public partial class App : Application
    {

        public static ProductosRepository ProductosRepository { get; set; }
        public static UsuariosRepository UsuariosRepository { get; set; }
        public static PedidosRepository PedidosRepository { get; internal set; }

        public App(string filename)
        {
            InitializeComponent();

            ProductosRepository = new ProductosRepository(filename);
            UsuariosRepository = new UsuariosRepository(filename);
            PedidosRepository = new PedidosRepository(filename);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
