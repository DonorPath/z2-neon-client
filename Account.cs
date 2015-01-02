using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    public class Account
    {

        public Account(NameValuePair[] data)
        {
            FirstName = data.GetValue("First Name");
            LastName = data.GetValue("Last Name");
            Address1 = data.GetValue("Street 1");
            Address2 = data.GetValue("Street 2");
            City = data.GetValue("City");
            Email = data.GetValue("Email");
            Id = data.GetValue("Account Id");
            OrganizationName = data.GetValue("Company Name");
            Phone = data.GetValue("Phone1 Full Number (F)");
            State = data.GetValue("State");
            Zip = data.GetValue("Zip Code");

            FullName = new StringBuilder()
                .Append(FirstName)
                .Append(" ")
                .Append(LastName)
                .Append(" ")
                .Append(Suffix)
                .Append(" ")
                .Append(OrganizationName).ToString().Trim();

            Segment = new StringBuilder()
                .Append(data.GetValue("Account Type"))
                .Append(" ")
                .Append(data.GetValue("Organization Type"))
                .Append(data.GetValue("Individual Type")).ToString().Trim();

            if (Segment.Contains('|'))
            {
                Segment = Segment.Split('|').First().Trim();
            }
            string donationCount = data.GetValue("All Donation Count");
            TotalDonationCount = !string.IsNullOrEmpty(donationCount) ? Convert.ToInt32(donationCount) : 0;
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Segment { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrganizationName { get; set; }
        public int TotalDonationCount { get; set; }
        //public string EventAmountFy2013 { get; set; }
        //public string EventAmountFy2012 { get; set; }
        //public string EventAmountFy2011 { get; set; }

        public override string ToString()
        {
            var donor = new StringBuilder();
            donor.AppendFormat("Id: {0}", Id).AppendLine();
            donor.AppendFormat("Name: {0}", FullName).AppendLine();
            donor.AppendFormat("First Name: {0}", FirstName).AppendLine();
            donor.AppendFormat("Last Name: {0}", LastName).AppendLine();
            donor.AppendFormat("Suffix: {0}", Suffix).AppendLine();
            donor.AppendFormat("Segment: {0}", Segment).AppendLine();
            donor.AppendFormat("Address 1: {0}", Address1).AppendLine();
            donor.AppendFormat("Address 2: {0}", Address2).AppendLine();
            donor.AppendFormat("City: {0}", City).AppendLine();
            donor.AppendFormat("Zip: {0}", Zip).AppendLine();
            donor.AppendFormat("State: {0}", State).AppendLine();
            donor.AppendFormat("Phone: {0}", Phone).AppendLine();
            donor.AppendFormat("Email: {0}", Email).AppendLine();
            donor.AppendFormat("Organization: {0}", OrganizationName).AppendLine();

            return donor.ToString();
        }
    }
}
