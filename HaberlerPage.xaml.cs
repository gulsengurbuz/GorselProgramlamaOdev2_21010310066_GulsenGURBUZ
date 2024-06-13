namespace GorselProgramlamaOdev21010310066;

public partial class HaberlerPage : ContentPage
{
	
        public HaberlerPage(string jsondata)
        {
            InitializeComponent();

            
            HaberlerLabel.Text = jsondata;
        }
    }
