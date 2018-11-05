using Products.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Observers
{
    public class Webshop : Interfaces.IObserver<Product>
    {
        public string ShopName { get; set; }
        public List<Product> Products = new List<Product>();

        public Webshop(string name)
        {
            ShopName = name;
        }

        /// <summary>
        /// Add a product to the web shop.
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            Console.WriteLine($"{ShopName} heeft nu de {product.ProductName}. (artnr. {product.ProductId})");
            Products.Add(product);
            product.Register(this);
        }

        /// <summary>
        /// Remove a product from the web shop.
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Product product)
        {
            Console.WriteLine($"{ShopName} verkoopt de {product.ProductName} (artnr. {product.ProductId}) niet meer.");
            Products.Remove(product);
            product.Unregister(this);
        }

        /// <summary>
        /// Trigger an update when a product price changed.
        /// </summary>
        /// <param name="value"></param>
        public void Update(Product value)
        {
            Console.WriteLine(value.IsOnSale
                ? $"{ShopName} - {value.ProductName} is in de aanbieding! E{value.Price}"
                : $"{ShopName} heeft de prijs van {value.ProductName} gewijzigd naar E{value.Price}.");
        }
    }
}
