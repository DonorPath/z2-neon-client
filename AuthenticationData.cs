using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    public class AuthenticationData
    {
        public string name{get; set;}
        public long accountId { get; set; }
        public bool isMember { get;set; }
        public bool isSystemUser {get; set;}
        public MembershipSummary currentMembership {get; set;}
    }
}
