using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitTest.Tests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void sepete_urun_eklenebilir()
        {
            // Arrange
            // bu değer fonksiyonumuz eğer doğru çalışır ise bize dönücek olan değer
            const int beklenen = 1;

            var cartManager = new CartManager();
            var cartItem = new CartItem
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Table",
                    ProductPrice = 120
                },
                Quantity = 1
            };            
            
            //Act Olay
            cartManager.Add(cartItem);
            var toplamElamanSayisi = cartManager.TotalItems;

            // burada karşılaştırma yapıyoruz.
            Assert.AreEqual(beklenen, toplamElamanSayisi);
        }
    }
}
