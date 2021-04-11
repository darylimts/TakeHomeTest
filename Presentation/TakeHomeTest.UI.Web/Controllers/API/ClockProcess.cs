using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TakeHomeTest.Entities;
using TakeHomeTest.UI.Web.Shared;

namespace TakeHomeTest.UI.Web.Controllers.API
{
    public partial class ClockProcess : ProcessBase
    {
        public void SetDecrementValue(sbyte param)
        {
            using (var response = base.HTTPClient.SendAsync(base.InitializeRequest(HttpMethod.Get, "SetClockDecrement?decrementSecs=" + param)).Result)
            {
                base.VerifyStatusCodeAsync<string>(response);
            }                       
        }
        public Clock GetClock()
        {
            Clock result = default(Clock);
            using (var response = base.HTTPClient.SendAsync(base.InitializeRequest(HttpMethod.Get, "GetClockDecrement")).Result)
            {
                result = base.VerifyStatusCodeAsync<Clock>(response);
            }
            return result;
        }
    }
}
