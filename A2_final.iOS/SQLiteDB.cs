using A2_final.iOS;
using A2_final.Persistance;
using SQLite;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDB))]
namespace A2_final.iOS
{
    class SQLiteDB : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string doucment_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(doucment_path, "nutrition.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}