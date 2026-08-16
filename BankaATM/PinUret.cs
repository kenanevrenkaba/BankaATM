namespace BankaATM;

public class PinUret
{
    public static string Pin()
    {
        string karakterHavuzu = "0123456789";
        string pin = "";
        Random rnd = new Random();
        for (int i = 0; i < 4; i++)
        {
            int randomIndex = rnd.Next(0, karakterHavuzu.Length);
            pin += karakterHavuzu[randomIndex];
        }
            
        return pin;
    }
}