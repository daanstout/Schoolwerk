using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Week2_HW {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(faculteit(4));
            Console.WriteLine();
            Console.WriteLine(omenom(5));
            Console.WriteLine(omenom(6));
            Console.WriteLine(omenom(7));
            Console.WriteLine();
            Console.WriteLine(aantalEnen(7));
            Console.WriteLine(aantalEnen(9));
            Console.WriteLine();
            Console.WriteLine(binair(7));
            Console.WriteLine(binair(9));
            Console.WriteLine(binair(100));
            Console.WriteLine();
            Console.WriteLine(Decimal("1001"));
            Console.WriteLine(Decimal("111"));
            Console.WriteLine(Decimal("101100101010101001010101001"));

            Console.ReadKey();
        }

        static int faculteit(int i) {
            if (i <= 1) {
                return 1;
            } else {
                return i * faculteit(i - 1);
            }
        }

        static int omenom(int i) {
            if (i < 0) {
                return 0;
            } else if (i <= 2) {
                return i;
            } else {
                return i + omenom(i - 2);
            }
        }

        static int aantalEnen(int i) {
            if (i < 0) {
                return 0;
            } else if (i == 1) {
                return 1;
            } else if (i % 2 == 0) {
                return aantalEnen(i / 2);
            } else if (i % 2 == 1) {
                return aantalEnen(i / 2) + 1;
            }
            return 0;
        }

        static string binair(int i) {
            if (i < 0) {
                return "";
            } else if (i == 0) {
                return "0";
            } else if (i == 1) {
                return "1";
            } else if (i % 2 == 0) {
                return binair(i / 2) + "0";
            } else if (i % 2 == 1) {
                return binair(i / 2) + "1";
            }
            return "";
        }

        static int Decimal(string s) {
            if (s == "")
                return 0;
            if (s[0] == '1') {
                return (1 << s.Length - 1) + Decimal(s.Substring(1));
            } else if (s[0] == '0') {
                return Decimal(s.Substring(1));
            }
            return 0;
        }
    }
}
