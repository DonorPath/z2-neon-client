using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2Systems.Neon
{
    public class Revenue
    {
        public string DonationId { get; set; }

        public string AccountId { get; set; }

        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string SourceSegment { get; set; }
        public string SourceSubSegment { get; set; }

        public string Status { get; set; }
    }
}
