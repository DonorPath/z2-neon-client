using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2Systems.Neon
{
    public class Fields
    {
        public class Account
        {
            public const string accountId = "Account Id";
            public const string firstName = "First Name";
            public const string lastName = "Last Name";
            public const string userSuffix = "User Suffix";
            public const string street1 = "Street 1";
            public const string street2 = "Street 2";
            public const string city = "City";
            public const string state = "State";
            public const string zipCode = "Zip Code";
            public const string phone1 = "Phone1 Full Number (F)";
            public const string email1 = "User Email 1";
            public const string accountType = "Account Type";
            public const string organizationType = "Organization Type";
            public const string individualType = "Individual Type";
            public const string companyName = "Company Name";
            public const string allDonationCount = "All Donation Count";
        }

        public class Donation
        {
            public const string accountId = "Account Id";
            public const string donationId = "Donation Id";
            public const string donationDate = "Donation Date";
            public const string amount = "Amount";
            public const string donationStatus = "Donation Status";
            /// <summary>
            /// DO NOT USE - Exceeds WSDL contract width
            /// </summary>
            public const string donationNote = "Donation Note";
            public const string campaignName = "Campaign Name";

        }

        public class Membership
        {
            public const string accountId = "Account Id";
            //public const string membershipId = "Membership Id";

            public const string lastEnrollmentDate = "Last Enrollment Date";
            public const string membershipCost = "Membership Cost";
            public const string membershipStatus = "Membership Status";
        }
    }
}
