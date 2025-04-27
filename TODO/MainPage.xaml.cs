using TODO.Services;

namespace TODO
{
    public partial class MainPage : ContentPage
    {
        private readonly AuthService _authService;

        public MainPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnSignInClicked(object sender, EventArgs e)
        {
            var response = await _authService.SignIn(
                EmailEntry.Text?.Trim(), 
                PasswordEntry.Text?.Trim()
            );

            if(response?.status == 200)
            {
                // Save user data
                await SecureStorage.SetAsync("user_id", response.data.id.ToString());
                await Shell.Current.GoToAsync("TaskPage");
            }
            else
            {
                await DisplayAlert("Error", response?.message ?? "Login failed", "OK");
            }
        }

        // Keep other methods as-is
    }
}

// namespace TODO
// {
//     public partial class MainPage : ContentPage
//     {
//         public MainPage()
//         {
//             InitializeComponent();
//         }

//         private async void OnSignInClicked(object sender, EventArgs e)
//         {
//             string username = EmailEntry.Text?.Trim();
//             string password = PasswordEntry.Text?.Trim();

//             if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
//             {
//                 await DisplayAlert("Error", "Username and Password cannot be empty.", "OK");
//                 return;
//             }

//             // Optional: Additional validation for only whitespace input
//             if (username.Contains(" ") || password.Contains(" "))
//             {
//                 await DisplayAlert("Error", "Username and Password cannot contain spaces.", "OK");
//                 return;
//             }

//             // TODO: Implement Sign-In Logic here (e.g., authentication)
//             await Shell.Current.GoToAsync("TaskPage");
//         }

//         private async void OnSignUpClicked(object sender, EventArgs e)
//         {
//             await Shell.Current.GoToAsync("SignUpPage");
//         }

//         private async void OnForgotPasswordTapped(object sender, EventArgs e)
//         {
//             // Optional visual feedback
//             ForgotPassword.TextColor = Color.FromArgb("#6A9C89");
//             await Task.Delay(50); // Brief delay for visual effect
//             ForgotPassword.TextColor = Colors.Black;

//             // TODO: Implement actual password reset navigation or logic here
//             //await DisplayAlert("Forgot Password", "Password recovery coming soon!", "OK");
//         }



//     }

// }
