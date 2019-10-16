using Kata9.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata9.Services
{
    public class Cashier
    {
        public float Checkout(List<Item> Items, List<string> checkoutCart)
        {
            float SubTotal = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                SubTotal += CalculateSubTotal(checkoutCart, Items[i]);
            }
            return SubTotal;
        }
        public float CalculateSubTotal(List<string> items, Item newItem)
        {
            var HasPossibleDiscount = newItem.BulkDiscountAmt > -1 && newItem.BulkDiscountPrice > -1;
            var subTotal = HasPossibleDiscount 
                ? CalculateDiscountSubTotal(items, newItem) 
                : CalculateNoDiscountSubTotal(items, newItem);
            return subTotal;
        }

        private float CalculateDiscountSubTotal(List<string> items, Item newItem)
        {
            int itemCount = items.Count(i => i == newItem.Name);
            return GetDiscountSubTotal(itemCount, newItem);
        }

        private float GetDiscountSubTotal(int itemCount, Item newItem)
        {
            var totalDiscountedItems = GetTotalDiscountItems(itemCount, newItem);
            return CalculateDiscountSubTotal(itemCount, newItem, totalDiscountedItems);
        }

        private int GetTotalDiscountItems(int itemCount, Item newItem)
        {
            return itemCount - (itemCount % newItem.BulkDiscountAmt);
        }

        private float CalculateDiscountSubTotal(int itemCount, Item newItem, int totalDiscountedItems)
        { 
            float DiscountSubtotal;
            DiscountSubtotal = newItem.Price * (itemCount % newItem.BulkDiscountAmt);
            DiscountSubtotal += (totalDiscountedItems * newItem.BulkDiscountPrice) / newItem.BulkDiscountAmt;
            return DiscountSubtotal;
        }
        private float CalculateNoDiscountSubTotal(List<string> items, Item newItem)
        {
            float subTotal = items.Count(i => i == newItem.Name) * newItem.Price;
            return subTotal;
        }
    }
}
