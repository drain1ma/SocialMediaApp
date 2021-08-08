using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaApp.Models
{
    public class Token
    {
        public int ID { get; set; }
        public string AccessToken { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ExpireDate { get; set; }

        public Token() { }
    }
}
