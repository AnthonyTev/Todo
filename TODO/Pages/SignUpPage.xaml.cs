
namespace TODO
{

    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnSignInClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        private async void OnSignUpConfirmClicked(object sender, EventArgs e)
        {
            
            await DisplayAlert("Success", "Account Created Successfully!", "OK");

            // Navigate back to Login Page
            await Shell.Current.GoToAsync("TaskPage");
        }
    }

   

}

