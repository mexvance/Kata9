using System;
using System.Collections.Generic;
using System.Text;

namespace Kata9.Model
{
    public class Item
    {
        public string Name { set; get; }
        public float Price { set; get; }
        public int BulkDiscountAmt { set; get; }
        public float BulkDiscountPrice{ set; get; }

        public Item(string name, float price, int discountAmt, float discountPrice)
        {
            this.Name = name;
            this.Price = price;
            this.BulkDiscountAmt = discountAmt;
            this.BulkDiscountPrice = discountPrice;
        }
    }
}
