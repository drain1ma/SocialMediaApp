using SocialMediaApp.Data;
using SocialMediaApp.Models;
using SQLite;
using System;
using System.Security.Cryptography;
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
            UserDatabaseController database = new UserDatabaseController();
            /* Fetch the stored value */
            string savedPasswordHash = database.GetUser().Password;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(Entry_Password.Text, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException();

            User user = new User(Entry_Username.Text, savedPasswordHash); 

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

        private async void SignUpPage(object Sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
    }
}