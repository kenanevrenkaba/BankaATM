namespace BankaATM;
using static Bicim;

public static class MusteriGiris
{
    public static Hesap? MusteriAl(List<Hesap> tumHesaplar)
    {
        
        string musteriNo = IslemSecim.IslemSecimSuresi(
            $"{Mavi}Müşteri Numaranızı Giriniz:\n{KoyuSari}(Yeni Müşteri girişi için {KoyuYesil}K {KoyuSari}tuşuna basınız)\n {Sifirla}",
            tekTus: true);
        
        musteriNo = musteriNo.ToUpper();

        while (string.IsNullOrWhiteSpace(musteriNo) || !musteriNo.All(char.IsDigit) && musteriNo != "K")
        {
            Bicim.Renkli("\nLütfen geçerli bir giriş yapınız.\n", ConsoleColor.DarkYellow);
            musteriNo = IslemSecim.IslemSecimSuresi(
                $"{Mavi}Müşteri Numaranızı Giriniz:\n{KoyuSari}(Yeni Müşteri girişi için {KoyuYesil}'K' {KoyuSari}tuşuna basınız)\n {Sifirla}");
            musteriNo = musteriNo.ToUpper();
        }

        if (musteriNo == "K")
        {
            MusteriKayit.YeniMusteri(tumHesaplar);

            Bicim.Renkli("\nMüşteri kaydınız yapıldı.", ConsoleColor.DarkGreen);

            return null;
        }
        
        Hesap? girisYapanHesap = tumHesaplar.Find(h => h.HesapSahibi.MusteriNumarasi == musteriNo);

        if (girisYapanHesap is null)
        {
            Bicim.Renkli("\nHesap bulunamadı.", ConsoleColor.DarkRed);

            Thread.Sleep(5000);

            Console.Clear();

            return null;
        }

        string pin = IslemSecim.IslemSecimSuresi($"\nPIN Kodunuzu giriniz:\n{KoyuSari}(Çıkış yapmak için {KoyuKirmizi}X{KoyuSari} tuşuna basınız.)\n", ConsoleColor.Blue, true, true);

        pin = pin.ToUpper();
        
        if (pin == "X")
        {
            Console.Clear();
            return null;
        }
        
        while (string.IsNullOrWhiteSpace(pin))
        {
            Bicim.Renkli("Lütfen geçerli bir giriş yapınız.\n", ConsoleColor.DarkYellow);
            pin = IslemSecim.IslemSecimSuresi($"\nPIN Kodunuzu giriniz:\n{KoyuSari}(Çıkış yapmak için ({KoyuKirmizi}X{KoyuSari}) tuşuna basınız.)\n", ConsoleColor.Blue, true, true);
        }
        
        int kalanHak = 2;

        while (girisYapanHesap.HesapSahibi.PinKodu != pin)
        {
            if (kalanHak == 0)
            {
                Bicim.Renkli("\nPIN Kodunuzu 3 kez üst üste hatalı girdiğiniz için oturumunuz sonlandırıldı.",
                    ConsoleColor.DarkRed);

                Bicim.Renkli("\nSağlıklı günler dileriz...", ConsoleColor.DarkGreen);

                Bicim.Renkli("\nSistem birazdan devreye girecektir.", ConsoleColor.DarkYellow);

                Thread.Sleep(10000);

                Console.Clear();

                return null;
            }

            Console.WriteLine(
                $"\n{KoyuSari}Hatalı PIN Kodu.\n\n{KoyuKirmizi}{kalanHak}{Sifirla} {KoyuSari}Giriş Hakkınız kaldı.\n");
            pin = IslemSecim.IslemSecimSuresi($"\nPIN Kodunuzu giriniz:\n{KoyuSari}(Çıkış yapmak için ({KoyuKirmizi}X{KoyuSari}) tuşuna basınız.)\n", ConsoleColor.Blue, true, true);
            
            pin = pin.ToUpper();
            
            if (pin == "X")
            {
                Console.Clear();
                return null;
            }

            while (string.IsNullOrWhiteSpace(pin))
            {
                Bicim.Renkli("Lütfen geçerli bir giriş yapınız.\n", ConsoleColor.DarkYellow);
                pin = IslemSecim.IslemSecimSuresi($"\nPIN Kodunuzu giriniz:\n{KoyuSari}Çıkış yapmak için ({KoyuKirmizi}X{KoyuSari}) tuşuna basınız.\n", ConsoleColor.Blue, true, true);
            }

            kalanHak--;
            
        }
        
        return girisYapanHesap;
    }
    
}