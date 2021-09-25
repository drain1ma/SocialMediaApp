using SocialMediaApp.Models;
using System;
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
            Init();
            
        }

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            AcvititySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e); 
        }
        private async void SignInProcedure(object Sender, EventArgs e)
        {
            
            User user = new User(Entry_Username.Text, Entry_Password.Text);

            if (user.CheckInformation())
            {
                await DisplayAlert("Login", user.Username + " has logged in", "Ok");
                _ = App.UserDatabase.SaveUser(user);

            }
            else
            {
                await DisplayAlert("Login", "Login Failed, wrong username or password", "Ok");
            }
        }
    }
}