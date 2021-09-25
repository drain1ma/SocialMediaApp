using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaApp.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection(); 
    }
}
