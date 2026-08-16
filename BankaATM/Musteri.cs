namespace BankaATM;

public class Musteri
{
    public string MusteriNumarasi { get; private set; }
    public string AdSoyad { get; private set; }
    public string KimlikNumarasi { get; private set; }
    public string TelefonNumarasi { get; private set; }
    public string PinKodu { get; private set; }

    public Musteri(string musteriNumarasi, string adSoyad, string kimlikNumarasi, string telefonNumarasi,
        string pinKodu)
    {
        MusteriNumarasi = musteriNumarasi;
        AdSoyad = adSoyad;
        KimlikNumarasi = kimlikNumarasi;
        TelefonNumarasi = telefonNumarasi;
        PinKodu = pinKodu;
    }
}