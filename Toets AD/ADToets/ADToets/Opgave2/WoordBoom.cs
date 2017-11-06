using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADToets.Opgave2 {
    public class WoordBoom {
        Node root;

        public WoordBoom() {
            root = new Node();
        }

        public override string ToString() {
            return ToString(root.nul) + " " + root.aantal + " " + ToString(root.een);
        }

        private string ToString(Node current) {
            if (current == null)
                return "NULL";
            else {
                return "[ " + ToString(current.nul) + " " + current.aantal + " " + ToString(current.een) + " ]";
            }
        }

        public void voeg_woord_toe(string woord) {
            if (woord.Equals("")) {
                root.aantal += 1;
                return;
            }

            if (!woord[0].Equals('1') && !woord[0].Equals('0'))
                return;

            if (woord[0].Equals('1')) {
                if (root.een == null)
                    root.een = new Node();
                voeg_woord_toe(woord.Substring(1), root.een);
            } else {
                if (root.nul == null)
                    root.nul = new Node();
                voeg_woord_toe(woord.Substring(1), root.nul);
            }
        }

        private void voeg_woord_toe(string woord, Node current) {
            if (woord.Equals("")) {
                current.aantal += 1;
                return;
            }

            if (!woord[0].Equals('1') && !woord[0].Equals('0'))
                return;

            if (woord[0].Equals('1')) {
                if (current.een == null)
                    current.een = new Node();
                voeg_woord_toe(woord.Substring(1), current.een);
            } else {
                if (current.nul == null)
                    current.nul = new Node();
                voeg_woord_toe(woord.Substring(1), current.nul);
            }
        }

        public int tel_woord(string woord) {
            if (woord.Equals(""))
                return root.aantal;

            if (!woord[0].Equals('1') && !woord[0].Equals('0'))
                return 0;

            if (woord[0].Equals('1')) {
                if (root.een == null)
                    return 0;
                return tel_woord(woord.Substring(1), root.een);
            } else {
                if (root.nul == null)
                    return 0;
                return tel_woord(woord.Substring(1), root.nul);
            }
        }

        private int tel_woord(string woord, Node current) {
            if (woord.Equals(""))
                return current.aantal;

            if (!woord[0].Equals('1') && !woord[0].Equals('0'))
                return 0;

            if (woord[0].Equals('1')) {
                if (current.een == null)
                    return 0;
                return tel_woord(woord.Substring(1), current.een);
            } else {
                if (current.nul == null)
                    return 0;
                return tel_woord(woord.Substring(1), current.nul);
            }
        }

        public void woorden_met_lengte(int lengte) {
            if (lengte < 0)
                return;

            if (lengte == 0) {
                if (root.aantal > 0)
                    Console.WriteLine("Root: " + root.aantal);
                return;
            }

            if (root.nul != null)
                woorden_met_lengte(lengte - 1, "0", root.nul);

            if (root.een != null)
                woorden_met_lengte(lengte - 1, "1", root.een);
        }

        private void woorden_met_lengte(int lengte, string route, Node current) {
            if (current == null)
                return;

            if (lengte == 0) {
                if (current.aantal > 0)
                    Console.WriteLine(route + " : " + current.aantal);
                return;
            }

            if (root.nul != null)
                woorden_met_lengte(lengte - 1, route + "0", current.nul);

            if (root.een != null)
                woorden_met_lengte(lengte - 1, route + "1", current.een);
        }
    }
}
