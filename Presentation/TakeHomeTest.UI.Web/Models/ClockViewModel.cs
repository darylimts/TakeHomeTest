using System;
using System.ComponentModel.DataAnnotations;

namespace TakeHomeTest.UI.Web.Models
{
    public  partial class ClockViewModel
    {
        /// <summary>
        ///  Gets or sets a sbyte value for the DecrementSecs
        /// </summary>
        /// 
        [Required]
        [Display(Name = "Please Enter Decrement Time In Sec (1 - 60) ")]
        [Range(1, 60, ErrorMessage = "The Decrement Time  must be between 1 - 60")]
        public sbyte DecrementSecs { get; set; }

        public DateTime CurrentDateTime { get; set; }
        public DateTime DecrementDateTime { get; set; }
        public Boolean TimerStart { get; set; }
    }
}
