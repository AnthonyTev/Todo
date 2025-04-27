using TODO.Services;
using TODO.Models;

namespace TODO
{
    public partial class SignUpPage : ContentPage
    {
        private readonly AuthService _authService;

        public SignUpPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnSignInClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        private async void OnSignUpConfirmClicked(object sender, EventArgs e)
        {
            var request = new SignUpRequest
            {
                first_name = "ChizB", // Replace with actual entry values
                last_name = "Beloy",  // Add x:Name to your XAML entries
                email = "chizray@gmail.com",
                password = "123456",
                confirm_password = "123456"
            };

            var success = await _authService.SignUp(request);
            
            if(success)
            {
                await DisplayAlert("Success", "Account Created Successfully!", "OK");
                await Shell.Current.GoToAsync("TaskPage");
            }
            else
            {
                await DisplayAlert("Error", "Registration failed", "OK");
            }
        }
    }
}


// namespace TODO
// {

//     public partial class SignUpPage : ContentPage
//     {
//         public SignUpPage()
//         {
//             InitializeComponent();
//         }

//         private async void OnSignInClicked(object sender, EventArgs e)
//         {
//             await Shell.Current.GoToAsync("//MainPage");
//         }

//         private async void OnSignUpConfirmClicked(object sender, EventArgs e)
//         {
            
//             await DisplayAlert("Success", "Account Created Successfully!", "OK");

//             // Navigate back to Login Page
//             await Shell.Current.GoToAsync("TaskPage");
//         }
//     }

   

// }

