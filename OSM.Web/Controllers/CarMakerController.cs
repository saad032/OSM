using System.Web.Mvc;
using OSM.Web.ViewModels.CarMaker;

namespace OSM.Web.Controllers
{
    public class CarMakerController : BaseController
    {
        public ActionResult AddEdit(int? id)
        {
            CarMakerViewModel carMakerViewModel = new CarMakerViewModel();
            return View(carMakerViewModel);
        }
    }
}