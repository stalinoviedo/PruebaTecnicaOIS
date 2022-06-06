using System;
using System.Collections.Generic;
using PruebaTecnicaOIS.ViewModels;
using Xamarin.Forms;

namespace PruebaTecnicaOIS
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
