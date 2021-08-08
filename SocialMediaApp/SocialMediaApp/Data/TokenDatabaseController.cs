using SocialMediaApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SocialMediaApp.Data
{
    public class TokenDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public TokenDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Token>();
        }

        public Token GetToken()
        {
            lock (locker)
            {
                return database.Table<Token>().Count() == 0 ? null : database.Table<Token>().First();
            }
        }

        public int SaveUser(Token token)
        {
            lock (locker)
            {
                if (token.ID != 0)
                {
                    _ = database.Update(token);
                    return token.ID;
                }
                else
                {
                    return database.Insert(token);
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
