using ADToets.Opgave2;
using ADToets.Opgave3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Deze toets is gemaakt door Daan Stout
 * S1076173
 * Op 6 November 2017
 */ 

namespace ADToets {
    class Program {
        static void Main(string[] args) {
            //Opgave1();
            Opgave2();
            //Opgave3();

            Console.ReadKey();
        }

        static void Opgave1() {
            Console.WriteLine(AantalOnevenDigits(-1));
            Console.WriteLine(AantalOnevenDigits(-7));
            Console.WriteLine(AantalOnevenDigits(-12));
            Console.WriteLine(AantalOnevenDigits(-42));
            Console.WriteLine(AantalOnevenDigits(0));
            Console.WriteLine(AantalOnevenDigits(3));
            Console.WriteLine(AantalOnevenDigits(10));
            Console.WriteLine(AantalOnevenDigits(15));
            Console.WriteLine(AantalOnevenDigits(123456789));
        }

        static int AantalOnevenDigits(int getal) {
            if (getal == 0)
                return 0;
            else if (getal < 0)
                getal *= -1;

            if (getal % 2 == 1)
                return AantalOnevenDigits(getal / 10) + 1;
            else
                return AantalOnevenDigits(getal / 10);
        }

        static void Opgave2() {
            WoordBoom boom = new WoordBoom();
            Console.WriteLine(boom);

            boom.voeg_woord_toe("0");
            boom.voeg_woord_toe("1010");
            boom.voeg_woord_toe("10");
            boom.voeg_woord_toe("11");
            boom.voeg_woord_toe("11");
            boom.voeg_woord_toe("010");

            Console.WriteLine(boom);

            boom.voeg_woord_toe("11");
            boom.voeg_woord_toe("1010");
            boom.voeg_woord_toe("1011");
            boom.voeg_woord_toe("101");
            boom.voeg_woord_toe("1001");

            Console.WriteLine(boom.tel_woord("0"));
            Console.WriteLine(boom.tel_woord("1"));
            Console.WriteLine(boom.tel_woord("10"));
            Console.WriteLine(boom.tel_woord("11"));
            Console.WriteLine(boom.tel_woord("1010"));
            Console.WriteLine(boom.tel_woord("1000"));

            Console.WriteLine(boom);

            boom.woorden_met_lengte(4);
        }

        static void Opgave3() {
            Wereld w = new Wereld(4, 7);
            setupWorld(ref w);

            w.Print();
            Console.WriteLine();

            w.KortstePad(1, 2);
            w.PrintMetAfstand();
            Console.WriteLine();
            w.KortstePad(3, 6);
            w.PrintMetAfstand();
        }

        static void setupWorld(ref Wereld w) {
            w.MaakMuur(0, 0);
            w.MaakMuur(1, 0);
            w.MaakMuur(2, 0);
            w.MaakMuur(3, 0);
            w.MaakMuur(0, 2);
            w.MaakMuur(2, 2);
            w.MaakMuur(0, 3);
            w.MaakMuur(2, 3);
            w.MaakMuur(0, 4);
            w.MaakMuur(2, 5);
            w.MaakMuur(3, 5);
            w.MaakMuur(2, 6);
        }
    }
}
