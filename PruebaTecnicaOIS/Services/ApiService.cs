using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PruebaTecnicaOIS.Data;
using PruebaTecnicaOIS.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PruebaTecnicaOIS.Services
{
    public class ApiService
    {

        public static async Task<ObservableCollection<Product>> GetProducts()
        {
            ObservableCollection<Product> collection = new ObservableCollection<Product>();

            try
            {
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync("https://fakestoreapi.com/products");
                        if (response.IsSuccessStatusCode)
                        {
                            var Listcollection = JsonConvert.DeserializeObject<List<ProductFromApi>>(await response.Content.ReadAsStringAsync());

                            foreach (var item in Listcollection)
                            {
                                collection.Add(new Product()
                                {
                                    title = item.title,
                                    category = item.category,
                                    description = item.description,
                                    image = item.image,
                                    price = item.price,
                                    rate = item.rating.rate,
                                    count = item.rating.count
                                });
                            }

                            return collection;
                        }
                        else
                        {
                            return collection = new ObservableCollection<Product>();
                        }
                    }
                }
                else
                {
                    if (VersionTracking.IsFirstLaunchEver)
                    {
                        await Application.Current.MainPage.DisplayAlert("Mensaje", "No existe conexión a internet, conecte su dispositivo a internet para un primer uso.", "Ok");
                        return collection = new ObservableCollection<Product>();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Mensaje", "No existe conexión a internet, se usaran los datos de la base de datos local.", "Ok");
                        var productsFromDB = SqliteManager.GetTable<Product>();
                        return collection = new ObservableCollection<Product>(productsFromDB);
                    }
                }

            }
            catch (Exception ex)
            {
                // There is a possibility that something happened. Be ready to catch it here.

                await Application.Current.MainPage.DisplayAlert("Mensaje", "Ocurrió un error al obtener la información de los productos.", "Ok");
                return collection = new ObservableCollection<Product>();
            }
        }
    }
}
