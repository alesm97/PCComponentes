using PCComponentes.Models;
using PCComponentes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace PCComponentes
{
    public partial class MainPage : ContentPage
    {
        private LoginVM viewModel;

        public MainPage()
        {
            InitializeComponent();

            viewModel = new LoginVM();

            BindingContext = viewModel;

            btnStart.Clicked += login;
        }

        private void login(object sender, EventArgs e)
        {
            viewModel.Login();
        }
    }
}
