using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    public class Order : Revenue
    {
        public Order(Neon.NeonService.Order order)
        {
            Date = order.orderDate;
            AccountId = order.shoppingCart.accountId.ToString();
            DonationId = order.orderId.ToString();
            //order.shoppingCart.shoppingCartItems.First().product.name


            double eventItemTotal = 0;
            if (order.shoppingCart.shoppingCartItems.Any(x => x.product != null))
            {
                SourceSegment = "Product";
                eventItemTotal = order.shoppingCart.subTotal - order.shoppingCart.totalDiscount;
                eventItemTotal -= order.shoppingCart.shoppingCartItems.Where(x => x.itemInfo != null && x.itemInfo.itemType == ShoppingCartItemType.Donation).Sum(x => x.quantity * x.itemInfo.unitPrice);
                eventItemTotal -= order.shoppingCart.shoppingCartItems.Where(x => x.itemInfo != null && x.itemInfo.itemType == ShoppingCartItemType.Membership).Sum(x => x.quantity * x.itemInfo.unitPrice);
            }
            if (order.shoppingCart.shoppingCartItems.Any(x => x.itemInfo != null && x.itemInfo.itemType == ShoppingCartItemType.Event))
            {
                SourceSegment = "SpecialEvent";

                eventItemTotal = order.shoppingCart.totalCharge;
                eventItemTotal -= order.shoppingCart.shoppingCartItems.Where(x => x.itemInfo != null && x.itemInfo.itemType == ShoppingCartItemType.Donation).Sum(x => x.quantity * x.itemInfo.unitPrice);
                eventItemTotal -= order.shoppingCart.shoppingCartItems.Where(x => x.itemInfo != null && x.itemInfo.itemType == ShoppingCartItemType.Membership).Sum(x => x.quantity * x.itemInfo.unitPrice);
            }

            if (eventItemTotal > 0 && order.transaction.transactionStatus == TransactionStatus.Succeed)
            {
                Amount = Convert.ToDecimal(eventItemTotal);
            }
        }
    }
}
