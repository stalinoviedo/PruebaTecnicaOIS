using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PruebaTecnicaOIS.Models;
using PruebaTecnicaOIS.ViewModels;
using Xamarin.Forms;

namespace PruebaTecnicaOIS
{
    public partial class ProductListPage : ContentPage
    {
        public ProductListPage(ObservableCollection<Product> ProductList)
        {
            InitializeComponent();
            BindingContext = new ProductListVidewModel(ProductList);
        }

        public ProductListPage()
        {

        }

        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new ProductDetailPage((Product)e.Item));
        }
    }
}
