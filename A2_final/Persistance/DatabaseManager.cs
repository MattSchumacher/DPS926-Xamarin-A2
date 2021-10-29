using A2_final.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace A2_final.Persistance
{
    public class DatabaseManager
    {
        private static readonly Lazy<DatabaseManager> _instanceHolder = new Lazy<DatabaseManager>(() => new DatabaseManager());
        private readonly SQLiteAsyncConnection Database;

        public static DatabaseManager Instance => _instanceHolder.Value;

        private DatabaseManager()
        {
            Database = DependencyService.Get<ISQLiteDb>().GetConnection();
            _ = Database.CreateTableAsync<Food>();
            _ = Database.CreateTableAsync<FoodImage>();
        }

        public Task<List<Food>> GetAllFoods()
        {
            return Database.Table<Food>().ToListAsync();
        }

        public void InsertFood(Food food)
        {
            _ = Database.InsertAsync(food);
        }
    }
}
