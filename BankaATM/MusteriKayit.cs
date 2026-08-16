namespace BankaATM;

public class MusteriKayit
{
    public static void YeniMusteri(List<Hesap> tumHesaplar)
    {
        Console.WriteLine("TC Kimlik Numaranızı giriniz: ");
        string tcNo = Console.ReadLine()??"";

        while (string.IsNullOrWhiteSpace(tcNo) || !tcNo.All(char.IsDigit))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            Console.WriteLine("TC Kimlik Numaranızı giriniz: ");
            tcNo = Console.ReadLine()??"";
        }
        
        Console.WriteLine("Adınızı giriniz: ");
        string isim = Console.ReadLine()??"";

        while (string.IsNullOrWhiteSpace(isim) || !isim.All(char.IsLetter))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            Console.WriteLine("İsminizi giriniz: ");
            isim = Console.ReadLine()??"";
        }
        
        Console.WriteLine("Soyisminizi giriniz: ");
        string soyAd = Console.ReadLine()??"";
        
        while (string.IsNullOrWhiteSpace(soyAd) || !soyAd.All(char.IsLetter))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            Console.WriteLine("Soyisminizi giriniz: ");
            soyAd = Console.ReadLine()??"";
        }

        string adSoyad = isim + " " + soyAd;
        
        Console.WriteLine("Telefon Numaranızı giriniz: ");
        string telefonNo = Console.ReadLine()??"";
        
        while (string.IsNullOrWhiteSpace(telefonNo) || !telefonNo.All(char.IsDigit))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            Console.WriteLine("Telefon Numaranızı giriniz: ");
            telefonNo = Console.ReadLine()??"";
        }

        // Otomatik Sıradaki Müşteri No ve Hesap No Üretimi:
        string yeniMusteriNo = (101 + tumHesaplar.Count).ToString(); // 103, 104, 105... diye otomatik gider
        string yeniHesapNo = "TR" + (1001 + tumHesaplar.Count);       // TR1003, TR1004... diye otomatik gider
        
        
        Musteri m = new Musteri(yeniMusteriNo, adSoyad, tcNo, telefonNo, PinUret.Pin());
        Hesap h = new Hesap(yeniHesapNo, m, 0m);
        
        tumHesaplar.Add(h);
        
        Console.WriteLine("\n===========================================");
        Console.WriteLine($"KAYIT BAŞARILI! Sayın {adSoyad.ToUpper()}");
        Console.WriteLine($"Müşteri Numaranız   : {yeniMusteriNo}");
        Console.WriteLine($"Hesap IBAN          : {yeniHesapNo}");
        Console.WriteLine($"Geçici PIN Kodunuz  : {m.PinKodu}");
        Console.WriteLine("===========================================\n");
        
    }
        
}