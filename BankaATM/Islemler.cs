namespace BankaATM;

using static Bicim;

public static class Islemler
{
    private static decimal MiktarAl(string soruMesaji)
    {
        decimal miktar;

        string girdi = IslemSecim.IslemSecimSuresi(soruMesaji);

        while (!decimal.TryParse(girdi, out miktar) || miktar <= 0)
        {
            Renkli("Lütfen geçerli bir değer giriniz.\n", ConsoleColor.DarkYellow);
            girdi = IslemSecim.IslemSecimSuresi(soruMesaji);
        }

        return miktar;
    }
    
    public static void ParaYatir(Hesap girisYapanMusteri, List<Hesap> tumHesaplar)
    {
        decimal miktar = MiktarAl("\nYatırmak istediğiniz miktarı giriniz:\n");

        girisYapanMusteri.ParaYatir(miktar);
        
            Console.WriteLine(
                $"\n{Mavi}Hesabınıza {KoyuYesil}{miktar} {Mavi}TL para yatırma işlemi gerçekleştirdiniz.\n\nGüncel bakiyeniz: {KoyuYesil}{girisYapanMusteri.Bakiye} {Mavi}TL\n");

            DosyaYoneticisi.Kaydet(tumHesaplar);
    }

    public static void ParaCek(Hesap girisYapanMusteri, List<Hesap> tumHesaplar)
    {
        decimal miktar = MiktarAl("\nÇekmek istediğiniz miktarı giriniz:\n");

        bool yeterliBakiye = girisYapanMusteri.ParaCek(miktar);

        if (yeterliBakiye)
        {
            Console.WriteLine(
                $"\n{Mavi}Hesabınızdan {KoyuYesil}{miktar} {Mavi}TL para çekme işlemi gerçekleştirdiniz.\n\nGüncel bakiyeniz: {KoyuYesil}{girisYapanMusteri.Bakiye} {Mavi}TL\n");

            DosyaYoneticisi.Kaydet(tumHesaplar);
        }

        else
        {
            Renkli("\nYetersiz bakiye.", ConsoleColor.DarkYellow);
            Console.WriteLine(
                $"\n{Mavi}Hesabınızın mevcut bakiyesi {KoyuYesil}{girisYapanMusteri.Bakiye} {Mavi}TL dir.");
        }
    }

    public static void Bakiye(Hesap girisYapanMusteri, List<Hesap> tumHesaplar)
    {
        Console.WriteLine($"\n{Mavi}Güncel bakiyeniz: {KoyuYesil}{girisYapanMusteri.Bakiye} {Mavi}TL\n");
    }
    
    public static void MusteriIslemDongusu(Hesap girisYapanMusteri, List<Hesap> tumHesaplar)
    {
        string secim = "E";

        while (secim == "E")
        {
            Console.Clear();

            string tarihSaat = DateTime.Now.ToString("dd.MM.yyyy | HH:mm");

            string baslik = new string('=', Console.WindowWidth - 1);
            string musteriBilgi =
                $" Sayın {girisYapanMusteri.HesapSahibi.AdSoyad.ToUpper()} | Müşteri No: {girisYapanMusteri.HesapSahibi.MusteriNumarasi} | IBAN: {girisYapanMusteri.HesapNumarasi}";

            Bicim.Renkli(baslik, ConsoleColor.DarkGreen);
            Bicim.Renkli(musteriBilgi.PadRight(Console.WindowWidth - (tarihSaat.Length + 2)) + tarihSaat + " ",
                ConsoleColor.Green);
            Bicim.Renkli(baslik + "\n", ConsoleColor.DarkGreen);


            string islemSecim =
                IslemSecim.IslemSec();

            switch (islemSecim)
            {
                case "Y":
                    Islemler.ParaYatir(girisYapanMusteri, tumHesaplar);
                    break;

                case "Ç":
                    Islemler.ParaCek(girisYapanMusteri, tumHesaplar);
                    break;

                case "B":
                    Islemler.Bakiye(girisYapanMusteri, tumHesaplar);
                    break;

                case "X":
                    Console.Clear();
                    string onay = IslemSecim.EvetHayirAl("\nÇıkış yapmak istiyor musunuz? E/H:\n");
                    if (onay == "E")
                    {
                        secim = "H"; // Ana döngüden temizce çık
                    }
                    break;
            }

            if (secim == "H")
            {
                break;
            }

            secim = IslemSecim.EvetHayirAl("Başka işlem yapmak istiyor musunuz? E/H:\n");
        }
    }
}