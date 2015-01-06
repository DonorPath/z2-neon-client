using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    internal static class Extensions
    {

        public static string GetValue(this NameValuePair[] data, string name)
        {
            var item = data.SingleOrDefault(x => x.name == name);
            if (item == null)
                return "";
            else
                return item.value;
        }

        public static MembershipData ToMembershipSummary(this NameValuePair[] data)
        {
            MembershipData membership = new MembershipData();
            membership.accountId = Convert.ToInt64(data.GetValue(Fields.Membership.accountId));
            membership.status = data.GetValue(Fields.Membership.membershipStatus);
            double amount;
            double.TryParse(data.GetValue(Fields.Membership.membershipCost), out amount);
            membership.amount = amount;
            DateTime date;
            if (DateTime.TryParse(data.GetValue(Fields.Membership.lastEnrollmentDate), out date))
                membership.enrollmentDate = date;
            return membership;
        }


        public static Donation ToDonation(this NameValuePair[] data)
        {
            Donation donation = new Donation();
            double amount;
            double.TryParse(data.GetValue(Fields.Donation.amount), out amount);
            donation.amount = amount;

            DateTime date;
            DateTime.TryParse(data.GetValue(Fields.Donation.donationDate), out date);
            donation.date = date;

            donation.accountId = Convert.ToInt64(data.GetValue(Fields.Donation.accountId));
            donation.campaign = new IdNamePair{ name = data.GetValue(Fields.Donation.campaignName)};
            donation.donationId = Convert.ToInt64(data.GetValue(Fields.Donation.donationId));
            donation.status = (DonationStatus)Enum.Parse(typeof(DonationStatus), data.GetValue(Fields.Donation.donationStatus), true);
            //Status = data.GetValue("Donation Status")
            //,SourceSubSegment = data.GetValue("Donation Note")    //Commented out for now - web service is throwing maxlength errors.
            return donation;
        }

        
    }
}
