using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW_Week3_Opgaves {
    public class Product {
        string name;
        string category;
        float price;
        bool inStock;

        public Product(string name, string category, float price, bool inStock) {
            this.name = name;
            this.category = category;
            this.price = price;
            this.inStock = inStock;
        }
    }
}
