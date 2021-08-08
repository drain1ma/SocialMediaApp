using SocialMediaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialMediaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void SignInProcedure(object Sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            _ = user.CheckInformation()
                ? DisplayAlert("Login", "Login Successful", "Ok")
                : DisplayAlert("Login", "Login Failed, wrong username or password", "Ok");
        }
    }
}