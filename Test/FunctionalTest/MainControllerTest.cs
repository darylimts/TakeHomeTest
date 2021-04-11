using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using TakeHomeTest.UI.Web.Controllers;
using System.Threading.Tasks;
using TakeHomeTest.UI.Web.Models;
using System.Web.Mvc;

namespace FunctionalTest
{
    [TestClass]
    public class MainControllerTest
    {
        /// <summary>
        /// Test for Main View 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InitializePage()
        {
            // controller
            var controller = new MainController();

            var result = controller.Home();

            // if not null then continue, null end
            Assert.IsNotNull(result);

            var viewResult = result.Result;

            //Assert
            Assert.IsTrue(result.Status == TaskStatus.RanToCompletion && ((Microsoft.AspNetCore.Mvc.ViewResult)viewResult).Model != null);
        }

        /// <summary>
        /// TEst for Data Creation
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CreateClockDTO()
        {
            var controller = new MainController();
            ClockViewModel clockViewModel = new ClockViewModel()
            {
                DecrementSecs = 5
            };
            var result = controller.CreateClockDTO(clockViewModel);

            // if not null then continue, null end
            Assert.IsNotNull(result);

            var viewResult = result.Result;

            //Assert
            Assert.IsTrue(result.Status == TaskStatus.RanToCompletion && ((RedirectToActionResult)viewResult).ActionName=="Home");

        }

        /// <summary>
        /// Test for StopTImer
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task StopTimer()
        {
            var controller = new MainController();

            // call create ClokDTO to create Data.
            await CreateClockDTO();

            var result = controller.StopTimer();

            // if not null then continue, null end
            Assert.IsNotNull(result);
            var viewResult = result.Result;

            //Assert
            Assert.IsTrue(result.Status == TaskStatus.RanToCompletion && ((RedirectToActionResult)viewResult).ActionName == "Home");
        }

        /// <summary>
        /// Test for when timer running, update the clockModel
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task storeClockModel()
        {
            var controller = new MainController();
            
            // call create ClokDTO to create Data.
            await CreateClockDTO();
            var result = controller.storeClockModel();

            Assert.IsNotNull(result);

            ////Empty Data Model
            // result = controller.storeClockModel();
            //Assert.IsNull(result);
        }


    }
}
