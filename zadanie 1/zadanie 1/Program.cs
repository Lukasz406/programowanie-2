using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //double wynik = 0.0;
           // Mat.OdwrotnaNotacjaPolska onp = new Mat.OdwrotnaNotacjaPolska();
           //// string wyrazenie = ("3.2+4*2/(1-5)^2^3");
           // Licz(args[0]);
           // Console.WriteLine();

            Zmienna(args[0],args[1]);

            Console.WriteLine();

            Przedzial(args[0],args[1],double.Parse(args[2]),double.Parse(args[3]),double.Parse(args[4]));

            Console.WriteLine("END");
        }

        static void Licz(string wyrazenie)
        {
            double wynik;
            Mat.OdwrotnaNotacjaPolska ONP = new Mat.OdwrotnaNotacjaPolska();
            Console.WriteLine();
            ONP.Parse(wyrazenie);
            wynik = ONP.Ocenianie();
            Console.WriteLine("Wersja poczatkowa: {0}", ONP.OrygnialneWyrazenie);
            Console.WriteLine("Wersja z zamiana: {0}", ONP.ZamianaWyrazenia);
            Console.WriteLine("Wersja z PostFix: {0}", ONP.WyrazeniePostfixowe);
            Console.WriteLine("Wynik: {0}", wynik);
            Console.WriteLine("");
        }
        static void Przedzial(string wyrazenie, string x, double p, double k, double n)
        {
            double wynik = 0.0;
            Mat.OdwrotnaNotacjaPolska onp = new Mat.OdwrotnaNotacjaPolska();
            double  odj, dziel, odej1;

            odj = k - p;
            odej1 = Math.Abs(odj);

            Console.WriteLine();

            dziel = odej1 / (n - 1);
            wynik = 0;
            //wyrazenie = "sinx";
            int index1 = wyrazenie.IndexOf('x');
            wyrazenie = wyrazenie.Remove(index1, Convert.ToInt32(x));
            string liczba;
            for (double i = p; i <= k; i += dziel)
            {
                liczba = i.ToString();
                liczba = liczba.Replace(',', '.');
                wyrazenie = wyrazenie.Insert(index1, liczba);
                //Console.WriteLine(wyrazenie);
                onp.Parse(wyrazenie);
                wynik = onp.Ocenianie();
                Console.WriteLine("oryginał: {0}", onp.OrygnialneWyrazenie);
                Console.WriteLine();
                Console.WriteLine("zamiana: {0}", onp.ZamianaWyrazenia);
                Console.WriteLine();
                Console.WriteLine("postfix: {0}", onp.WyrazeniePostfixowe);
                Console.WriteLine();
                Console.WriteLine("wynik: {0}", wynik);
                Console.WriteLine();
                wyrazenie = wyrazenie.Remove(index1, liczba.Length);


            }


        }
        static void Zmienna(string wyrazenie, string x)
        {
            Console.WriteLine("Wyrazenie dla podajego 'y'");
            Console.WriteLine();
            Console.WriteLine();
            double wynik = 0;



            Console.WriteLine();

            Console.WriteLine();

            int index = wyrazenie.IndexOf('x');
            wyrazenie = wyrazenie.Remove(index, 1);
            wyrazenie = wyrazenie.Insert(index, x);

            Mat.OdwrotnaNotacjaPolska ONP = new Mat.OdwrotnaNotacjaPolska();
            Console.WriteLine();
            ONP.Parse(wyrazenie);
            wynik = ONP.Ocenianie();
            Console.WriteLine("Wersja poczatkowa: {0}", ONP.OrygnialneWyrazenie);
            Console.WriteLine("Wersja z zamiana: {0}", ONP.ZamianaWyrazenia);
            Console.WriteLine("Wersja z PostFix: {0}", ONP.WyrazeniePostfixowe);
            Console.WriteLine("Wynik: {0}", wynik);
            Console.WriteLine("");

        }
    }
}