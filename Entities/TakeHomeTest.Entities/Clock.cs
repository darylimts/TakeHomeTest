using System;
using System.ComponentModel.DataAnnotations;

namespace TakeHomeTest.Entities
{
    public partial class Clock
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Clock()
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
