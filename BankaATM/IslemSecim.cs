namespace BankaATM;

public static class IslemSecim
{
    public static string IslemSec(string soruMesaji)
    {
        string secim = IslemSecimSuresi(soruMesaji);

        secim = secim.ToUpper();

        while (secim != "Y" && secim != "Ç" && secim != "B" && secim != "X")
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.\n");
            secim = IslemSecimSuresi(soruMesaji);

            secim = secim.ToUpper();
        }

        return secim;
    }


    public static decimal MiktarAl(string soruMesaji)
    {
        decimal miktar;

        string girdi = IslemSecimSuresi(soruMesaji);

        while (!decimal.TryParse(girdi, out miktar) || miktar <= 0)
        {
            Console.WriteLine("Lütfen geçerli bir değer giriniz.\n");
            girdi = IslemSecimSuresi(soruMesaji);
        }

        return miktar;
    }

    public static string EvetHayirAl(string soruMesaji)
    {
        string cevap = IslemSecimSuresi(soruMesaji);

        cevap = cevap.ToUpper();

        while (cevap != "E" && cevap != "H")
        {
            Console.WriteLine("Lütfen geçerli bir seçim yapınız.");
            cevap = IslemSecimSuresi(soruMesaji);

            cevap = cevap.ToUpper();
        }

        return cevap;
    }

    public static string IslemSecimSuresi(string soruMesaji)
    {
        int gecenSure = 0;
        bool uyari = false;

        Console.WriteLine(soruMesaji);

        while (gecenSure < 30)
        {
            if (Console.KeyAvailable)
            {
                return Console.ReadLine() ?? "";
            }

            Thread.Sleep(1000);
            gecenSure++;

            if (gecenSure == 15 && !uyari)
            {
                Console.WriteLine(
                    "\n15 saniye içerisinde herhangi bir işlem yapmamanız durumunda oturumunuz sonlandırılacaktır.\n");
                Console.WriteLine(soruMesaji);
                uyari = true;
            }
        }

        throw new ZamanAsimiException("\nUzun süredir işlem yapmadığınız için oturumunuz sonlandırıldı.\n");
    }
}