using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADToets.Opgave3 {
    public interface IWereld {
        void MaakMuur(int row, int col);
        void MaakOpenPlek(int row, int col);
        void Print();
        string ToString();
    }
}
