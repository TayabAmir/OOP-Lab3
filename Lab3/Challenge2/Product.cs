using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge23
{
    internal class Product
    {
        public int id;
        public string name;
        public int price;
        public string category;
        public string brandname;
        public string country;

        public Product(int id, string name, int price, string category, string brandname, string country)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.category = category;
            this.brandname = brandname;
            this.country = country;
        }
        public void showProduct()
        {
            Console.WriteLine(id + "\t" + name + "\t" + price + "\t" + category + "\t" + brandname + "\t" +category);
        }
        public int getPrice()
        {
            return price;
        }

    }
}
