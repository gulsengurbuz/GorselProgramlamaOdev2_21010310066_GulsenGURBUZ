using System.Text.Json;
using GorselProgramlamaOdev21010310066.Model;

namespace GorselProgramlamaOdev21010310066;

public partial class Kurlar : ContentPage
{
	public Kurlar()
	{
		InitializeComponent();
	}
    private async void ContentPage_Appearing(object sender, EventArgs e)
    {
        await Load();
    }
    List<KurItem> kurlar;
    private async Task Load()
    {
        string jsonData = await KarlariYukle();

        var json = JsonSerializer.Deserialize<Root>(jsonData);

        kurlar = new List<KurItem>();

        kurlar.Add(new KurItem()
        {
            Doviz = "Dolar",
            alis = json.USD.satis,
            satis = json.USD.alis,
            yuksek = json.USD.yuksek,
            dusuk = json.USD.dusuk,
            degisim = json.USD.degisim,
            oran = json.USD.oran,
            yon = json.USD.yon,
        });

        kurlar.Add(new KurItem()
        {
            Doviz = "Euro",
            alis = json.EUR.alis,
            satis = json.EUR.satis,
            yuksek = json.EUR.yuksek,
            dusuk = json.EUR.dusuk,
            degisim = json.EUR.degisim,
            oran = json.EUR.oran,
            yon = json.EUR.yon,
        });

        kurlar.Add(new KurItem()
        {
            Doviz = "Sterlin",
            alis = json.GBP.alis,
            satis = json.GBP.satis,
            yuksek = json.GBP.yuksek,
            dusuk = json.GBP.dusuk,
            degisim = json.GBP.degisim,
            oran = json.GBP.oran,
            yon = json.GBP.yon,
        });

        kurlar.Add(new KurItem()
        {
            Doviz = "Gram Altýn",
            alis = json.GA.alis,
            satis = json.GA.satis,
            yuksek = json.GA.yuksek,
            dusuk = json.GA.dusuk,
            degisim = json.GA.degisim,
            oran = json.GA.oran,
            yon = json.GA.yon,
        });

        kurlar.Add(new KurItem()
        {
            Doviz = "Çeyrek Altýn",
            alis = json.C.alis,
            satis = json.C.satis,
            yuksek = json.C.yuksek,
            dusuk = json.C.dusuk,
            degisim = json.C.degisim,
            oran = json.C.oran,
            yon = json.C.yon,
        });

        kurlar.Add(new KurItem()
        {
            Doviz = "Gümüþ",
            alis = json.GAG.alis,
            satis = json.GAG.satis,
            yuksek = json.GAG.yuksek,
            dusuk = json.GAG.dusuk,
            degisim = json.GAG.degisim,
            oran = json.GAG.oran,
            yon = json.GAG.yon,
        });

        kurlar.Add(new KurItem()
        {
            Doviz = "Bitcoin",
            alis = json.BTC.alis,
            satis = json.BTC.satis,
            yuksek = json.BTC.yuksek,
            dusuk = json.BTC.dusuk,
            degisim = json.BTC.degisim,
            oran = json.BTC.oran,
            yon = json.BTC.yon,
        });

        kurlar.Add(new KurItem()
        {
            Doviz = "Ethereum",
            alis = json.ETH.alis,
            satis = json.ETH.satis,
            yuksek = json.ETH.yuksek,
            dusuk = json.ETH.dusuk,
            degisim = json.ETH.degisim,
            oran = json.BTC.oran,
            yon = json.BTC.yon,
        });
        listDoviz.ItemsSource = kurlar;
    }
    private async Task<string> KarlariYukle()
    {
        string jsonData = "";
        HttpClient client = new HttpClient();
        string url = "https://api.genelpara.com/embed/altin.json";
        using HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        jsonData = await response.Content.ReadAsStringAsync();

        return jsonData;
    }
}
