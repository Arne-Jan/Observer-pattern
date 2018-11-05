using Products.Interfaces;
using System.Collections.Generic;

namespace Products.Subject
{
    public class Product : ISubject
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool IsOnSale { get; set; }
        public List<IObserver<Product>> Observers = new List<IObserver<Product>>();

        public Product(string name, int id, double price)
        {
            ProductId = id;
            ProductName = name;
            Price = price;
        }

        /// <summary>
        /// Updates the product price.
        /// </summary>
        /// <param name="newPrice"></param>
        public void UpdatePrice(double newPrice)
        {
            IsOnSale = newPrice < Price;
            Price = newPrice;
            NotifyAll();
        }

        /// <summary>
        /// Notifies each observer with a update()
        /// </summary>
        public void NotifyAll()
        {
            foreach(IObserver<Product> observer in Observers)
            {
                observer.Update(this);
            }
        }

        /// <summary>
        /// Adds a observer to the list of observers
        /// </summary>
        /// <param name="observer"></param>
        public void Register(IObserver<Product> observer)
        {
            Observers.Add(observer);
        }

        /// <summary>
        /// Deletes a observer from the list of observers
        /// </summary>
        /// <param name="observer"></param>
        public void Unregister(IObserver<Product> observer)
        {
            Observers.Remove(observer);
        }
    }
}
