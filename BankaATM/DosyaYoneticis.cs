using System.Text.Json;

namespace BankaATM;

public static class DosyaYoneticisi
{
    private static string dosyaYolu = "hesaplar.json";

    public static void Kaydet(List<Hesap> tumHesaplar)
    {
        string json = JsonSerializer.Serialize(tumHesaplar);

        File.WriteAllText(dosyaYolu, json);
    }

    public static List<Hesap> Yukle()
    {
        if (File.Exists(dosyaYolu))
        {
            string json = File.ReadAllText(dosyaYolu);

            return JsonSerializer.Deserialize<List<Hesap>>(json) ?? new List<Hesap>();
        }

        return new List<Hesap>();
    }
}