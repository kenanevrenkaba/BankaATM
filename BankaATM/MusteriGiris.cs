namespace BankaATM;

public class MusteriGiris
{
    public static Hesap? MusteriAl(List<Hesap> tumHesaplar)
    {
        Console.WriteLine("Müşteri Numaranızı giriniz. Ya Da (Yeni Müşteri girişi için 'K' tuşuna basınız.): ");
        string musteriNo = (Console.ReadLine() ?? "").ToUpper();

        while (string.IsNullOrWhiteSpace(musteriNo))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            Console.WriteLine("Müşteri Numaranızı giriniz. Ya Da (Yeni Müşteri girişi için 'K' tuşuna basınız.): ");
            musteriNo = Console.ReadLine() ?? "";
        }

        if (musteriNo == "K")
        {
            MusteriKayit.YeniMusteri(tumHesaplar);
            
            Console.WriteLine("\nMüşteri kaydınız yapıldı.");

            return null;
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