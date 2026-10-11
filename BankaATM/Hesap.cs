namespace BankaATM;

public class Hesap
{
    public string HesapNumarasi { get; private set; }
    public Musteri HesapSahibi { get; private set; }
    public decimal Bakiye { get; private set; }

    public Hesap(string hesapNumarasi, Musteri hesapSahibi, decimal bakiye)
    {
        HesapNumarasi = hesapNumarasi;
        HesapSahibi = hesapSahibi;
        Bakiye = bakiye;
    }


    public void ParaYatir(decimal miktar)
    {
        if (miktar > 0)
        {
            Bakiye += miktar;
        }
        
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