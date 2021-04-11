using System;

namespace TakeHomeTest.UI.Web.Models
{
    public  partial class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
