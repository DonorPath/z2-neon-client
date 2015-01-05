using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    internal static class Helpers
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
            membership.accountId = Convert.ToInt64(data.GetValue("Account Id"));
            membership.status = data.GetValue("Membership Status");
            double amount;
            double.TryParse(data.GetValue("Membership Cost"), out amount);
            membership.amount = amount;
            DateTime date;
            if (DateTime.TryParse(data.GetValue("Last Enrollment Date"), out date))
                membership.enrollmentDate = date;
            return membership;
        }


        public static Donation ToDonation(this NameValuePair[] data)
        {
            Donation donation = new Donation();
            double amount;
            double.TryParse(data.GetValue("Amount"), out amount);
            donation.amount = amount;

            DateTime date;
            DateTime.TryParse(data.GetValue("Donation Date"), out date);
            donation.date = date;

            donation.accountId = Convert.ToInt64(data.GetValue("Account Id"));
            donation.campaign = new IdNamePair{ name = data.GetValue("Campaign Name")};
            donation.donationId = Convert.ToInt64(data.GetValue("Donation Id"));
            //Status = data.GetValue("Donation Status")
            //,SourceSubSegment = data.GetValue("Donation Note")    //Commented out for now - web service is throwing maxlength errors.
            return donation;
        }

        public static Account ToAccount(this NameValuePair[] x)
        {
            if (x.GetValue("Account Type").ToLower().Contains("organization"))
            {
                return new OrganizationAccount
                {
                    accountId = Convert.ToInt64(x.GetValue("Account Id")),
                    organizationName = x.GetValue("Company Name"),
                    organizationTypes = new IdNamePair[]
                    {
                        new IdNamePair
                        {
                            name = x.GetValue("Organization Type")
                        }
                    },
                    primaryContact = new Contact
                    {
                        firstName = x.GetValue("First Name"),
                        lastName = x.GetValue("Last Name"),
                        email1 = x.GetValue("Email"),
                        phone1 = x.GetValue("Phone1 Full Number (F)"),
                        addresses = new Address[] 
                        { 
                            new Address
                            {
                                addressLine1 = x.GetValue("Street 1"), 
                                addressLine2 = x.GetValue("Street 2"),
                                city = x.GetValue("City"), 
                                state = new CodeNamePair
                                {
                                    name = x.GetValue("State")
                                }, 
                                zipCode = x.GetValue("Zip Code")

                            },
                        }
                    }
                };
            }
            else
            {
                return new IndividualAccount
                {
                    accountId = Convert.ToInt64(x.GetValue("Account Id")),
                    organizationName = x.GetValue("Company Name"),
                    individualTypes = new IdNamePair[]
                {
                    new IdNamePair
                    {
                        name = x.GetValue("Individual Type")
                    }
                },
                    primaryContact = new Contact
                    {
                        firstName = x.GetValue("First Name"),
                        lastName = x.GetValue("Last Name"),
                        email1 = x.GetValue("Email"),
                        phone1 = x.GetValue("Phone1 Full Number (F)"),
                        addresses = new Address[] 
                        { 
                            new Address
                            {
                                addressLine1 = x.GetValue("Street 1"), 
                                addressLine2 = x.GetValue("Street 2"),
                                city = x.GetValue("City"), 
                                state = new CodeNamePair
                                {
                                    name = x.GetValue("State")
                                }, 
                                zipCode = x.GetValue("Zip Code")

                            },

                        }
                    }
                };
            }
        }
    }
}
