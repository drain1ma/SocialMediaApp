using SocialMediaApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialMediaApp.Data
{
    public class UserDatabaseController
    {
        static readonly object locker = new object();
        private SQLiteAsyncConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            _ = database.CreateTableAsync<User>();
        }

        public Task<User> GetUser(int id)
        {
            lock (locker)
            {
                return database.FindAsync<User>(id);
            }
        }

        public Task SaveUser(User user)
        {
            lock (locker)
            {
                if (database.FindAsync<User>(user.ID) != null)
                {
                    _ = database.UpdateAsync(user);
                    return database.GetAsync<User>(user.ID);
                }
                else
                {
                    return database.InsertAsync(user);
                }
            }
        }

        public Task DeleteUser(int id)
        {
            lock (locker)
            {
                return database.DeleteAsync<User>(id);
            }
        }
    }
}
