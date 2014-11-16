using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OSM.Interfaces.IServices;
using OSM.Web.Controllers;
using OSM.Web.ModelMappers;
using OSM.Web.ViewModels.Common;
using OSM.Interfaces.IServices;
using OSM.Models.RequestModels;
using OSM.Web.ViewModels.DetentionLocation;
using DetentionLocation = OSM.Web.Models.DetentionLocation;
using Prisoner = OSM.Models.DomainModels.Prisoner;

namespace OSM.Web.Controllers
{
    public class DetentionLocationController : BaseController
    {
        private readonly IDetentionLocationService oDetentionLocationService;
        private readonly IPrisonerService oPrisonerService;

        #region Constructor

        public DetentionLocationController(IDetentionLocationService oDetentionLocationService, IPrisonerService oPrisonerService)
        {
            this.oDetentionLocationService = oDetentionLocationService;
            this.oPrisonerService = oPrisonerService;
        }

        #endregion

        #region Public

        public ActionResult Index()
        {
            if (Request.UrlReferrer == null || Request.UrlReferrer.AbsolutePath == "/DetentionLocation/Index")
            {
                Session["PageMetaData"] = null;
            }

            DetentionLocationSearchRequest detentionLocationSearchRequest =
                Session["PageMetaData"] as DetentionLocationSearchRequest;

            Session["PageMetaData"] = null;

            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new DetentionLocationViewModel
            {
                SearchRequest = detentionLocationSearchRequest ?? new DetentionLocationSearchRequest()
            });
        }

        [HttpPost]

        public ActionResult Index(DetentionLocationSearchRequest detentionLocationSearchRequest)
        {
            detentionLocationSearchRequest.UserId = Guid.Parse(Session["LoginID"] as string);
            var detentionAuthorities = oDetentionLocationService.GetAllDetentionLocations(detentionLocationSearchRequest);
            IEnumerable<DetentionLocation> detentionLocationList =
                detentionAuthorities.DetentionLocations.Select(x => x.CreateFrom()).ToList();
            DetentionLocationAjaxViewModel detentionLocationAjaxViewModel = new DetentionLocationAjaxViewModel
            {
                data = detentionLocationList,
                recordsTotal = detentionAuthorities.TotalCount,
                recordsFiltered = detentionAuthorities.TotalCount
            };

            // Keep Search Request in Session
            Session["PageMetaData"] = detentionLocationSearchRequest;

            return Json(detentionLocationAjaxViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEdit(int? id)
        {
            DetentionLocationViewModel viewModel = new DetentionLocationViewModel();
            if (id != null)
            {
                viewModel.DetentionLocation = oDetentionLocationService.FindDetentionLocationById(id).CreateFrom();

            }
            return View(viewModel);
        }

        // POST: DetentionLocation/AddEdit
        [HttpPost]
        public ActionResult AddEdit(DetentionLocationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            try
            {
                #region Update

                if (viewModel.DetentionLocation.DetentionLocationId > 0)
                {
                    var detentionLocationToUpdate = viewModel.DetentionLocation.CreateFrom();
                    detentionLocationToUpdate.UpdatedDate = DateTime.Now;
                    detentionLocationToUpdate.UpdatedBy = Session["LoginID"].ToString();
                    if (oDetentionLocationService.UpdateDetentionLocation(detentionLocationToUpdate))
                    {
                        return RedirectToAction("Index");
                    }
                }
                    #endregion

                #region Add

                else
                {
                    viewModel.DetentionLocation.CreatedDate = DateTime.Now;
                    viewModel.DetentionLocation.UpdatedDate = DateTime.Now;
                    viewModel.DetentionLocation.CreatedBy = Session["LoginID"].ToString();
                    viewModel.DetentionLocation.UpdatedBy = Session["LoginID"].ToString();
                    var modelToSave = viewModel.DetentionLocation.CreateFrom();

                    if (oDetentionLocationService.AddDetentionLocation(modelToSave))
                    {
                        viewModel.DetentionLocation.DetentionLocationId = modelToSave.DetentionLocationId;
                        return RedirectToAction("Index");
                    }
                }

                #endregion

            }
            catch (Exception e)
            {
                return RedirectToAction("AddEdit");
            }
            return View(viewModel);
        }

        public ActionResult Delete(int detentionLocationId)
        {
            var detentionLocationToBeDeleted = oDetentionLocationService.FindDetentionLocationById(detentionLocationId);
            try
            {
                var prisoners = oPrisonerService.LoadAllPrisoners();
                var enumerable = prisoners as IList<Prisoner> ?? prisoners.ToList();
                var prisonersWithDetentionId = enumerable.Where(x => x.PrisonerCaseInfo.DetentionLocationId != null && x.PrisonerCaseInfo.DetentionLocationId == detentionLocationId);
                if (!prisonersWithDetentionId.Any())
                {
                    oDetentionLocationService.DeleteDetentionLocation(detentionLocationToBeDeleted);
                    return
                    Json(
                        new
                        {
                            response = "Successfully Deleted  ",
                            status = (int)HttpStatusCode.OK
                        }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return
                    Json(
                        new
                        {
                            response = "Failed to delete. Error: Used in Prisoner Case Info ",
                            status = (int)HttpStatusCode.BadRequest
                        }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception exp)
            {
                return
                    Json(
                        new
                        {
                            response = "Failed to delete. Error: " + exp.Message,
                            status = (int)HttpStatusCode.BadRequest
                        }, JsonRequestBehavior.AllowGet);
            }
        }

    #endregion

    }
}