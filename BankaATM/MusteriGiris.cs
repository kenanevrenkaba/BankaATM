namespace BankaATM;

public static class MusteriGiris
{
    public static Hesap? MusteriAl(List<Hesap> tumHesaplar)
    {
        Console.WriteLine("Müşteri Numaranızı Giriniz. (Yeni Müşteri girişi için 'K' tuşuna basınız):\n");
        string musteriNo = (Console.ReadLine() ?? "").ToUpper();

        while (string.IsNullOrWhiteSpace(musteriNo))
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            Console.WriteLine("Müşteri Numaranızı Giriniz. (Yeni Müşteri girişi için 'K' tuşuna basınız):\n");
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


        string pin = IslemSecim.IslemSecimSuresi("\nPIN Kodunuzu giriniz:\n");

        while (string.IsNullOrWhiteSpace(pin) || !pin.All(char.IsDigit))
        {
            pin = IslemSecim.IslemSecimSuresi("Lütfen geçerli bir giriş yapınız.\n\nPIN Kodunuzu giriniz:\n");
        }

        while (girisYapanHesap.HesapSahibi.PinKodu != pin)
        {
            pin = IslemSecim.IslemSecimSuresi("Hatalı PIN Kodu.\n\nPIN Kodunuzu giriniz:\n");
        }

        return girisYapanHesap;
    }
}