namespace GorselProgramlamaOdev21010310066;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private async void RegisterClicked(object sender, EventArgs e)
    {
        
        await DisplayAlert("Ba�ar�l�", "Kay�t ba�ar�l�", "Tamam");

        
        await Navigation.PushAsync(new LoginPage());
    }

    private async void GoToLoginPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}