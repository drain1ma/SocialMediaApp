using SocialMediaApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SocialMediaApp.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            _ = database.CreateTable<User>();
        }

        public User GetUser()
        {
            lock (locker)
            {
                return database.Table<User>().Count() == 0 ? null : database.Table<User>().First();
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if (user.ID != 0)
                {
                    _ = database.Update(user);
                    return user.ID;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
