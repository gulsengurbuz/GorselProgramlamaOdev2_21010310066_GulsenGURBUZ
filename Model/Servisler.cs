
using System.Net.Http;
using System.Threading.Tasks;
namespace GorselProgramlamaOdev21010310066.Model;

public static class Servisler 
{
    public static async Task<string> HaberleriGetir(Kategori ctg)
    {
        try
        {
            HttpClient client = new HttpClient();
            string url = $"https://api.rss2json.com/v1/api.json?rss_url={ctg.Link}";
            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsondata = await response.Content.ReadAsStringAsync();
            return jsondata;
        }
        catch
        {
            return null;
        }
    }
}