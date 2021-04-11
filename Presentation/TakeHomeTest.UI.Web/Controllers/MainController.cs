using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TakeHomeTest.UI.Web.Controllers.API;
using TakeHomeTest.UI.Web.Models;

namespace TakeHomeTest.UI.Web.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private static ClockViewModel _clock;
        private static Timer _timer;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        public MainController()
        {

        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Home()
        {
            if (_clock == null)
            {
                _clock = new ClockViewModel();
                return View(_clock);
            }
            else
            {
                return View(_clock);
            }
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Decrement(ClockViewModel clockViewModel)
        {
            return View(clockViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> CreateClockDTO(ClockViewModel clockViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            _clock = clockViewModel;

            // ClockProcess clockProcess = new ClockProcess();
            // clockProcess.SetDecrementValue(clockViewModel.DecrementSecs);
            //return RedirectToAction(nameof(Decrement), clockViewModel);

            return RedirectToAction(nameof(Home));
        }

        //[HttpPost]
        //public async Task<IActionResult> StartTimer()
        //{
        //    _clock.TimerStart = true;
        //    _clock.CurrentDateTime = DateTime.Now;
        //    _clock.DecrementDateTime = DateTime.Now.AddSeconds(-_clock.DecrementSecs);

        //    //_timer = new Timer();
        //    //_timer.Interval = 1000;
        //    //_timer.Elapsed += OnTimedEvent;
        //    //_timer.AutoReset = true;
        //    //_timer.Enabled = true;

        //    return RedirectToAction(nameof(Home));
        //}

        [HttpPost]
        public async Task<IActionResult> StopTimer()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _clock.TimerStart = false;
            _clock.DecrementSecs = 0;
            _clock.CurrentDateTime = DateTime.MinValue;
            _clock.DecrementDateTime = DateTime.MinValue;

            //_timer.Stop();
            //_timer.Dispose();
            //_timer = null;

            return RedirectToAction(nameof(Home));
        }

        //private void OnTimedEvent(object sender, ElapsedEventArgs e)
        //{
        //    storeClockModel();
        //    //RedirectToAction(nameof(Home));
        //}

        [HttpPost]
        public JsonResult storeClockModel()
        {
            if (_clock != null)
            {
                _clock.TimerStart = true;

                _clock.CurrentDateTime = DateTime.Now;
                _clock.DecrementDateTime = _clock.DecrementDateTime == DateTime.MinValue ?
                    DateTime.Now.AddSeconds(-_clock.DecrementSecs) :
                    _clock.DecrementDateTime.AddSeconds(-_clock.DecrementSecs);

                return Json(new
                {
                    currenttime = _clock.CurrentDateTime.ToString("yyyy-mm-dd hh:mm:ss"),
                    decrementtime = _clock.DecrementDateTime.ToString("yyyy-mm-dd hh:mm:ss")
                });
            }
            else
            {
                return null;
            }
        }

    }
}
