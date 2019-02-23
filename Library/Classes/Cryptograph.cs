using System.Net.NetworkInformation;

namespace Library.Classes
{
    static public class Cryptograph
    {
        /// <summary>
        /// Verifica se o computador atual está em uma lista de permissões.
        /// </summary>
        /// <returns>Retorna valor indicando se o MAC do computador atual está em uma lista de permissões.</returns>
        static public bool CheckMAC()
        {
            foreach (NetworkInterface nif in NetworkInterface.GetAllNetworkInterfaces())
            {
                switch (nif.GetPhysicalAddress().ToString())
                {
                    case "00248CCF6CB1"://ideia-frente??
                        return true;
                    case "001BFC2B6084"://ideia-frente??
                        return true;
                    case "485B39BB276E"://ideia-arte??
                        return true;
                    case "000C2983E462"://maquinavirtual1
                        return true;
                    case "000C29D2B287"://maquinavirtual2(vinicius)
                        return true;
                    case "001D6054A145"://eduardo-pc
                        return true;
                    case "00248CA47E4E"://santos-pc
                        return true;
                    case "0018E7195980"://Arte Livre 1
                        return true;
                    case "00306733DC90"://Arte Livre 2
                        return true;
                    case "00241DF1A926"://eduardo-tb
                        return true;
                    case "90E6BABF3C96"://servidor
                        return true;

                    case "000C4F35F13C"://veronica
                        return true;
                    case "0011D80F34C0"://veronica
                        return true;
                    case "0017AD0034C3"://veronica
                        return true;

                    case "485B39BB4C04"://claudia
                        return true;
                    case "001D7D8DFFF8"://claudia
                        return true;
                }
            }
            return false;
        }
    }
}
