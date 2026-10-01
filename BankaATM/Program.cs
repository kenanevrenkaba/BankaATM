using BankaATM;

List<Hesap> tumHesaplar = DosyaYoneticisi.Yukle();

if (tumHesaplar.Count == 0)
{
    Musteri m1 = new Musteri("101", "KENAN YILMAZ", "12345678901", "05551234567", "1234");
    Musteri m2 = new Musteri("102", "AHMET DEMİR", "98765432109", "05449876543", "4321");

    Hesap h1 = new Hesap("TR1001", m1, 5000m);
    Hesap h2 = new Hesap("TR1002", m2, 12500m);

    tumHesaplar.Add(h1);
    tumHesaplar.Add(h2);

    DosyaYoneticisi.Kaydet(tumHesaplar);
}

while (true)
{
    try
    {
        Console.WriteLine("\nHoş Geldiniz...\n");

        Hesap? girisYapanMusteri = MusteriGiris.MusteriAl(tumHesaplar);

        if (girisYapanMusteri == null)
        {
            continue;
        }

        string secim = "E";

        while (secim == "E")
        {
            string islemSecim =
                IslemSecim.IslemSec(
                    "\nYapmak istediğiniz işlemi seçiniz.\n\nPara Yatırma: (Y)\n\nPara Çekme: (Ç)\n\nBakiye Sorgulama: (B)\n\nÇıkış Yapmak İçin: (X) tuşuna basın.\n\nY/Ç/B:\n");


            if (islemSecim == "Y")
            {
                decimal miktar = IslemSecim.MiktarAl("\nYatırmak istediğiniz miktarı giriniz:\n");

                girisYapanMusteri.ParaYatir(miktar);

                Console.WriteLine("\nHesabınıza " + miktar +
                                  "TL para yatırma işlemi gerçekleştirdiniz.\n\nGüncel bakiyeniz: " +
                                  girisYapanMusteri.Bakiye + " TL\n");

                DosyaYoneticisi.Kaydet(tumHesaplar);
            }

            else if (islemSecim == "Ç")
            {
                decimal miktar = IslemSecim.MiktarAl("\nÇekmek istediğiniz miktarı giriniz:\n");

                girisYapanMusteri.ParaCek(miktar);

                Console.WriteLine("\nHesabınızdan " + miktar +
                                  "TL para çekme işlemi gerçekleştirdiniz.\n\nGüncel bakiyeniz: " +
                                  girisYapanMusteri.Bakiye + " TL\n");

                DosyaYoneticisi.Kaydet(tumHesaplar);
            }

            else if (islemSecim == "B")
            {
                Console.WriteLine($"\nGüncel bakiyeniz: {girisYapanMusteri.Bakiye} TL\n");
            }

            else if (islemSecim == "X")
            {
                string onay = IslemSecim.EvetHayirAl("\nÇıkış yapmak istiyor musunuz? E/H:\n");

                if (onay != "E")
                {
                    continue;
                }

                break;
            }

            secim = IslemSecim.EvetHayirAl("Başka işlem yapmak istiyor musunuz? E/H:\n");
        }

        Console.Write("\nSağlıklı günler dileriz...");

        Thread.Sleep(10000);

        Console.Clear();
    }
    catch (ZamanAsimiException e)
    {
        Console.WriteLine(e.Message);

        Console.Write("\nSağlıklı günler dileriz...");

        Thread.Sleep(10000);

        Console.Clear();
    }
}