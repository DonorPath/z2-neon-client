using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Xml;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    public class Client : IDisposable
    {
            private static IdNamePair[] AccountFields
            {
                get
                {
                    return new IdNamePair[]
                {
                    new IdNamePair { name = "Account Id" },
                    new IdNamePair { name = "First Name" },
                    new IdNamePair { name = "Last Name" },
                    new IdNamePair { name = "User Suffix" },
                    new IdNamePair { name = "Street 1" },
                    new IdNamePair { name = "Street 2" },
                    new IdNamePair { name = "City" },
                    new IdNamePair { name = "State" },
                    new IdNamePair { name = "Zip Code" },
                    new IdNamePair { name = "Phone1 Full Number (F)" },
                    new IdNamePair { name = "User Email 1" },
                    new IdNamePair { name = "Account Type" },
                    new IdNamePair { name = "Organization Type" },
                    new IdNamePair { name = "Individual Type" },
                    new IdNamePair { name = "Company Name" },
                    new IdNamePair { name = "All Donation Count" },
                    //new IdNamePair { name = "2013-2014 Fiscal Registration Amount" },
                    //new IdNamePair { name = "2012-2013 Fiscal Registration Amount" },
                    //new IdNamePair { name = "2011-2012 Fiscal Registration Amount" }
                };
                }
            }

            private static IdNamePair[] DonationFields
            {
                get
                {
                    return new IdNamePair[]
                {
                    new IdNamePair { name = "Account Id" },
                    new IdNamePair { name = "Donation Id" },
                    new IdNamePair { name = "Donation Date" },
                    new IdNamePair { name = "Amount" },
                    //new IdNamePair { name = "Donation Note"},
                    new IdNamePair { name = "Campaign Name"},
                    //new IdNamePair { name = "Donation Status"}
                };
                }
            }

            private static IdNamePair[] MembershipFields
            {
                get
                {
                    return new IdNamePair[]
                {
                    new IdNamePair { name = "Account Id" },
                    //new IdNamePair { name = "Membership Id" },
                    new IdNamePair { name = "Last Enrollment Date" },
                    new IdNamePair { name = "Membership Cost" },
                    new IdNamePair { name = "Membership Status" }
                    //new IdNamePair { name = "Donation Note"},
                    //new IdNamePair { name = "Campaign Name"},
                    //new IdNamePair { name = "Donation Status"}
                };
                }
            }

            private static IdNamePair[] EventFields
            {
                get
                {
                    return new IdNamePair[] 
                { 
                    new IdNamePair { name = "Registration Status" },
                    new IdNamePair { name = "Registration Id" },
                    new IdNamePair { name = "Registration Amount" },
                    new IdNamePair { name = "Registration Time" },
                    new IdNamePair { name = "Shopping Cart Id"}
                };
                }
            }


            private BasicHttpBinding binding = null;

            private EndpointAddress donationAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/DonationService");
            private EndpointAddress eventAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/EventService");
            private EndpointAddress accountAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/AccountService");
            private EndpointAddress storeAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/StoreService");
            private EndpointAddress commonAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/CommonService");
            private EndpointAddress membershipAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/MembershipService");

            public Client(string apiKey, string orgId)
            {
                binding = new BasicHttpBinding{ MaxBufferSize = 2147483647, MaxReceivedMessageSize = 2147483647, ReceiveTimeout = new TimeSpan(0, 10, 0), SendTimeout = new TimeSpan(0, 10, 0)};
                binding.ReaderQuotas = new XmlDictionaryReaderQuotas { MaxDepth = 2147483647, MaxStringContentLength = 2147483647, MaxArrayLength = 2147483647, MaxBytesPerRead = 2147483647, MaxNameTableCharCount = 2147483647};
                binding.Security = new BasicHttpSecurity{ Mode = BasicHttpSecurityMode.Transport };
                ApiKey = apiKey;
                OrgId = orgId;
            }

            protected string ApiKey { get; set; }
            protected string OrgId { get; set; }
            protected string SessionId { get; set; }

            public void TryLogin()
            {
                EnsureSession();
            }

            public Account GetAccount(string accountId)
            {
                var search = new SearchObject { key = "Account Id", searchOperator = OperatorType.EQUAL, value = accountId };
                return GetAccounts(new SearchObject[1] { search }).FirstOrDefault();
            }

            public Account[] GetAccounts(SearchObject[] searches = null)
            {
                List<Account> accounts = new List<Account>();

                int pageSize = 100;
                EnsureSession();
                
                AccountServiceClient accountService = new AccountServiceClient(binding, accountAddress);

                ListAccountsResponse response = null;
                ListAccountsRequest request = new ListAccountsRequest
                {
                    userSessionId = SessionId,
                    page = new Page
                    {
                        currentPage = 0,
                        currentPageSpecified = true,
                        pageSize = pageSize,
                        pageSizeSpecified = true
                    },
                    outputFields = AccountFields
                };
                if (searches != null)
                    request.searches = searches;

                do
                {
                    request.page.currentPage++;

                    response = accountService.listAccounts(request);

                    if (response.operationResult == OperationResult.SUCCESS)
                    {
                        accounts.AddRange(response.searchResults.Select(x => x.ToAccount()));
                    }
                    else
                    {
                        throw new ApplicationException(string.Format("Neon Web Service Failure Code {0} : {1}", response.errors.First().errorCode, response.errors.First().errorMessage));
                    }
                } while (response.page.totalPage != response.page.currentPage);
                accountService.Close();
                return accounts.ToArray();
            }



            public Donation[] GetDonations()
            {
                List<Donation> donations = new List<Donation>();

                int pageSize = 100;
                EnsureSession();
                DonationServiceClient donationService = new DonationServiceClient(binding, donationAddress);
                ListDonationsResponse response = null;
                ListDonationsRequest request = new ListDonationsRequest
                {
                    userSessionId = SessionId,
                    page = new Page
                    {
                        currentPage = 0,
                        currentPageSpecified = true,
                        pageSize = pageSize,
                        pageSizeSpecified = true
                    },
                    outputFields = DonationFields,
                    searches = new[]
                    {
                        new SearchObject { key = "Donation Status", value = "SUCCEED"}
                    }
                };

                do
                {
                    request.page.currentPage++;

                    response = donationService.listDonations(request);

                    if (response.operationResult == OperationResult.SUCCESS)
                    {
                        donations.AddRange(response.searchResults.Select(x => x.ToDonation()));
                    }
                    else
                    {
                        throw new ApplicationException(string.Format("Neon Web Service Failure Code {0} : {1}", response.errors.First().errorCode, response.errors.First().errorMessage));
                    }
                } while (response.page.totalPage != response.page.currentPage);
                donationService.Close();
                return donations.ToArray();
            }



            public Order[] GetOrders(string accountId = null)
            {
                List<Order> orders = new List<Order>();
                EnsureSession();

                ListOrdersRequest request = new ListOrdersRequest
                {
                    userSessionId = SessionId,
                    page = new Page
                    {
                        currentPage = 0,
                        currentPageSpecified = true,
                        pageSize = 10,
                        pageSizeSpecified = true,
                    },
                    orderDateFromSpecified = true,
                    orderDateFrom = DateTime.Now.AddYears(-4)
                };

                if (accountId != null)
                {
                    request.accountId = Convert.ToInt64(accountId);
                    request.accountIdSpecified = true;
                }
                ListOrdersResponse response = null;

                StoreServiceClient storeService = new StoreServiceClient(binding, storeAddress);

                do
                {
                    request.page.currentPage++;

                    response = storeService.listOrders(request);

                    if (response.operationResult == OperationResult.SUCCESS)
                    {
                        orders.AddRange(response.orders);
                    }
                    else
                        throw new ApplicationException(string.Format("Neon Web Service Failure Code {0} : {1}", response.errors.First().errorCode, response.errors.First().errorMessage));
                } while (response.page.totalPage != response.page.currentPage);

                storeService.Close();



                return orders.ToArray();
            }


            public MembershipSummary[] GetAllMemberships()
            {
                EnsureSession();
                List<MembershipSummary> memberships = new List<MembershipSummary>();

                ListMembershipsRequest request = new ListMembershipsRequest
                {
                    userSessionId = SessionId,
                    page = new Page
                    {
                        currentPage = 0,
                        currentPageSpecified = true,
                        pageSize = 100,
                        pageSizeSpecified = true
                    },
                    outputFields = MembershipFields
                };

                MembershipServiceClient membershipService = new MembershipServiceClient(binding, membershipAddress);
                ListMembershipsResponse response = null;

                do
                {
                    request.page.currentPage++;

                    response = membershipService.listMemberships(request);

                    if (response.operationResult == OperationResult.SUCCESS)
                    {
                        memberships.AddRange(response.searchResults.Select(x => x.ToMembershipSummary()));
                    }
                    else
                        throw new ApplicationException(string.Format("Neon Web Service Failure Code {0} : {1}", response.errors.First().errorCode, response.errors.First().errorMessage));
                } while (response.page.totalPage != response.page.currentPage);


                membershipService.Close();

                return memberships.ToArray();
            }

            public string[] GetAccountTypes()
            {
                EnsureSession();

                AccountServiceClient accountService = new AccountServiceClient(binding, accountAddress);
                var individualTypes = accountService.listIndividualTypes(new ListIndividualTypesRequest() { userSessionId = SessionId });
                var organizationTypes = accountService.listOrganizationTypes(new ListOrganizationTypesRequest() { userSessionId = SessionId });
                var types = individualTypes.individualTypes.Select(x => string.Concat("Individual ", x.name))
                    .Union(organizationTypes.organizationTypes.Select(x => string.Concat("Organization ", x.name))).ToList();
                types.Add("Individual ");
                types.Add("Organization ");
                types.Add("Membership");
                accountService.Close();


                return types.ToArray();
            }

            protected void EnsureSession()
            {
                if (string.IsNullOrEmpty(SessionId))
                {
                    CommonServiceClient commonService = new CommonServiceClient(binding, commonAddress);
                    LoginRequest request = new LoginRequest
                    {
                        login = new APILogin
                        {
                            apiKey = ApiKey,
                            orgId = OrgId
                        }
                    };
                    LoginResponse loginResponse = commonService.login(request);
                    commonService.Close();

                    if (loginResponse.operationResult != OperationResult.SUCCESS)
                    {
                        throw new Exception("Error logging in to NeonCRM. Check the API key and Organization ID.");
                    }

                    SessionId = loginResponse.userSessionId;
                }
            }





            public void Dispose()
            {
                if (!string.IsNullOrEmpty(SessionId))
                {
                    CommonServiceClient commonService = new CommonServiceClient(binding, commonAddress);
                    LogoutRequest logoutRequest = new LogoutRequest { userSessionId = SessionId };
                    commonService.logout(logoutRequest);
                    commonService.Close();
                }
            }
        }

}