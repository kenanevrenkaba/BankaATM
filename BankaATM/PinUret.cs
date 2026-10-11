namespace BankaATM;
using System.Security.Cryptography;

public static class PinUret
{
    public static string Pin()
    {
        return RandomNumberGenerator.GetInt32(1000, 10000).ToString();
    }
}