using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie7
{
    class Delegacje
    {
       
       public delegate void Pogoda(int parametr);
        
        class Statek
        {
            public string kadlub;
            public string ster;
            public event Pogoda burza;
            public event Pogoda wichura;
            public static int liczbaStatkow;
            public void wyslijInformacje()
            {
                if (burza != null)
                    burza(1);

                if (wichura != null)
                    wichura(2);
            }

            
            public Statek(string kadlub, string ster)
            {

                kadlub = "Kadłub";

                ster = "Ster";
                liczbaStatkow++;
            }


            public static void pokazLiczbeStatkow()
            {
                Console.WriteLine("Liczba pojazdow: " + liczbaStatkow);
            }

        }



        class Zaglowka : Statek
        {
            public bool zagiel;
            
            
            public Zaglowka(string kadlub, string ster, bool zagiel)
                    : base(kadlub, ster)
            {
                zagiel = false;
            }


            public void decyzja(int warunki)
            {
                if (warunki <= 5)
                    Console.WriteLine("Wypływam");
                else
                    Console.WriteLine("Czekam aż pogoda się polepszy");
            }

           

            public void rozlozenieZagla()
            {
                while (true)
                {
                    if (zagiel == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Zagiel jest rozłożony");
                        Console.WriteLine("");
                        Console.WriteLine("Napisz(TAK) jeśli zagiel ma być rozłożony lub(NIE) jeśli zagiel nie ma być rozłożony, jeśli chcesz przejść dalej(NEXT):");
                    }
                    else if (zagiel == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Zagiel nie jest rozłożony");
                        Console.WriteLine("");
                        Console.WriteLine("Napisz (TAK) jeśli zagiel ma być rozłożony lub (NIE) jeśli zagiel nie ma być rozłożony, jeśli chcesz przejść dalej (NEXT):");
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                    string rozlozenieZagla = Console.ReadLine().ToLower();
                    zagiel = rozlozenieZagla == "TAK" ? true : false;
                }
            }
        }

        class Motorowka : Statek
        {

            public bool silnik;
            

            public Motorowka(string kadlub, string ster, bool silnik)
                    : base(kadlub, ster)
            {
                silnik = false;
            }
            

            public void decyzja(int warunki)
            {
                if (warunki <= 5)
                    Console.WriteLine("Wypływam");
                else
                    Console.WriteLine("Czekam aż pogoda się polepszy");
            }

            

            public void wlaczenieSilnika()
            {
                while (true)
                {
                    if (silnik == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Silnik włączony");
                        Console.WriteLine("");
                        Console.WriteLine("Napisz (TAK) jeśli chcesz włączyć silnik lub (NIE) jeśli chcesz wyłączyć silnik, jeśli chcesz przejść dalej (NEXT):");
                    }
                    else if (silnik == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Silnik nie jest włączony");
                        Console.WriteLine("");
                        Console.WriteLine("Napisz (TAK) jeśli chcesz włączyć silnik lub (NIE) jeśli chcesz wyłączyć silnik, jeśli chcesz przejść dalej (NEXT):");
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                    string wlaczenieSilnika = Console.ReadLine().ToLower();
                    silnik = wlaczenieSilnika == "TAK" ? true : false;
                }
            }
        }

           
       static void Main(string[] args)
       {
            Delegacje D1 = new Delegacje();

            //D1.wyswietl_Delegacje(); 
            
            Statek stat = new Statek("kadlub", "ster");

            Zaglowka zagl = new Zaglowka("kadlub", "ster", false);
            Motorowka moto = new Motorowka("kadlub", "ster", true);

            stat.burza += new Pogoda(zagl.decyzja);
            stat.burza += new Pogoda(moto.decyzja);
            stat.wichura += new Pogoda(zagl.decyzja);
            stat.wichura += new Pogoda(moto.decyzja);

            Console.ReadLine();
       }
        
    }
}
