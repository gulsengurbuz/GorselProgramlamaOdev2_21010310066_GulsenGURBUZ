namespace GorselProgramlamaOdev21010310066
{
    public partial class AppShell : Shell
    {
        
            public AppShell()
            {
                InitializeComponent();
                Routing.RegisterRoute("register", typeof(RegisterPage));
                Routing.RegisterRoute("login", typeof(LoginPage));
                Routing.RegisterRoute("home", typeof(MainPage));


            }
    }
}

