using System;
using System.Collections.Generic;
using PruebaTecnicaOIS.Models;
using Xamarin.Forms;

namespace PruebaTecnicaOIS
{
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            BindingContext = product;
        }
    }
}
