using Kata9.Model;
using Kata9.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata9Test
{
    public class Tests
    {
        Cashier CheckoutCashier;
        List<Item> Items;
        [SetUp]
        public void Setup()
        {
            var A = new Item("A", 50, 3, 130);
            var B = new Item("B", 30, 2, 45);
            var C = new Item("C", 20, -1, -1);
            var D = new Item("D", 15, -1, -1);
            Items = new List<Item> { A, B, C, D };
            CheckoutCashier = new Cashier();
        }

        [Test]
        public void TestApplyingTwoDiscounts()
        {
            float SubTotal;
            var checkoutCart = new List<string> { "A", "B", "C", "B", "A", "D", "A" };
            //Enumerable.Range(1, 999999).ToList().ForEach(i => checkoutCart.Add("A"));
            SubTotal = CheckoutCashier.Checkout(Items, checkoutCart);
            Assert.AreEqual(210, SubTotal, "This was applying two discounts");
        }
        [Test]
        public void TestApplyDiscountWithSeparatedItems()
        {
            float SubTotal;
            var checkoutCart = new List<string> { "A", "C", "B", "A", "D", "A" };
            SubTotal = CheckoutCashier.Checkout(Items, checkoutCart);
            Assert.AreEqual(195, SubTotal);
        }
        [Test]
        public void TestRegularPriceForOneItem()
        {
            float SubTotal;
            var checkoutCart = new List<string> { "A" };
            SubTotal = CheckoutCashier.Checkout(Items, checkoutCart);
            Assert.AreEqual(50, SubTotal);
        }
        [Test]
        public void TestDiscountWillApply()
        {
            float SubTotal;
            var checkoutCart = new List<string> { "A", "A", "A" };
            SubTotal = CheckoutCashier.Checkout(Items, checkoutCart);
            Assert.AreEqual(130, SubTotal);
        }
        [Test]
        public void TestOnlyDiscountSpecificAmount()
        {
            float SubTotal;
            var checkoutCart = new List<string> { "A", "A", "A", "A" };
            SubTotal = CheckoutCashier.Checkout(Items, checkoutCart);
            Assert.AreEqual(180, SubTotal);
        }
    }
}