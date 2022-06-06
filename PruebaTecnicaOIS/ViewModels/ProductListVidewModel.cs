using System;
using System.Collections.ObjectModel;
using PruebaTecnicaOIS.Models;

namespace PruebaTecnicaOIS.ViewModels
{
    public class ProductListVidewModel : BaseViewModel
    {
        private ObservableCollection<Product> _ProductList;
        public ObservableCollection<Product> ProductList
        {
            get => this._ProductList;
            set => this.SetValue(ref this._ProductList, value);
        }

        public ProductListVidewModel(ObservableCollection<Product> ProductList)
        {
            this.ProductList = ProductList;
        }
    }
}
