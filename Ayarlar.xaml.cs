namespace GorselProgramlamaOdev21010310066;

public partial class Ayarlar : ContentPage
{
	public Ayarlar()
	{
		
        InitializeComponent();
        
        LoadTheme();
    }
   
    private void OnThemeToggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
            Preferences.Set("theme", "dark");
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            Preferences.Set("theme", "light");
        }
    }

    private void LoadTheme()
    {
        string theme = Preferences.Get("theme", "light");
        if (theme == "dark")
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
            ThemeSwitch.IsToggled = true;
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            ThemeSwitch.IsToggled = false;
        }
    }
}
