using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisielec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Wisielec gra = new Wisielec();
                gra.Zagraj();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }
    }
}
