using System.IO;
using PruebaTecnicaOIS.Data;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(PruebaTecnicaOIS.Droid.DatabaseConnection_Android))]
namespace PruebaTecnicaOIS.Droid
{
    public class DatabaseConnection_Android : ISqliteManager
    {
        public SQLiteConnection DbConnection()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Database.db");

            if (!File.Exists(dbPath))
            {
                using (var br = new BinaryReader(Android.App.Application.Context.Assets.Open("Database.db")))
                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;

                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }
                }
            }

            return new SQLiteConnection(dbPath);
        }
    }
}