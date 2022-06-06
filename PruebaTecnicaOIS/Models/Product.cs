using System;
using PruebaTecnicaOIS.Data;

namespace PruebaTecnicaOIS.Models
{
    public class Product : Table
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public double rate { get; set; }
        public int count { get; set; }
    }
}
