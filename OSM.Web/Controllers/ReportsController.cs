using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSM.Interfaces.IServices;
using OSM.WebBase.Mvc;

namespace OSM.Web.Controllers
{
    public class ReportsController : BaseController
    {
        //
        // GET: /Reports/
        [SiteAuthorize(PermissionKey = "PrisonerReport")]
        public ActionResult PrisonerReport()
        {
            return View();
        }
	}
}