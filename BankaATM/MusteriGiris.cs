namespace BankaATM;

public class MusteriGiris
{
    public static Hesap? MusteriAl(List<Hesap> tumHesaplar)
    {
        Console.WriteLine("Müşteri Numaranızı giriniz:");
        string musteriNo = Console.ReadLine() ?? "";

        while (string.IsNullOrWhiteSpace(musteriNo) || !musteriNo.All(char.IsDigit))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.");
            Console.WriteLine("Müşteri Numaranızı giriniz:");
            musteriNo = Console.ReadLine() ?? "";
        }

        Hesap? girisYapanHesap = tumHesaplar.Find(h => h.HesapSahibi.MusteriNumarasi == musteriNo);

        if (girisYapanHesap is null)
        {
            Console.WriteLine("Hesap bulunamadı.");
            return null;
        }

        Console.WriteLine("PIN Kodunuzu giriniz:");
        string pin = Console.ReadLine() ?? "";


        while (string.IsNullOrWhiteSpace(pin) && !pin.All(char.IsDigit))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\nPIN Kodunuzu giriniz:");
            pin = Console.ReadLine() ?? "";
        }

        while (girisYapanHesap.HesapSahibi.PinKodu != pin)
        {
            Console.WriteLine("Hatalı PIN Kodu.\nPIN Kodunuzu giriniz: ");
            pin = Console.ReadLine() ?? "";
        }

        return girisYapanHesap;
    }
}