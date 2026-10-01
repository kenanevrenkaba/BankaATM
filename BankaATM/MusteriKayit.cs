namespace BankaATM;

public static class MusteriKayit
{
    public static void YeniMusteri(List<Hesap> tumHesaplar)
    {
        string tcNo = IslemSecim.IslemSecimSuresi("\nTC Kimlik Numaranızı giriniz:\n");

        while (string.IsNullOrWhiteSpace(tcNo) || !tcNo.All(char.IsDigit))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            tcNo = IslemSecim.IslemSecimSuresi("\nTC Kimlik Numaranızı giriniz:\n");
        }


        string isim = IslemSecim.IslemSecimSuresi("\nAdınızı giriniz:\n");

        while (string.IsNullOrWhiteSpace(isim) || !isim.All(char.IsLetter))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            isim = IslemSecim.IslemSecimSuresi("\nAdınızı giriniz:\n");
        }

        Console.WriteLine();
        string soyAd = IslemSecim.IslemSecimSuresi("\nSoyadınızı giriniz:\n");

        while (string.IsNullOrWhiteSpace(soyAd) || !soyAd.All(char.IsLetter))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            soyAd = IslemSecim.IslemSecimSuresi("\nSoyadınızı giriniz:\n");
        }

        string adSoyad = isim + " " + soyAd;


        string telefonNo = IslemSecim.IslemSecimSuresi("\nTelefon Numaranızı giriniz:\n");

        while (string.IsNullOrWhiteSpace(telefonNo) || !telefonNo.All(char.IsDigit))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            telefonNo = IslemSecim.IslemSecimSuresi("\nTelefon Numaranızı giriniz:\n");
        }

        // Otomatik Sıradaki Müşteri No ve Hesap No Üretimi:
        string yeniMusteriNo = (101 + tumHesaplar.Count).ToString(); // 103, 104, 105... diye otomatik gider
        string yeniHesapNo = "TR" + (1001 + tumHesaplar.Count); // TR1003, TR1004... diye otomatik gider


        Musteri m = new Musteri(yeniMusteriNo, adSoyad, tcNo, telefonNo, PinUret.Pin());
        Hesap h = new Hesap(yeniHesapNo, m, 0m);

        tumHesaplar.Add(h);

        DosyaYoneticisi.Kaydet(tumHesaplar);

        Console.WriteLine("\n===========================================");
        Console.WriteLine($"KAYIT BAŞARILI! Sayın {adSoyad.ToUpper()}");
        Console.WriteLine($"Müşteri Numaranız   : {yeniMusteriNo}");
        Console.WriteLine($"Hesap IBAN          : {yeniHesapNo}");
        Console.WriteLine($"Geçici PIN Kodunuz  : {m.PinKodu}");
        Console.WriteLine("===========================================\n");
    }
}