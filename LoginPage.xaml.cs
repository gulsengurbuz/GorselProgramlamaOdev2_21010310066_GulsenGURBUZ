namespace GorselProgramlamaOdev21010310066;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void LoginClicked(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        
        if (email == "glsn66@gmail.com" && password == "1234")
        {
            await DisplayAlert("Ba�ar�l�", "Giri� ba�ar�l�", "Tamam");
            (App.Current as App).UserLoggedIn();

        }
        else
        {
            await DisplayAlert("Hata", "Email veya �ifre yanl��", "Tamam");
        }
    }

    private async void GoToRegisterPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}