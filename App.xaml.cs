
namespace GorselProgramlamaOdev21010310066
{
    public partial class App : Application
    {
        public void UserLoggedIn()
        {

            MainPage = new AppShell();
        }

        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new LoginPage());


            if (UserIsLoggedIn())
            {

                MainPage = new AppShell();
            }
            else
            {

                MainPage = new NavigationPage(new LoginPage());
            }
        }


        bool UserIsLoggedIn()
        {

            return false;
        }
    }
}
    
