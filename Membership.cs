using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    public class Membership : Revenue
    {
        public Membership(NameValuePair[] giftData)
        {
            AccountId = giftData.GetValue("Account Id");

            if (giftData.GetValue("Membership Status").ToLowerInvariant() == "succeed")
            {

                SourceSegment = "Membership";
                //DonationId = giftData.GetValue("Membership Id")

                decimal amount;
                if (Decimal.TryParse(giftData.GetValue("Membership Cost"), out amount))
                    Amount = amount;

                DateTime date;
                if (DateTime.TryParse(giftData.GetValue("Last Enrollment Date"), out date))
                    Date = date;
            }
        }
    }
}
