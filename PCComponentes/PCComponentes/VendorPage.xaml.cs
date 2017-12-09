﻿using PCComponentes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace PCComponentes
{
    public partial class VendorPage : ContentPage
    {
        public VendorPage(Usuario usuario)
        {
            InitializeComponent();
            
            
            btnDesconectar.Clicked += desconectar;
        }

        private void desconectar(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}
