using GorselProgramlamaOdev21010310066.Model;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GorselProgramlamaOdev21010310066;

public partial class Haberler : ContentPage
{

    public Haberler()
    { 
    InitializeComponent();
        KategoriCollectionView.ItemsSource = Kategori.liste;
    }

    private async void OnKategoriTapped(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;

        var kategori = (Kategori)e.CurrentSelection[0];
        var jsondata = await Servisler.HaberleriGetir(kategori);

        if (jsondata != null)
        {
            var haberler = ParseHaberler(jsondata);
            HaberlerListView.ItemsSource = haberler;
            HaberlerListView.IsVisible = true;
        }

        
        KategoriCollectionView.SelectedItem = null;
    }

    private List<Haber> ParseHaberler(string jsondata)
    {
        var rootObject = JsonConvert.DeserializeObject<RootObject>(jsondata);
        return rootObject.Items.Select(item => new Haber
        {
            title = item.title,
            description = item.description,
            link = item.link
        }).ToList();
    }
}
    


        
