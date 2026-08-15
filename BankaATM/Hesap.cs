using System.Globalization;

namespace BankaATM;

public class Hesap
{
    public string HesapNumarasi { get; private set; }
    public Musteri HesapSahibi { get; private set; }
    public decimal Bakiye { get; private set; }
    
    public Hesap (string hesapNumarasi, Musteri hesapSahibi, decimal bakiye)
    {
        HesapNumarasi = hesapNumarasi;
        HesapSahibi = hesapSahibi;
        Bakiye = bakiye;
    }
    

    public bool ParaYatir(decimal miktar)
    {
        if (miktar <= 0)
        {
            return false;
        }
        Bakiye += miktar;
        return true;
    }

    public bool ParaCek(decimal miktar)
    {
        if (miktar <= 0 || miktar > Bakiye)
        {
            return false;
        }
        Bakiye -= miktar;
        return true;
    }
}
