using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt;
            List<Product> products = new List<Product>();
            do
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to add products");
                Console.WriteLine("Enter 2 to show products");
                Console.WriteLine("Enter 3 to watch Total Store Worth");
                Console.WriteLine("Enter 0 to Exit");
                opt = int.Parse(Console.ReadLine());
                if(opt==1)
                {
                    products.Add(addProducts(products));
                }
                else if(opt==2)
                {
                    showProducts(products);
                }
                else if(opt==3)
                {
                    Console.WriteLine("Total Store Worth is: "+totalWorth(products));
                }
            } while (opt!=0);
        }

        static Product addProducts(List<Product> products)
        {
            int id, price;
            string name, category, brandname, country;
            Console.Write("Enter ID: ");
            id=int.Parse(Console.ReadLine());
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter price: ");
            price = int.Parse(Console.ReadLine());
            Console.Write("Enter category: ");
            category = Console.ReadLine();
            Console.Write("Enter brandname: ");
            brandname = Console.ReadLine();
            Console.Write("Enter country: ");
            country = Console.ReadLine();
            Product obj = new Product(id, name, price, category, brandname, country);
            return obj;
        }
        static void showProducts(List<Product> products)
        {
            Console.WriteLine("ID \t Name \t Price \t  Category \t BrandName \t Category");
            for(int i=0;i<products.Count; i++)
            {
                products[i].showProduct();
            }
        }
        static int totalWorth(List<Product> products)
        {
            int sum = 0;
            for(int i=0;i<products.Count; i++)
            {
                sum += products[i].getPrice();
            }
            return sum;
        }
    }
}
