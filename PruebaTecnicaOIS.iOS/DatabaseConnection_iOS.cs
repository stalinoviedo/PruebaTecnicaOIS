using System.IO;
using System.Linq;
using Foundation;
using PruebaTecnicaOIS.Data;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(PruebaTecnicaOIS.iOS.DatabaseConnection_iOS))]
namespace PruebaTecnicaOIS.iOS
{
    public class DatabaseConnection_iOS : ISqliteManager
    {
        public global::SQLite.SQLiteConnection DbConnection()
        {
            var docFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            string dbPath = Path.Combine(libFolder, "Database.db");

            if (!File.Exists(dbPath))
            {
                var splitNameBD = "Database.db".Split('.');
                string existingDb;

                if (splitNameBD != null && splitNameBD.Count() > 1)
                {
                    existingDb = NSBundle.MainBundle.PathForResource(splitNameBD[0], splitNameBD[1]);
                }
                else { throw new System.Exception("Es necesario configurar el nombre de la base de datos con el que se va trabajar"); }


                File.Copy(existingDb, dbPath);
            }

            return new SQLiteConnection(dbPath);
        }
    }
}
