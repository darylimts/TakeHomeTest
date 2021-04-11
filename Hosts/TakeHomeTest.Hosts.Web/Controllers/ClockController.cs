using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using TakeHomeTest.Entities;

namespace TakeHomeTest.Hosts.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClockController : ControllerBase
    {
        private static Clock _clock;

        public ClockController()
        {
            if (_clock == null)
            {
                _clock = new Clock();
            }
        }

        [HttpGet("/[controller]/SetClockDecrement")]
        public void SetClockDecrement(sbyte decrementSecs)
        {
            _clock.DecrementSecs = decrementSecs;
        }

        [HttpGet("/[controller]/GetClockDecrement")]
        public Clock GetClockDecrement()
        {
            return _clock;
        }

    }
}
