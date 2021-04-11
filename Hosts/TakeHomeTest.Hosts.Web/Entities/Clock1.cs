using System;
using System.ComponentModel.DataAnnotations;

namespace TakeHomeTest.Hosts.Web
{
    public partial class Clock1
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Clock1()
        {
            // Do Nothing
        }

        [Range(1, 60)]
        public sbyte DecrementSecs { get; set; }

        public DateTime CurrentDateTime { get; set; }
        public DateTime DecrementDateTime { get; set; }
        public Boolean TimerStart { get; set; }
    }
}
