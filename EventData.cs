using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    public class EventData
    {
        public long EventId { get; set; }
        public decimal EventCost { get; set; }
        public DateTime EventDate { get; set; }
        public EventAttendee[] Attendees { get; set; }
    }

    public class EventAttendee
    {
        public long RegistrantAccountId { get; set; }
        public string RegistrantName { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
        public DateTime RegistrationDate { get; set; }
        public long AttendeeId { get; set; }
        public long AttendeeAccountId { get; set; }
        public string AttendeeFirstName { get; set; }
        public string AttendeeLastName { get; set; }
        public EventData Event { get; set; }
    }
}
