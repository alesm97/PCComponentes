using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PCComponentes
{
    public partial class App : Application
    {

        public static ProductosRepository productosRepository { get; set; }
        public static UsuariosRepository usuariosRepository { get; set; }

        public App(string filename)
        {
            InitializeComponent();

            productosRepository = new ProductosRepository(filename);
            usuariosRepository = new UsuariosRepository(filename);

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
