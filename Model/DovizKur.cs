using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GorselProgramlamaOdev21010310066.Model
{


    public class KurItem
    {
        public string Doviz { get; set; }
        public string satis { get; set; }
        public string alis { get; set; }
        public string yuksek { get; set; }
        public string dusuk { get; set; }
        public string degisim { get; set; }
        public string oran { get; set; }
        public string yon { get; set; }
        public string YonImage
        {
            get
            {
                if (yon.Contains("up"))
                    return "up.png";
                else if (yon.Contains("down"))
                    return "down.png";
                else if (yon.Contains("moneyNat"))
                    return "kkk.png";
                return "";
            }
        }
    }
    public class Root
    {
        public USD USD { get; set; }
        public EUR EUR { get; set; }
        public GBP GBP { get; set; }
        public GA GA { get; set; }
        public C C { get; set; }
        public GAG GAG { get; set; }
        public BTC BTC { get; set; }
        public ETH ETH { get; set; }
    }


    public class BTC
    {
        public string satis { get; set; }
        public string alis { get; set; }
        public string yuksek { get; set; }
        public string dusuk { get; set; }
        public string degisim { get; set; }
        public string oran { get; set; }
        public string yon { get; set; }
    }

    public class C
    {
        public string satis { get; set; }
        public string alis { get; set; }
        public string yuksek { get; set; }
        public string dusuk { get; set; }
        public string degisim { get; set; }
        public string oran { get; set; }
        public string yon { get; set; }
    }

    public class ETH
    {
        public string satis { get; set; }
        public string alis { get; set; }
        public string yuksek { get; set; }
        public string dusuk { get; set; }
        public string degisim { get; set; }
        public string oran { get; set; }
        public string yon { get; set; }
    }

    public class EUR
    {
        public string satis { get; set; }
        public string alis { get; set; }
        public string yuksek { get; set; }
        public string dusuk { get; set; }
        public string degisim { get; set; }
        public string oran { get; set; }
        public string yon { get; set; }
    }

    public class GA
    {
        public string satis { get; set; }
        public string alis { get; set; }
        public string yuksek { get; set; }
        public string dusuk { get; set; }
        public string degisim { get; set; }
        public string oran { get; set; }
        public string yon { get; set; }
    }

    public class GAG
    {
        public string satis { get; set; }
        public string alis { get; set; }
        public string yuksek { get; set; }
        public string dusuk { get; set; }
        public string degisim { get; set; }
        public string oran { get; set; }
        public string yon { get; set; }
    }

    public class GBP
    {
        public string satis { get; set; }
        public string alis { get; set; }
        public string yuksek { get; set; }
        public string dusuk { get; set; }
        public string degisim { get; set; }
        public string oran { get; set; }
        public string yon { get; set; }
    }


    public class USD
    {
        public string satis { get; set; }
        public string alis { get; set; }
        public string yuksek { get; set; }
        public string dusuk { get; set; }
        public string degisim { get; set; }
        public string oran { get; set; }
        public string yon { get; set; }
    }

}

