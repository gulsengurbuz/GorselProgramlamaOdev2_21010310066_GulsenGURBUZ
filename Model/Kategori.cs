namespace GorselProgramlamaOdev21010310066.Model;

public class Kategori
{
	
       
        public string Baslik { get; set; }
        public string Link { get; set; }

        public static List<Kategori> liste = new List<Kategori>()
    {
        new Kategori() { Baslik = "Gündem", Link = "https://www.trthaber.com/gundem_articles.rss" },
        new Kategori() { Baslik = "Ekonomi", Link = "https://www.trthaber.com/ekonomi_articles.rss" },
        new Kategori() { Baslik = "Spor", Link = "https://www.trthaber.com/spor_articles.rss" },
        new Kategori() { Baslik = "Bilim ve Teknoloji", Link = "https://www.trthaber.com/bilim_teknoloji_articles.rss" },
        new Kategori() { Baslik = "Eðitim", Link = "https://www.trthaber.com/egitim_articles.rss" }
    };
    }
