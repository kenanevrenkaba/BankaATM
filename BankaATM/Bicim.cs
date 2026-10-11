using System.Reflection.Metadata;

namespace BankaATM;

public static class Bicim
{
    public const string Sifirla = "\u001b[0m";
    public const string KoyuKirmizi = "\u001b[31m";
    public const string KoyuYesil = "\u001b[32m";
    public const string KoyuSari = "\u001b[33m";
    public const string KoyuMavi = "\u001b[34m";
    public const string KoyuCyan = "\u001b[36m";
    public const string KoyuMor = "\u001b[35m";
    public const string KoyuGri = "\u001b[90m";
    public const string Kirmizi = "\u001b[91m";
    public const string Yesil = "\u001b[92m";
    public const string Sari = "\u001b[93m";
    public const string Mavi = "\u001b[94m";
    public const string Cyan = "\u001b[96m";
    public const string Mor = "\u001b[95m";
    public const string Beyaz = "\u001b[97m";

    public static void Renkli(string mesaj, ConsoleColor renk)
    {
        Console.ForegroundColor = renk;
        Console.WriteLine(mesaj);
        Console.ResetColor();
    }
}