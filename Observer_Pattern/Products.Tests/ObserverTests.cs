using System;
using Products;
using Products.Subject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products.Observers;
using Products.Interfaces;
using System.Collections.Generic;

namespace Products.Tests
{
    [TestClass]
    public class ObserverTests
    {
        /// <summary>
        /// Check if the price has changed.
        /// </summary>
        [TestMethod]
        public void TestPriceChanged()
        {
            Product fiets = new Product("fiets",1,10.00);
            fiets.UpdatePrice(15.00);
            Assert.AreEqual(15.00, fiets.Price);
        }

        /// <summary>
        /// Check if the product added the observer.
        /// </summary>
        [TestMethod]
        public void TestObserverAddedToProduct()
        {
            Webshop wehkamp = new Webshop("Wehkamp");
            Product fiets = new Product("fiets", 1, 10.00);
            
            wehkamp.AddProduct(fiets);
            Assert.AreEqual(wehkamp, fiets.Observers[0]);
        }

        /// <summary>
        /// Check if the observer gives a notification when the product's price has changed.
        /// </summary>
        [TestMethod]
        public void TestNotificationWhenPriceUpdated()
        {
            Webshop wehkamp = new Webshop("Wehkamp");
            Product fiets = new Product("fiets", 1, 10.00);

            wehkamp.AddProduct(fiets);

            using(var consoleOutput = new ConsoleListener())
            {
                fiets.UpdatePrice(5.00);
                Assert.AreEqual("Wehkamp - fiets is in de aanbieding! E5\r\n", consoleOutput.GetOutput());
            }
        }

        /// <summary>
        /// Check if there is no notification when the observer has been removed.
        /// </summary>
        [TestMethod]
        public void TestNoNotificationWhenObserverRemoved()
        {
            Webshop wehkamp = new Webshop("Wehkamp");
            Product fiets = new Product("fiets", 1, 10.00);

            wehkamp.AddProduct(fiets);
            wehkamp.RemoveProduct(fiets);

            using (var consoleOutput = new ConsoleListener())
            {
                fiets.UpdatePrice(5.00);
                Assert.AreNotEqual("Wehkamp - fiets is in de aanbieding! E5\r\n", consoleOutput.GetOutput());
            }
        }
    }
}
