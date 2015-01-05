using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Xml;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    public class Client
    {
        private BasicHttpBinding binding = null;

        private EndpointAddress donationAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/DonationService");
        private EndpointAddress eventAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/EventService");
        private EndpointAddress accountAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/AccountService");
        private EndpointAddress storeAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/StoreService");
        private EndpointAddress commonAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/CommonService");
        private EndpointAddress membershipAddress = new EndpointAddress("https://api.neoncrm.com/neonws/services/MembershipService");

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client()
        {
            binding = new BasicHttpBinding { MaxBufferSize = 2147483647, MaxReceivedMessageSize = 2147483647, ReceiveTimeout = new TimeSpan(0, 10, 0), SendTimeout = new TimeSpan(0, 10, 0) };
            binding.ReaderQuotas = new XmlDictionaryReaderQuotas { MaxDepth = 2147483647, MaxStringContentLength = 2147483647, MaxArrayLength = 2147483647, MaxBytesPerRead = 2147483647, MaxNameTableCharCount = 2147483647 };
            binding.Security = new BasicHttpSecurity { Mode = BasicHttpSecurityMode.Transport };
        }

        /// <summary>
        /// Connects this instance to the Neon Web Service using the specified API Key and organization ID.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="orgId">The org identifier.</param>
        public virtual void Connect(string apiKey, string orgId)
        {
            ApiKey = apiKey;
            OrgId = orgId;
            EnsureSession();
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        public void Disconnect()
        {
            if (!string.IsNullOrEmpty(SessionId))
            {
                CommonServiceClient commonService = new CommonServiceClient(binding, commonAddress);
                LogoutRequest logoutRequest = new LogoutRequest { userSessionId = SessionId };
                commonService.logout(logoutRequest);
                commonService.Close();
            }
        }

        /// <summary>
        /// Ensures the session.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// No API Key Specified.
        /// or
        /// No Organization ID Specified
        /// </exception>
        /// <exception cref="System.ApplicationException">Error logging in to NeonCRM. Check the API key and Organization ID.</exception>
        protected virtual void EnsureSession()
        {
            if (string.IsNullOrEmpty(ApiKey))
                throw new InvalidOperationException("No API Key Specified.");

            if (string.IsNullOrEmpty(OrgId))
                throw new InvalidOperationException("No Organization ID Specified");

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
                    throw new ApplicationException("Error logging in to NeonCRM. Check the API key and Organization ID.");
                }

                SessionId = loginResponse.userSessionId;
            }
        }

        private string ApiKey { get; set; }
        private string OrgId { get; set; }
        private string SessionId { get; set; }

        /// <summary>
        /// Lists the accounts.
        /// </summary>
        /// <param name="totalResults">The total results.</param>
        /// <param name="totalPages">The total pages.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortColumn">The sort column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="searches">The searches.</param>
        /// <param name="outputFields">The output fields.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">
        /// Error Communicating With Neon
        /// </exception>
        public Account[] ListAccounts(out long totalResults, out long totalPages, int? page, int pageSize = 100, string sortColumn = null, SortDirection? sortDirection = null, IEnumerable<SearchObject> searches = null, params string[] outputFields)
        {
            List<Account> accounts = new List<Account>();

            EnsureSession();

            AccountServiceClient accountService = new AccountServiceClient(binding, accountAddress);

            ListAccountsResponse response = null;
            ListAccountsRequest request = new ListAccountsRequest
            {
                userSessionId = SessionId,
                page = new Page
                {
                    currentPage = page ?? 0,
                    currentPageSpecified = true,
                    pageSize = pageSize,
                    pageSizeSpecified = true,
                },
                outputFields = outputFields.Select(x => new IdNamePair { name = x }).ToArray()
            };
            if (!string.IsNullOrEmpty(sortColumn))
            {
                request.page.sortColumn = sortColumn;
                sortDirection = sortDirection ?? SortDirection.ASC;
            }

            if (searches != null)
            {
                request.searches = searches.ToArray();
            }

            do
            {
                request.page.currentPage++;

                response = accountService.listAccounts(request);

                if (response.operationResult == OperationResult.SUCCESS)
                {
                    totalPages = response.page.totalPage;
                    totalResults = response.page.totalResults;
                    accounts.AddRange(response.searchResults.Select(x => x.ToAccount()));
                }
                else
                {
                    throw new ApplicationException("Error Communicating With Neon", new ApplicationException(string.Format("Erorr Code {0} : {1}", response.errors.First().errorCode, response.errors.First().errorMessage)));
                }
            } while (!page.HasValue && response.page.totalPage != response.page.currentPage);
            accountService.Close();
            return accounts.ToArray();
        }



        /// <summary>
        /// Lists the donations.
        /// </summary>
        /// <param name="totalResults">The total results.</param>
        /// <param name="totalPages">The total pages.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortColumn">The sort column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="searches">The searches.</param>
        /// <param name="outputFields">The output fields.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">
        /// Error Communicating With Neon
        /// </exception>
        public Donation[] ListDonations(out long totalResults, out long totalPages, int? page, int pageSize = 100, string sortColumn = null, SortDirection? sortDirection = null, IEnumerable<SearchObject> searches = null, params string[] outputFields)
        {
            List<Donation> donations = new List<Donation>();
            EnsureSession();
            DonationServiceClient donationService = new DonationServiceClient(binding, donationAddress);
            ListDonationsResponse response = null;
            ListDonationsRequest request = new ListDonationsRequest
            {
                userSessionId = SessionId,
                page = new Page
                {
                    currentPage = page ?? 0,
                    currentPageSpecified = true,
                    pageSize = pageSize,
                    pageSizeSpecified = true,
                },
                outputFields = outputFields.Select(x => new IdNamePair { name = x }).ToArray()
            };
            if (!string.IsNullOrEmpty(sortColumn))
            {
                request.page.sortColumn = sortColumn;
                sortDirection = sortDirection ?? SortDirection.ASC;
            }

            if (searches != null)
            {
                request.searches = searches.ToArray();
            }

            do
            {
                request.page.currentPage++;

                response = donationService.listDonations(request);

                if (response.operationResult == OperationResult.SUCCESS)
                {
                    totalPages = response.page.totalPage;
                    totalResults = response.page.totalResults;
                    donations.AddRange(response.searchResults.Select(x => x.ToDonation()));
                }
                else
                {
                    throw new ApplicationException("Error Communicating With Neon", new ApplicationException(string.Format("Erorr Code {0} : {1}", response.errors.First().errorCode, response.errors.First().errorMessage)));
                }
            } while (!page.HasValue && response.page.totalPage != response.page.currentPage);
            donationService.Close();
            return donations.ToArray();
        }




        /// <summary>
        /// Lists the orders.
        /// </summary>
        /// <param name="totalResults">The total results.</param>
        /// <param name="totalPages">The total pages.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="orderDateFrom">The order date from.</param>
        /// <param name="orderDateTo">The order date to.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">
        /// Error Communicating With Neon
        /// </exception>
        public Order[] listOrders(out long totalResults, out long totalPages, int? page, int pageSize = 10, string accountId = null, DateTime? orderDateFrom = null, DateTime? orderDateTo = null)
        {
            List<Order> orders = new List<Order>();
            EnsureSession();

            ListOrdersRequest request = new ListOrdersRequest
            {
                userSessionId = SessionId,
                page = new Page
                {
                    currentPage = page ?? 0,
                    currentPageSpecified = true,
                    pageSize = pageSize,
                    pageSizeSpecified = true,
                },
            };
            if(orderDateFrom.HasValue)
            {
                request.orderDateFrom = orderDateFrom.Value;
                request.orderDateFromSpecified = true;
            }
            if (orderDateTo.HasValue)
            {
                request.orderDateTo = orderDateTo.Value;
                request.orderDateToSpecified = true;
            }
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
                    totalPages = response.page.totalPage;
                    totalResults = response.page.totalResults;
                    orders.AddRange(response.orders);
                }
                else
                {
                    throw new ApplicationException("Error Communicating With Neon", new ApplicationException(string.Format("Erorr Code {0} : {1}", response.errors.First().errorCode, response.errors.First().errorMessage)));
                }
            } while (!page.HasValue && response.page.totalPage != response.page.currentPage);

            storeService.Close();
            return orders.ToArray();
        }


        public MembershipSummary[] ListMemberships(out long totalResults, out long totalPages, int? page, int pageSize = 100, string sortColumn = null, SortDirection? sortDirection = null, IEnumerable<SearchObject> searches = null, params string[] outputFields)
        {
            List<MembershipSummary> memberships = new List<MembershipSummary>();
            MembershipServiceClient membershipService = new MembershipServiceClient(binding, membershipAddress);
            EnsureSession();
            

            ListMembershipsRequest request = new ListMembershipsRequest
            {
                userSessionId = SessionId, 
                page = new Page
                {
                    currentPage = page ?? 0,
                    currentPageSpecified = true,
                    pageSize = pageSize,
                    pageSizeSpecified = true,
                },
                outputFields = outputFields.Select(x => new IdNamePair { name = x }).ToArray()
            };
            if (!string.IsNullOrEmpty(sortColumn))
            {
                request.page.sortColumn = sortColumn;
                sortDirection = sortDirection ?? SortDirection.ASC;
            }

            if(searches != null)
            {
                request.searches = searches.ToArray();
            }
            
            

            
            ListMembershipsResponse response = null;

            do
            {
                request.page.currentPage++;

                response = membershipService.listMemberships(request);

                if (response.operationResult == OperationResult.SUCCESS)
                {
                    totalPages = response.page.totalPage;
                    totalResults = response.page.totalResults;
                    memberships.AddRange(response.searchResults.Select(x => x.ToMembershipSummary()));
                }
                else
                {
                    throw new ApplicationException("Error Communicating With Neon", new ApplicationException(string.Format("Erorr Code {0} : {1}", response.errors.First().errorCode, response.errors.First().errorMessage)));
                }
            } while (!page.HasValue && response.page.totalPage != response.page.currentPage);


            membershipService.Close();

            return memberships.ToArray();
        }

        public IdNamePair[] IndividualTypes
        {
            get
            {
                EnsureSession();
                AccountServiceClient accountService = new AccountServiceClient(binding, accountAddress);
                return accountService.listIndividualTypes(new ListIndividualTypesRequest() { userSessionId = SessionId }).individualTypes;
            }
        }

        public IdNamePair[] OrganizationTypes
        {
            get
            {
                EnsureSession();
                AccountServiceClient accountService = new AccountServiceClient(binding, accountAddress);
                return accountService.listOrganizationTypes(new ListOrganizationTypesRequest() { userSessionId = SessionId }).organizationTypes;
            }
        }
    }

}