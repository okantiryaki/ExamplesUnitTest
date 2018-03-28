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
        private CartItem _cartItem;
        private CartManager _cartManager;

        //her test metotundan önce çalışacak olan test testInitialize metotu
        [TestInitialize]
        public void TestInitialize()
        {
            _cartManager = new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Table",
                    ProductPrice = 120
                },
                Quantity = 1
            };

            _cartManager.Add(_cartItem);
        }

        //her test metotundan sonra çalışacak olan test testCleanup metotu
        [TestCleanup]
        public void TestCleanUp()
        {
            _cartManager.Clear();
        }

        [TestMethod]
        public void sepete_urun_eklenebilir()
        {
            // Arrange
            // bu değer fonksiyonumuz eğer doğru çalışır ise bize dönücek olan değer
            const int beklenen = 1;

            //Act Olay
            var toplamElamanSayisi = _cartManager.TotalItems;

            // burada karşılaştırma yapıyoruz.
            Assert.AreEqual(beklenen, toplamElamanSayisi);
        }

        [TestMethod]
        public void sepetten_urun_cikartilabilmelidir()
        {

            _cartManager.Add(_cartItem);
            var sepetteOlanUrunSayisi = _cartManager.TotalItems;

            _cartManager.Remove(1);
            var sepetteKalanGerekenUrunSayisi = _cartManager.TotalItems;

            // burada karşılaştırma yapıyoruz.
            Assert.AreEqual(sepetteOlanUrunSayisi - 1, sepetteKalanGerekenUrunSayisi);
        }
    }
}
