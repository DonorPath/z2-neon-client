using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    public class AccountData
    {
        public AccountData(NameValuePair[] x)
        {
            CreatedBy = x.GetValue(Fields.Account.accountCreatedBy);
            AccountCreated = x.GetValue(Fields.Account.accountCreatedTime);
            AccountId = x.GetValue(Fields.Account.accountId);
            AccountLastModifiedBy = x.GetValue(Fields.Account.accountLastModifiedBy);
            AccountLastModified = x.GetValue(Fields.Account.accountLastModifiedTime);
            AccountLoginName = x.GetValue(Fields.Account.accountLoginName);
            AccountNote = x.GetValue(Fields.Account.accountNote);
            AccountType = x.GetValue(Fields.Account.accountType);
            Activity = new ActivityData
            {
                AccountId = x.GetValue(Fields.Account.activityAccountId),
                CustomStatus = x.GetValue(Fields.Account.activityCustomStatus),
                EndDate = x.GetValue(Fields.Account.activityEndDate),
                EndTime = x.GetValue(Fields.Account.activityEndTime),
                Id = x.GetValue(Fields.Account.activityId),
                Location = x.GetValue(Fields.Account.activityLocation),
                Note = x.GetValue(Fields.Account.activityNote),
                Priority = x.GetValue(Fields.Account.activityPriority),
                Solicitation = x.GetValue(Fields.Account.activitySolicitation),
                StartDate = x.GetValue(Fields.Account.activityStartDate),
                StartTime = x.GetValue(Fields.Account.activityStartTime),
                Status = x.GetValue(Fields.Account.activityStatus),
                Subject = x.GetValue(Fields.Account.activitySubject)
            };
            Address = new AddressData
            {
                CreatedBy = x.GetValue(Fields.Account.addressCreatedBy),
                Created = x.GetValue(Fields.Account.addressCreatedTime),
                EndDate = x.GetValue(Fields.Account.addressEndDate),
                FullStreet = x.GetValue(Fields.Account.addressFullStreet),
                LastModifiedBy = x.GetValue(Fields.Account.addressLastModifiedBy),
                LastModified = x.GetValue(Fields.Account.addressLastModifiedTime),
                StartDate = x.GetValue(Fields.Account.addressStartDate),
                Type = x.GetValue(Fields.Account.addressType),
                State = x.GetValue(Fields.Account.state),
                Street1 = x.GetValue(Fields.Account.street1),
                Street2 = x.GetValue(Fields.Account.street2),
                Street3 = x.GetValue(Fields.Account.street3),
                Street4 = x.GetValue(Fields.Account.street4),
                ZipCode = x.GetValue(Fields.Account.zipCode),
                ZipSuffix = x.GetValue(Fields.Account.zipSuffix),
                Province = x.GetValue(Fields.Account.province),
                City = x.GetValue(Fields.Account.city),
                Country = x.GetValue(Fields.Account.country),
                County = x.GetValue(Fields.Account.county),
            };
            Metrics = new Metric[] {
                  new Metric 
                  {
                      Period = "All", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmountAll), 
                      DonationCount = x.GetValue(Fields.Account.donationCountAll),
                      MembershipCount = x.GetValue(Fields.Account.membershipCountAll),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmountAll),
                      OrderAmount = x.GetValue(Fields.Account.orderAmountAll),
                      OrderCount = x.GetValue(Fields.Account.orderCountAll),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmountAll),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCountAll),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmountAll),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCountAll)
                  },
                  new Metric 
                  {
                      Period = "2005", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2005), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2005),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2005),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2005),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2005),
                      OrderCount = x.GetValue(Fields.Account.orderCount2005),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2005),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2005),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2005),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2005)
                  },
                  new Metric 
                  {
                      Period = "2005-2006", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20052006), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20052006),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20052006),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20052006),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20052006),
                      OrderCount = x.GetValue(Fields.Account.orderCount20052006),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20052006),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20052006),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20052006),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20052006)
                  },
                  new Metric 
                  {
                      Period = "2006", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2006), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2006),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2006),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2006),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2006),
                      OrderCount = x.GetValue(Fields.Account.orderCount2006),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2006),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2006),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2006),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2006)
                  },
                  new Metric 
                  {
                      Period = "2006-2007", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20062007), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20062007),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20062007),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20062007),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20062007),
                      OrderCount = x.GetValue(Fields.Account.orderCount20062007),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20062007),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20062007),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20062007),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20062007)
                  },
                  new Metric 
                  {
                      Period = "2007", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2007), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2007),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2007),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2007),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2007),
                      OrderCount = x.GetValue(Fields.Account.orderCount2007),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2007),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2007),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2007),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2007)
                  },
                  new Metric 
                  {
                      Period = "2007-2008", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20072008), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20072008),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20072008),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20072008),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20072008),
                      OrderCount = x.GetValue(Fields.Account.orderCount20072008),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20072008),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20072008),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20072008),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20072008)
                  },
                  new Metric 
                  {
                      Period = "2008", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2008), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2008),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2008),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2008),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2008),
                      OrderCount = x.GetValue(Fields.Account.orderCount2008),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2008),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2008),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2008),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2008)
                  },
                  new Metric 
                  {
                      Period = "2008-2009", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20082009), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20082009),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20082009),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20082009),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20082009),
                      OrderCount = x.GetValue(Fields.Account.orderCount20082009),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20082009),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20082009),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20082009),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20082009)
                  },
                  new Metric 
                  {
                      Period = "2009", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2009), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2009),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2009),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2009),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2009),
                      OrderCount = x.GetValue(Fields.Account.orderCount2009),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2009),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2009),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2009),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2009)
                  },
                  
                  new Metric 
                  {
                      Period = "2009-2010", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20092010), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20092010),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20092010),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20092010),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20092010),
                      OrderCount = x.GetValue(Fields.Account.orderCount20092010),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20092010),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20092010),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20092010),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20092010)
                  },
                  new Metric 
                  {
                      Period = "2010", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2010), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2010),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2010),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2010),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2010),
                      OrderCount = x.GetValue(Fields.Account.orderCount2010),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2010),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2010),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2010),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2010)
                  },
                  new Metric 
                  {
                      Period = "2010-2011", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20102011), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20102011),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20102011),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20102011),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20102011),
                      OrderCount = x.GetValue(Fields.Account.orderCount20102011),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20102011),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20102011),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20102011),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20102011)
                  },
                  new Metric 
                  {
                      Period = "2011", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2011), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2011),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2011),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2011),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2011),
                      OrderCount = x.GetValue(Fields.Account.orderCount2011),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2011),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2011),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2011),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2011)
                  },
                  new Metric 
                  {
                      Period = "2011-2012", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20112012), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20112012),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20112012),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20112012),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20112012),
                      OrderCount = x.GetValue(Fields.Account.orderCount20112012),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20112012),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20112012),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20112012),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20112012)
                  },
                  new Metric 
                  {
                      Period = "2012", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2012), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2012),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2012),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2012),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2012),
                      OrderCount = x.GetValue(Fields.Account.orderCount2012),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2012),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2012),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2012),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2012)
                  },
                  new Metric 
                  {
                      Period = "2012-2013", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20122013), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20122013),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20122013),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20122013),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20122013),
                      OrderCount = x.GetValue(Fields.Account.orderCount20122013),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20122013),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20122013),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20122013),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20122013)
                  },
                  
                  
                  new Metric 
                  {
                      Period = "2013-2014", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20132014), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20132014),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20132014),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20132014),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20132014),
                      OrderCount = x.GetValue(Fields.Account.orderCount20132014),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20132014),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20132014),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20132014),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20132014)
                  },
                  
                  new Metric 
                  {
                      Period = "2014", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2014), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2014),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2014),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2014),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2014),
                      OrderCount = x.GetValue(Fields.Account.orderCount2014),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2014),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2014),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2014),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2014)
                  },
                  new Metric 
                  {
                      Period = "2014-2015", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20142015), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20142015),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20142015),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20142015),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20142015),
                      OrderCount = x.GetValue(Fields.Account.orderCount20142015),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20142015),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20142015),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20142015),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20142015)
                  },
                  
                  new Metric 
                  {
                      Period = "2015", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount2015), 
                      DonationCount = x.GetValue(Fields.Account.donationCount2015),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount2015),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount2015),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount2015),
                      OrderCount = x.GetValue(Fields.Account.orderCount2015),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount2015),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount2015),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount2015),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount2015)
                  },
                  
                  new Metric 
                  {
                      Period = "2015-2016", 
                      DonationAmount = x.GetValue(Fields.Account.donationAmount20152016), 
                      DonationCount = x.GetValue(Fields.Account.donationCount20152016),
                      MembershipCount = x.GetValue(Fields.Account.membershipCount20152016),
                      MembershipAmount = x.GetValue(Fields.Account.membershipAmount20152016),
                      OrderAmount = x.GetValue(Fields.Account.orderAmount20152016),
                      OrderCount = x.GetValue(Fields.Account.orderCount20152016),
                      PledgeAmount = x.GetValue(Fields.Account.pledgeAmount20152016),
                      PledgeCount = x.GetValue(Fields.Account.pledgeCount20152016),
                      RegistrationAmount = x.GetValue(Fields.Account.registrationAmount20152016),
                      RegistrationCount = x.GetValue(Fields.Account.registrationCount20152016)
                  }

              };
            BloggerName = x.GetValue(Fields.Account.bloggerName);
            Company = new CompanyData
            {
                Department = x.GetValue(Fields.Account.companyDepartment),
                Email = x.GetValue(Fields.Account.companyEmail),
                Name = x.GetValue(Fields.Account.companyName),
                Title = x.GetValue(Fields.Account.companyTitle)
            };
            Deceased = x.GetValue(Fields.Account.deceased);
            DoNotContact = x.GetValue(Fields.Account.doNotContact);
            DateOfBirthDay = x.GetValue(Fields.Account.dobDay);
            DateOfBirthMonth = x.GetValue(Fields.Account.dobMonth);
            DateOfBirthYear = x.GetValue(Fields.Account.dobYear);
            EmailOptOut = x.GetValue(Fields.Account.emailOptOut);
            Fax = new PhoneData
            {
                Area = x.GetValue(Fields.Account.faxArea),
                FullNumber = x.GetValue(Fields.Account.faxFullNumber),
                Number = x.GetValue(Fields.Account.faxNumber),
                Type = x.GetValue(Fields.Account.faxType),
            };
            FederalDistrict = x.GetValue(Fields.Account.federalDistrict);
            FirstDonationAmount = x.GetValue(Fields.Account.firstDonationAmount);
            FirstDonationDate = x.GetValue(Fields.Account.firstDonationDate);
            FirstEnrollmentDate = x.GetValue(Fields.Account.firstEnrollmentDate);
            FirstName = x.GetValue(Fields.Account.firstName);
            FirstOrderDate = x.GetValue(Fields.Account.firstOrderDate);
            FirstRegistrationDate = x.GetValue(Fields.Account.firstRegistrationDate);
            FullZipCode = x.GetValue(Fields.Account.fullZipCode);
            HouseholdName = x.GetValue(Fields.Account.householdName);
            HouseholdSalutation = x.GetValue(Fields.Account.householdSalutation);
            IndividualType = x.GetValue(Fields.Account.individualType);
            LastDonationAmount = x.GetValue(Fields.Account.lastDonationAmount);
            LastDonationDate = x.GetValue(Fields.Account.lastDonationDate);
            LastEnrollmentDate = x.GetValue(Fields.Account.lastEnrollmentDate);
            LastLoginTime = x.GetValue(Fields.Account.lastLoginTime);
            LastName = x.GetValue(Fields.Account.lastName);
            lastOrderDate = x.GetValue(Fields.Account.lastOrderDate);
            lastRegistration = x.GetValue(Fields.Account.lastRegistrationDate);
            MailRemindTime = x.GetValue(Fields.Account.mailRemindTime);
            MembershipCost = x.GetValue(Fields.Account.membershipCost);
            MembershipEndDate = x.GetValue(Fields.Account.membershipEndDate);
            MembershipEnrollType = x.GetValue(Fields.Account.membershipEnrollType);
            MembershipEnrollmentDate = x.GetValue(Fields.Account.membershipEnrollmentDate);
            MembershipName = x.GetValue(Fields.Account.membershipName);
            MembershipStartDate = x.GetValue(Fields.Account.membershipStartDate);
            MiddleName = x.GetValue(Fields.Account.middleName);
            Note = new NoteData
            {
                LastModified = x.GetValue(Fields.Account.noteLastModifiedTime),
                Text = x.GetValue(Fields.Account.noteText),
                Type = x.GetValue(Fields.Account.noteType),
            };
            OrganizationType = x.GetValue(Fields.Account.organizationType);
            Phone1 = new PhoneData
            {
                Area = x.GetValue(Fields.Account.phone1Area),
                FullNumber = x.GetValue(Fields.Account.phone1FullNumber),
                Number = x.GetValue(Fields.Account.phone1Number),
                Type = x.GetValue(Fields.Account.phone1Type)
            };
            Phone2 = new PhoneData
            {
                Area = x.GetValue(Fields.Account.phone2Area),
                FullNumber = x.GetValue(Fields.Account.phone2FullNumber),
                Number = x.GetValue(Fields.Account.phone2Number),
                Type = x.GetValue(Fields.Account.phone2Type)
            };
            Phone3 = new PhoneData
            {
                Area = x.GetValue(Fields.Account.phone3Area),
                FullNumber = x.GetValue(Fields.Account.phone3FullNumber),
                Number = x.GetValue(Fields.Account.phone3Number),
                Type = x.GetValue(Fields.Account.phone3Type)
            };
            Prospect = new ProspectData
            {
                AskAmount = x.GetValue(Fields.Account.prospectAskAmount),
                AskDate = x.GetValue(Fields.Account.prospectAskDate),
                Campaign = x.GetValue(Fields.Account.prospectCampaign),
                CampaignId = x.GetValue(Fields.Account.prospectCampaignId),
                Created = x.GetValue(Fields.Account.prospectCreatedTime),
                CustomStatus = x.GetValue(Fields.Account.prospectCustomStatus),
                Note = x.GetValue(Fields.Account.prospectNote),
                PledgeAmount = x.GetValue(Fields.Account.prospectPledgeAmount),
                PledgeDate = x.GetValue(Fields.Account.prospectPledgeDate),
                Purpose = x.GetValue(Fields.Account.prospectPurpose),
                SocialFundraiser = x.GetValue(Fields.Account.prospectSocialFundraiser),
                Solicitor = x.GetValue(Fields.Account.prospectSolicitor),
                Status = x.GetValue(Fields.Account.prospectStatus),
                SystemUser = x.GetValue(Fields.Account.prospectSystemUser),
                Updated = x.GetValue(Fields.Account.prospectUpdatedTime),

            };
            Salutation = x.GetValue(Fields.Account.salutation);
            ShippingAddress = new AddressData
            {
                Street1 = x.GetValue(Fields.Account.shippingAddress1),
                Street2 = x.GetValue(Fields.Account.shippingAddress2),
                Street3 = x.GetValue(Fields.Account.shippingAddress3),
                Street4 = x.GetValue(Fields.Account.shippingAddress4),
                City = x.GetValue(Fields.Account.shippingCity),
                Country = x.GetValue(Fields.Account.shippingCountry),
                County = x.GetValue(Fields.Account.shippingCounty),
                Email = x.GetValue(Fields.Account.shippingEmail),
                ShippingFaxNumber = new PhoneData
                {
                    Area = x.GetValue(Fields.Account.shippingFaxArea),
                    Number = x.GetValue(Fields.Account.shippingFaxNumber),
                    Type = x.GetValue(Fields.Account.shippingFaxType),
                },
                Phone1 = new PhoneData
                {
                    Area = x.GetValue(Fields.Account.shippingPhone1Area),
                    FullNumber = x.GetValue(Fields.Account.shippingPhone1FullNumber),
                    Number = x.GetValue(Fields.Account.shippingPhone1Number),
                    Type = x.GetValue(Fields.Account.shippingPhone1Type)
                },
                Phone2 = new PhoneData
                {
                    Area = x.GetValue(Fields.Account.shippingPhone2Area),
                    FullNumber = x.GetValue(Fields.Account.shippingPhone2FullNumber),
                    Number = x.GetValue(Fields.Account.shippingPhone2Number),
                    Type = x.GetValue(Fields.Account.shippingPhone2Type)
                },
                Phone3 = new PhoneData
                {
                    Area = x.GetValue(Fields.Account.shippingPhone3Area),
                    FullNumber = x.GetValue(Fields.Account.shippingPhone3FullNumber),
                    Number = x.GetValue(Fields.Account.shippingPhone3Number),
                    Type = x.GetValue(Fields.Account.shippingPhone3Type)
                },
                State = x.GetValue(Fields.Account.shippingState),
                ToName = x.GetValue(Fields.Account.shippingToName),
                ToOrganization = x.GetValue(Fields.Account.shippingToOrganization),
                ZipSuffix = x.GetValue(Fields.Account.shippingZipSuffix),
                ZipCode = x.GetValue(Fields.Account.shippingZipCode)

            };
            Source = x.GetValue(Fields.Account.source);
            StateHouseDistrict = x.GetValue(Fields.Account.stateHouseDistrict);
            StateSenateDistrict = x.GetValue(Fields.Account.stateSenateDistrict);
            StickyNote = x.GetValue(Fields.Account.stickyNote);
            Email1 = x.GetValue(Fields.Account.userEmail1);
            Email2 = x.GetValue(Fields.Account.userEmail2);
            Email3 = x.GetValue(Fields.Account.userEmail3);
            FullName = x.GetValue(Fields.Account.userFullName);
            Gender = x.GetValue(Fields.Account.userGender);
            PreferredName = x.GetValue(Fields.Account.userPreferredName);
            Prefix = x.GetValue(Fields.Account.userPrefix);
            Suffix = x.GetValue(Fields.Account.userSuffix);
            URL = x.GetValue(Fields.Account.userUrl);
        }
        public string AccountCreated;
        public string CreatedBy { get; set; }

        public string AccountLastModifiedBy { get; set; }

        public string AccountId { get; set; }

        public string AccountLastModified { get; set; }

        public string AccountLoginName { get; set; }

        public string AccountNote { get; set; }

        public string AccountType { get; set; }

        public ActivityData Activity { get; set; }

        public AddressData Address { get; set; }

        public Metric[] Metrics { get; set; }

        public string BloggerName { get; set; }


        public CompanyData Company { get; set; }

        public string Deceased { get; set; }

        public string DoNotContact { get; set; }

        public PhoneData Fax { get; set; }

        public string DateOfBirthDay { get; set; }

        public string DateOfBirthMonth { get; set; }

        public string DateOfBirthYear { get; set; }

        public string EmailOptOut { get; set; }

        public string FederalDistrict { get; set; }

        public string FirstDonationAmount { get; set; }

        public NoteData Note { get; set; }

        public string FirstDonationDate { get; set; }

        public string FirstEnrollmentDate { get; set; }

        public string FirstName { get; set; }

        public string FirstOrderDate { get; set; }

        public string FirstRegistrationDate { get; set; }

        public string FullZipCode { get; set; }

        public string HouseholdName { get; set; }

        public string HouseholdSalutation { get; set; }

        public string IndividualType { get; set; }

        public string LastDonationAmount { get; set; }

        public string LastDonationDate { get; set; }

        public string LastEnrollmentDate { get; set; }

        public string LastLoginTime { get; set; }

        public string LastName { get; set; }

        public string lastOrderDate { get; set; }

        public string lastRegistration { get; set; }

        public string MailRemindTime { get; set; }

        public string MembershipEndDate { get; set; }

        public string MembershipCost { get; set; }

        public string MembershipEnrollType { get; set; }

        public string MembershipEnrollmentDate { get; set; }

        public string MembershipName { get; set; }

        public string MembershipStartDate { get; set; }

        public string MiddleName { get; set; }

        public string OrganizationType { get; set; }

        public PhoneData Phone1 { get; set; }

        public PhoneData Phone2 { get; set; }

        public PhoneData Phone3 { get; set; }

        public ProspectData Prospect { get; set; }

        public string Salutation { get; set; }

        public AddressData ShippingAddress { get; set; }

        public string URL { get; set; }

        public string Suffix { get; set; }

        public string Prefix { get; set; }

        public string Gender { get; set; }

        public string FullName { get; set; }

        public string PreferredName { get; set; }

        public string Email3 { get; set; }

        public string Email2 { get; set; }

        public string Email1 { get; set; }

        public string StickyNote { get; set; }

        public string StateSenateDistrict { get; set; }

        public string StateHouseDistrict { get; set; }

        public string Source { get; set; }
    }
}
