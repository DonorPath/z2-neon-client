using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    public class Donation : Revenue
    {
        public Donation(NameValuePair[] data)
        {
            decimal amount;
            Decimal.TryParse(data.GetValue("Amount"), out amount);
            Amount = amount;

            DateTime date;
            DateTime.TryParse(data.GetValue("Donation Date"), out date);
            Date = date;

            AccountId = data.GetValue("Account Id");
            SourceSegment = data.GetValue("Campaign Name");
            DonationId = data.GetValue("Donation Id");
            //Status = data.GetValue("Donation Status")
            //,SourceSubSegment = data.GetValue("Donation Note")    //Commented out for now - web service is throwing maxlength errors.
        }
    }
}
