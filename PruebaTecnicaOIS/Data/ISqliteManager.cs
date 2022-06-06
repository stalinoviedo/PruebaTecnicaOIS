using System;
using SQLite;

namespace PruebaTecnicaOIS.Data
{
    public interface ISqliteManager
    {
        SQLiteConnection DbConnection();
    }
}
