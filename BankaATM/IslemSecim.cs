namespace BankaATM;

using static Bicim;
using System.Diagnostics;
using System.Text;

public static class IslemSecim
{ 
    public static string IslemSec()
    {
        string secim = IslemSecimSuresi(
            $"\nYapmak istediğiniz işlemi seçiniz.\n\n{Cyan}Para Yatırma: {KoyuSari}Y\n\n{Cyan}Para Çekme: {KoyuSari}Ç\n\n{Cyan}Bakiye Sorgulama: {KoyuSari}B\n\n{Cyan}Çıkış Yapmak İçin: {KoyuKirmizi}X\n\n{KoyuSari}Y{Mavi}/{KoyuSari}Ç{Mavi}/{KoyuSari}B:\n",
            tekTus: true);

        secim = secim.ToUpper();

        while (secim != "Y" && secim != "Ç" && secim != "B" && secim != "X")
        {
            Renkli("\nLütfen geçerli bir giriş yapınız.\n", ConsoleColor.DarkYellow);
            secim = IslemSecimSuresi(
                $"\nYapmak istediğiniz işlemi seçiniz.\n\n{Cyan}Para Yatırma: {KoyuSari}(Y)\n\n{Cyan}Para Çekme: {KoyuSari}(Ç)\n\n{Cyan}Bakiye Sorgulama: {KoyuSari}(B)\n\n{Cyan}Çıkış Yapmak İçin: {KoyuKirmizi}(X)\n\n{Cyan}Y{Mavi}/{Cyan}Ç{Mavi}/{Cyan}B:\n",
                tekTus: true);

            secim = secim.ToUpper();
        }

        return secim;
    }

    public static string EvetHayirAl(string soruMesaji, ConsoleColor color = ConsoleColor.DarkYellow)
    {
        string cevap = IslemSecimSuresi(soruMesaji, color, tekTus: true);

        cevap = cevap.ToUpper();

        while (cevap != "E" && cevap != "H")
        {
            Renkli("Lütfen geçerli bir seçim yapınız.", color);
            cevap = IslemSecimSuresi(soruMesaji, color, tekTus: true);

            cevap = cevap.ToUpper();
        }

        return cevap;
    }

    private static bool Maskele(ConsoleKeyInfo tus, StringBuilder girdi, bool maskele)
    {
        if (tus.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            return true;
        }

        else if (tus.Key == ConsoleKey.Backspace)
        {
            if (girdi.Length > 0)
            {
                girdi.Length--;
                Console.Write("\b \b");
            }

            return false;
        }

        girdi.Append(tus.KeyChar);
        Console.Write(maskele ? "*" : tus.KeyChar);

        return false;
    }

    public static string IslemSecimSuresi(string soruMesaji, ConsoleColor color = ConsoleColor.Blue,
        bool maskele = false, bool tekTus = false)
    {
        StringBuilder girdi = new StringBuilder();
        Stopwatch sayac = Stopwatch.StartNew();
        bool uyari = false;

        Renkli(soruMesaji, color);

        while (sayac.Elapsed.TotalSeconds < 30)
        {
            if (Console.KeyAvailable)
            {
                var tus = Console.ReadKey(intercept: true);

                sayac.Restart();
                uyari = false;

                bool tusEnter = Maskele(tus, girdi, maskele);

                if (tusEnter)
                {
                    return girdi.ToString();
                }
            }

            if ((girdi.Length == 1 && sayac.Elapsed.TotalSeconds >= 3 && tekTus) ||
                (girdi.Length >= 4 && sayac.Elapsed.TotalSeconds >= 3 && maskele))
            {
                Console.WriteLine();
                return girdi.ToString();
            }

            Thread.Sleep(50);

            if (sayac.Elapsed.TotalSeconds >= 15 && !uyari)
            {
                Console.Clear();

                Renkli(
                    "15 saniye içerisinde herhangi bir işlem yapmamanız durumunda oturumunuz sonlandırılacaktır.\n",
                    ConsoleColor.DarkYellow);
                Renkli(soruMesaji, color);
                uyari = true;
            }
        }

        Console.Clear();

        throw new ZamanAsimiException("\nUzun süredir işlem yapmadığınız için oturumunuz sonlandırıldı.\n");
    }
}