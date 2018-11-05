using Products.Observers;
using Products.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Webshop bolCom = new Webshop("Bol.com");
            Webshop wehkamp = new Webshop("Wehkamp");
            MailServer prcWatch = new MailServer("PriceWatch");
            Product bakfiets = new Product("Bakfiets", 1104202, 149.99);

            // Bol.com sells the bakfiets.
            bolCom.AddProduct(bakfiets);
            Console.WriteLine();

            // Update the price, should notify all observers.
            bakfiets.UpdatePrice(120.00);
            Console.WriteLine();

            // Wehkamp sells the bakfiets as well.
            wehkamp.AddProduct(bakfiets);
            Console.WriteLine();

            // Update the price, should notify all observers.
            bakfiets.UpdatePrice(150.00);
            Console.WriteLine();

            // Bol.com does not sell the bakfiets anymore.
            // PriceWatch observes this product.
            bolCom.RemoveProduct(bakfiets);
            prcWatch.AddProduct(bakfiets);
            Console.WriteLine();

            // Update the price, should notify all observers except bol.com.
            bakfiets.UpdatePrice(100.00);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
