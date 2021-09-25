using SQLite;
using System.Linq; 
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password; 
        }

        public bool CheckInformation()
        {
            return Username != null && Password != null;
        }
    }
}
