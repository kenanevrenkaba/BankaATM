namespace BankaATM;

public class IslemSecim
{
    public static string IslemSec()
    {
        Console.Write("Yapmak istediğiniz işlemi seçiniz\nPara Yatırma: (Y)\nPara Çekme: (Ç)\nY/Ç:");
        string secim = (Console.ReadLine() ?? "").ToUpper();

        while (secim != "Y" && secim != "Ç")
        {
            Console.WriteLine("Lütfen geçerli bir giriş yapınız.");
            Console.Write("Yapmak istediğiniz işlemi seçiniz\nPara Yatırma: (Y)\nPara Çekme: (Ç)\nY/Ç:");
            secim = (Console.ReadLine() ?? "").ToUpper();
        }

        return secim;
    }


    public static decimal MiktarAl(string soruMesaji)
    {
        Console.Write(soruMesaji);
        decimal miktar;
        while (!decimal.TryParse(Console.ReadLine(), out miktar) || miktar <= 0)
        {
            Console.WriteLine("Lütfen geçerli bir değer giriniz.\n");
            Console.Write(soruMesaji);
        }

        return miktar;
    }

    public static string EvetHayirAl(string soruMesaji)
    {
        Console.Write(soruMesaji + " E/H: ");
        string cevap = (Console.ReadLine() ?? "").ToUpper();
        while (cevap != "E" && cevap != "H")
        {
            Console.WriteLine("Lütfen geçerli bir seçim yapınız.");
            Console.Write(soruMesaji + " E/H: ");
            cevap = (Console.ReadLine() ?? "").ToUpper();
        }

        return cevap;
    }
}