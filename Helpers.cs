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

        public static MembershipData ToMembershipData(this NameValuePair[] data)
        {
            MembershipData membership = new MembershipData();
            membership.accountId = Convert.ToInt64(data.GetValue(Fields.Membership.accountId));
            membership.status = data.GetValue(Fields.Membership.membershipStatus);
            double amount;
            double.TryParse(data.GetValue(Fields.Membership.membershipCost), out amount);
            membership.amount = amount;
            DateTime date;
            if (DateTime.TryParse(data.GetValue(Fields.Membership.lastMembershipEnrollmentDate), out date))
                membership.enrollmentDate = date;
            return membership;
        }

        public static EventData ToEventData(this NameValuePair[] data)
        {
            long fee;
            DateTime date;
            EventData eventData = new EventData
            {
                EventId = Int64.Parse(data.GetValue(Fields.Event.EventID)),
                EventCost = Int64.TryParse(data.GetValue(Fields.Event.EventAdmissionFee), out fee) ? fee : data.GetValue(Fields.Event.EventAdmissionFee) != null && Int64.TryParse(data.GetValue(Fields.Event.EventAdmissionFee).Split('.')[0], out fee) ? fee : 0, // if the initial fails, try checking for a decimal before declairing it's zero
                EventDate = DateTime.TryParse(data.GetValue(Fields.Event.EventStartDate), out date) ? date : DateTime.MinValue
            };
            return eventData;
        }

        public static Donation ToDonation(this NameValuePair[] data)
        {
            Donation donation = new Donation();
            double amount;
            double.TryParse(data.GetValue(Fields.Donation.donationAmount), out amount);
            donation.amount = amount;

            DateTime date;
            DateTime.TryParse(data.GetValue(Fields.Donation.donationDate), out date);
            donation.date = date;

            donation.accountId = Convert.ToInt64(data.GetValue(Fields.Donation.accountId));
            donation.campaign = new IdNamePair{ name = data.GetValue(Fields.Donation.campaignName)};
            donation.donationId = Convert.ToInt64(data.GetValue(Fields.Donation.donationId));
            DonationStatus status = DonationStatus.Pending;
            if(Enum.TryParse<DonationStatus>(data.GetValue(Fields.Donation.donationStatus), true, out status))
                donation.status = status;
            //Status = data.GetValue("Donation Status")
            //,SourceSubSegment = data.GetValue("Donation Note")    //Commented out for now - web service is throwing maxlength errors.
            return donation;
        }

        
    }
}
