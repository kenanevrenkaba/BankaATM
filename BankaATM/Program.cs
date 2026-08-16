using BankaATM;

List<Hesap> tumHesaplar = new List<Hesap>();

Musteri m1 = new Musteri("101", "KENAN YILMAZ", "12345678901", "05551234567", "1234");
Musteri m2 = new Musteri("102", "AHMET DEMİR", "98765432109", "05449876543", "4321");

Hesap h1 = new Hesap("TR1001", m1, 5000m);
Hesap h2 = new Hesap("TR1001", m2, 12500m);

tumHesaplar.Add(h1);
tumHesaplar.Add(h2);

Console.WriteLine("Hoş Geldiniz.");

string secim = "";

while (secim != "H")
{
    Hesap? girisYapanMusteri = MusteriGiris.MusteriAl(tumHesaplar);

    if (girisYapanMusteri == null)
    {
        continue;
    }

    string islemSecim = IslemSecim.IslemSec();


    if (islemSecim == "Y")
    {
        decimal miktar = IslemSecim.MiktarAl("Yatırmak istediğiniz miktarı giriniz: ");
        girisYapanMusteri.ParaYatir(miktar);

        Console.WriteLine("Hesabınıza " + miktar + "TL para yatırma işlemi gerçekleştirdiniz.\nGüncel bakiyeniz: " +
                          girisYapanMusteri.Bakiye + " TL");
    }

    else if (islemSecim == "Ç")
    {
        decimal miktar = IslemSecim.MiktarAl("Çekmek istediğiniz miktarı giriniz: ");
        girisYapanMusteri.ParaCek(miktar);

        Console.WriteLine("Hesabınızdan" + miktar + "TL para çekme işlemi gerçekleştirdiniz.\nGüncel bakiyeniz: " +
                          girisYapanMusteri.Bakiye + " TL");
    }

    secim = IslemSecim.EvetHayirAl("Başka işlem yapmak istiyor musunuz?");
}

Console.WriteLine("Sağlıklı Günler Dileriz...");