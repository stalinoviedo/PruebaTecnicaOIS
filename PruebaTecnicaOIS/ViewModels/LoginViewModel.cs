using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using PruebaTecnicaOIS.Data;
using PruebaTecnicaOIS.Models;
using PruebaTecnicaOIS.Services;
using Xamarin.Forms;

namespace PruebaTecnicaOIS.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Usuario;
        public string Usuario
        {
            get => this._Usuario;
            set => this.SetValue(ref this._Usuario, value);
        }

        private string _Password;
        public string Password
        {
            get => this._Password;
            set => this.SetValue(ref this._Password, value);
        }

        public LoginViewModel()
        {
        }

        public ICommand LoginCommand => new Command(Login);
        public ICommand ToRegisterCommand => new Command(ToRegister);

        private void ToRegister(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Digite usuario",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Digite password",
                    "Aceptar");
                return;
            }

            ObservableCollection<Product> ProductList;

            var DataBaseProducts = SqliteManager.GetTable<Product>();
            if (DataBaseProducts == null || !DataBaseProducts.Any())
            {
                //Obtener informacion del API

                ProductList = await ApiService.GetProducts();

                foreach (var item in ProductList)
                {
                    try
                    {
                        SqliteManager.InsertRegisterTable<Product>(item);
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                        return;
                    }
                }
            }
            else
            {
                //Obtener información de SQLite
                ProductList = new ObservableCollection<Product>(DataBaseProducts);
            }

            await Application.Current.MainPage.Navigation.PushAsync(new ProductListPage(ProductList));
        }
    }
}
