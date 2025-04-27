using TODO.Models;
using Newtonsoft.Json;
using System.Text;

namespace TODO.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://todo-list.dcism.org/";

        public AuthService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        }

        public async Task<SignInResponse> SignIn(string email, string password)
        {
            try
            {
                var encodedEmail = Uri.EscapeDataString(email);
                var encodedPassword = Uri.EscapeDataString(password);
                var response = await _httpClient.GetAsync($"signin_action.php?email={encodedEmail}&password={encodedPassword}");
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SignInResponse>(content);
            }
            catch
            {
                return new SignInResponse { status = 500, message = "Network error" };
            }
        }

        public async Task<bool> SignUp(SignUpRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("signup_action.php", content);
                var responseContent = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}