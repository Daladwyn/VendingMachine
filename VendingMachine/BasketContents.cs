using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class BasketContents
    {
        public BasketContents()
        {
            BasketProductId = 1;
            BasketProductName = "";
            BasketNumberOfItems = 0;
            BasketProductPrice = 0;
        }

        internal int BasketProductId { get; set; }
        internal string BasketProductName { get; set; }
        internal int BasketNumberOfItems { get; set; }
        internal int BasketProductPrice { get; set; }
        internal int BasketTotalProductPrice { get; set; }
        
    }
}
