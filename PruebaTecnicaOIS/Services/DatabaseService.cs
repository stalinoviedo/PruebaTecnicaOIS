using System;
using System.Collections.Generic;
using System.Linq;
using PruebaTecnicaOIS.Data;
using SQLite;
using Xamarin.Forms;

namespace PruebaTecnicaOIS.Services
{
    internal sealed class DataBaseService
    {
        private DataBaseService() { }

        private static DataBaseService context = null;

        public static DataBaseService Context
        {
            get
            {
                if (context == null)
                {
                    context = new DataBaseService();
                    context.CreateConnection();
                }
                return context;
            }
        }

        internal SQLiteConnection database;

        private void CreateConnection()
        {
            if (database == null)
            {
                database = DependencyService.Get<ISqliteManager>().DbConnection();
            }
        }

        internal List<Model> GetTable<Model>() where Model : new()
        {
            return database.Table<Model>().ToList();
        }

        internal bool InsertRegisterTable<Model>(Model modelInsert) where Model : new()
        {
            int numberRowsAdded = database.Insert(modelInsert);
            return (numberRowsAdded > 0);
        }

        private bool TableExists<Model>()
        {
            var sqliteAttribute = typeof(Model).GetCustomAttributes(false).OfType<TableAttribute>();

            if (!sqliteAttribute.Any() && string.IsNullOrEmpty(sqliteAttribute.First().Name))
            {
                throw new System.NullReferenceException("No se ha especificado el atributo SQLite, que define el nombre de la tabla.");
            }

            string table = sqliteAttribute.First().Name;
            var tableInfo = database.GetTableInfo(table);

            return (tableInfo?.Count > 0);
        }
    }
}
