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
        Bicim.Renkli("\nHoş Geldiniz...\n", ConsoleColor.DarkGreen);

        Hesap? girisYapanMusteri = MusteriGiris.MusteriAl(tumHesaplar);

        if (girisYapanMusteri == null)
        {
            continue;
        }

       Islemler.MusteriIslemDongusu(girisYapanMusteri, tumHesaplar);
       

        Bicim.Renkli("\nSağlıklı günler dileriz...\n", ConsoleColor.Green);

        Bicim.Renkli("\nSistem birazdan devreye girecektir.", ConsoleColor.DarkYellow);

        Thread.Sleep(10000);

        Console.Clear();
    }

    catch (ZamanAsimiException e)
    {
        Bicim.Renkli(e.Message, ConsoleColor.DarkRed);

        Bicim.Renkli("\nSağlıklı günler dileriz...\n", ConsoleColor.Green);

        Bicim.Renkli("\nSistem birazdan devreye girecektir.", ConsoleColor.DarkYellow);

        Thread.Sleep(10000);

        Console.Clear();
    }
}