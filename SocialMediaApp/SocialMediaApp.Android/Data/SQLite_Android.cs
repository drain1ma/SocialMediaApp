using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SocialMediaApp.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using SocialMediaApp.Droid.Data; 

[assembly: Dependency(typeof(SQLite_Android))]
namespace SocialMediaApp.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android(){}
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFileName);
            var conn = new SQLiteConnection(path);

            return conn; 

        }
    }
}