using System;
using System.Collections.Generic;
using PruebaTecnicaOIS.Services;

namespace PruebaTecnicaOIS.Data
{
    public static class SqliteManager
    {
        public static List<Model> GetTable<Model>() where Model : new()
        {
            return DataBaseService.Context.GetTable<Model>();
        }



        public static bool InsertRegisterTable<Model>(Model modelInsert) where Model : new()
        {
            return DataBaseService.Context.InsertRegisterTable<Model>(modelInsert);
        }
    }
}
