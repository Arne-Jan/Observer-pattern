using Products.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Observers
{
    /// <summary>
    /// A mail app should provide e-mails to its user when prices drop.
    /// </summary>
    public class MailServer : Interfaces.IObserver<Product>
    {
        public string MailName { get; set; }
        public List<Product> Products = new List<Product>();

        public MailServer(string name)
        {
            MailName = name;
        }

        /// <summary>
        /// Add a product to the list of observable products.
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            Console.WriteLine($"{MailName} bekijkt nu {product.ProductName} op prijswizigingen.");
            Products.Add(product);
            product.Register(this);
        }

        /// <summary>
        /// Remove a product from the list.
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Product product)
        {
            Console.WriteLine($"{MailName} bekijkt {product.ProductName} niet meer.");
            Products.Remove(product);
            product.Unregister(this);
        }

        /// <summary>
        /// Trigger an "e-mail" when a product price is on sale.
        /// </summary>
        /// <param name="value"></param>
        public void Update(Product value)
        {
            if (value.IsOnSale)
                Console.WriteLine($"Nieuwe mail van {MailName}\n\t{value.ProductName} is in de aanbieding! E{value.Price}");
        }
    }
}
