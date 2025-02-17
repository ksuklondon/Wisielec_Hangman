using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisielec
{
    public class Wisielec
    {
        private static string[] slowa = { "kot", "pies", "dom", "zamek", "komputer", "matka", "lizak", "biedronka" };
        private static string[] cytaty = { "Śmierć", "jest", "tylko", "bramą", "do", "wieczności" };
        private static Random losowy = new Random();

        public void Zagraj()
        {
            string wybraneSlowo = WybierzSlowo();
            char[] zgadywaneLitery = InicjalizujZgadywaneLitery(wybraneSlowo);
            int maksymalnaLiczbaProb = 6;
            int pozostaleProby = maksymalnaLiczbaProb;

            while (pozostaleProby > 0 && !CzyWygrana(zgadywaneLitery, wybraneSlowo))
            {
                Console.WriteLine("\nPozostałe próby: " + pozostaleProby);
                Console.WriteLine("Dotychczas zgadywane litery: " + SformatujZgadywaneLitery(zgadywaneLitery));
                Console.Write("Podaj literę: ");

                char litera;
                try
                {
                    litera = Char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    if (!char.IsLetter(litera))
                    {
                        throw new ArgumentException("Niewłaściwy znak. Podaj literę alfabetu.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                if (CzyPowtorzonaLitera(litera, zgadywaneLitery))
                {
                    Console.WriteLine("Ta litera była już zgadywana.");
                    continue;
                }

                bool znaleziona = false;
                for (int i = 0; i < wybraneSlowo.Length; i++)
                {
                    if (wybraneSlowo[i] == litera)
                    {
                        zgadywaneLitery[i] = litera;
                        znaleziona = true;
                    }
                }

                if (!znaleziona)
                {
                    pozostaleProby--;
                    Console.WriteLine($"Niestety, litera '{litera}' nie znajduje się w słowie.");
                    if (maksymalnaLiczbaProb - pozostaleProby <= cytaty.Length)
                    {
                        Console.WriteLine("Cytat: " + string.Join(" ", cytaty, 0, maksymalnaLiczbaProb - pozostaleProby));
                    }
                }

                if (CzyWygrana(zgadywaneLitery, wybraneSlowo))
                {
                    Console.WriteLine("Gratulacje! Odgadłeś słowo: " + wybraneSlowo);
                    return;
                }
            }

            if (pozostaleProby == 0)
            {
                Console.WriteLine("Niestety, skończyły się próby. Słowo to było: " + wybraneSlowo);
            }
        }

        private string WybierzSlowo()
        {
            int indeksSłowa = losowy.Next(slowa.Length);
            return slowa[indeksSłowa].ToUpper();
        }

        private char[] InicjalizujZgadywaneLitery(string wybraneSlowo)
        {
            char[] zgadywaneLitery = new char[wybraneSlowo.Length];
            for (int i = 0; i < zgadywaneLitery.Length; i++)
            {
                zgadywaneLitery[i] = '_';
            }
            return zgadywaneLitery;
        }

        private bool CzyPowtorzonaLitera(char litera, char[] zgadywaneLitery)
        {
            return Array.IndexOf(zgadywaneLitery, litera) >= 0;
        }

        private bool CzyWygrana(char[] zgadywaneLitery, string wybraneSlowo)
        {
            return new string(zgadywaneLitery) == wybraneSlowo;
        }

        private string SformatujZgadywaneLitery(char[] zgadywaneLitery)
        {
            return string.Join(" ", zgadywaneLitery);
        }
    }
}
