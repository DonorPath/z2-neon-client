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
            public static const string accountId = "Account Id";
            public static const string firstName = "First Name";
            public static const string lastName = "Last Name";
            public static const string userSuffix = "User Suffix";
            public static const string street1 = "Street 1";
            public static const string street2 = "Street 2";
            public static const string city = "City";
            public static const string state = "State";
            public static const string zipCode = "Zip Code";
            public static const string phone1 = "Phone1 Full Number (F)";
            public static const string email1 = "User Email 1";
            public static const string accountType = "Account Type";
            public static const string organizationType = "Organization Type";
            public static const string individualType = "Individual Type";
            public static const string companyName = "Company Name";
            public static const string allDonationCount = "All Donation Count";
        }

        public class Donation
        {
            public static const string accountId = "Account Id";
            public static const string donationId = "Donation Id";
            public static const string donationDate = "Donation Date";
            public static const string amount = "Amount";
            public static const string donationStatus = "Donation Status";
            /// <summary>
            /// DO NOT USE - Exceeds WSDL contract width
            /// </summary>
            public static const string donationNote = "Donation Note";
            public static const string campaignName = "Campaign Name";

        }

        public class Membership
        {
            public static const string accountId = "Account Id";
            //public static const string membershipId = "Membership Id";

            public static const string lastEnrollmentDate = "Last Enrollment Date";
            public static const string membershipCost = "Membership Cost";
            public static const string membershipStatus = "Membership Status";
        }
    }
}
