using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Week2.Opdracht1 {
    public interface ISimpleArrayList {
        // Toevoegen aan het einde van de lijst, mits de lijst niet vol is
        void add(int n); // O(c)
        // Haal de waarde op van een bepaalde index
        int get(int index); // O(c)
        // Wijzig een item op een bepaalde index
        void set(int index, int n); // O(c)
        // Print de inhoud van de list
        void print(); // O(N)
        // Maak de list leeg
        void clear(); // O(c)
        // Tel hoe vaak het gegeven getal voorkomt
        int countOccurences(int n); // O(N)
    }
}
