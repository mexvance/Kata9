using System;
using System.Collections.Generic;
using Kata9.Model;
using Kata9.Services;

namespace Kata9
{
    class Program
    {
        static void Main(string[] args)
        {
            var CheckoutCashier = new Cashier();
            float SubTotal;

            var A = new Item("A", 50, 3, 130);
            var B = new Item("B", 30, 2, 45);
            var C = new Item("C", 20, -1, -1);
            var D = new Item("D", 15, -1, -1);
            var Items = new List<Item> { A, B, C, D };
            var checkoutCart = new List<string> { "A", "B", "C", "B", "A", "D", "A"};

            SubTotal = CheckoutCashier.Checkout(Items, checkoutCart);
            Console.WriteLine("Your total price is: " + SubTotal);
        }
    }
}
