using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OSM.Interfaces.IServices;
using OSM.Web.Controllers;
using OSM.Web.ModelMappers;
using OSM.Web.Models;
using OSM.Web.ViewModels.Common;
using OSM.Interfaces.IServices;
using OSM.Models.RequestModels;
using OSM.Web.ViewModels.DetentionAuthority;
using Prisoner = OSM.Models.DomainModels.Prisoner;

namespace OSM.Web.Controllers
{
    public class DetentionAuthorityController : BaseController
    {
        private readonly IDetentionAuthorityService oDetentionAuthorityService;
        private readonly IPrisonerService oPrisonerService;

        #region Constructor

        public DetentionAuthorityController(IDetentionAuthorityService oDetentionAuthorityService, IPrisonerService oPrisonerService)
        {
            this.oDetentionAuthorityService = oDetentionAuthorityService;
            this.oPrisonerService = oPrisonerService;
        }

        #endregion

        #region Public

        public ActionResult Index()
        {
            if (Request.UrlReferrer == null || Request.UrlReferrer.AbsolutePath == "/DetentionAuthority/Index")
            {
                Session["PageMetaData"] = null;
            }

            DetentionAuthoritySearchRequest detentionAuthoritySearchRequest = Session["PageMetaData"] as DetentionAuthoritySearchRequest;

            Session["PageMetaData"] = null;

            ViewBag.MessageVM = TempData["MessageVm"] as MessageViewModel;

            return View(new DetentionAuthorityViewModel
            {
                SearchRequest = detentionAuthoritySearchRequest ?? new DetentionAuthoritySearchRequest()
            });
        }

        [HttpPost]

        public ActionResult Index(DetentionAuthoritySearchRequest detentionAuthoritySearchRequest)
        {
            detentionAuthoritySearchRequest.UserId = Guid.Parse(Session["LoginID"] as string);
            var detentionAuthorities = oDetentionAuthorityService.GetAllDetentionAuthorities(detentionAuthoritySearchRequest);
            IEnumerable<DetentionAuthority> detentionAuthorityList = detentionAuthorities.DetentionAuthorities.Select(x => x.CreateFrom()).ToList();
            DetentionAuthorityAjaxViewModel detentionAuthorityAjaxViewModel = new DetentionAuthorityAjaxViewModel
            {
                data = detentionAuthorityList,
                recordsTotal = detentionAuthorities.TotalCount,
                recordsFiltered = detentionAuthorities.TotalCount
            };

            // Keep Search Request in Session
            Session["PageMetaData"] = detentionAuthoritySearchRequest;

            return Json(detentionAuthorityAjaxViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEdit(int? id)
        {
            DetentionAuthorityViewModel viewModel = new DetentionAuthorityViewModel();
            if (id != null)
            {
                viewModel.DetentionAuthority = oDetentionAuthorityService.FindDetentionAuthorityById(id).CreateFrom();

            }
            return View(viewModel);
        }

        // POST: DetentionAuthority/AddEdit
        [HttpPost]
        public ActionResult AddEdit(DetentionAuthorityViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            try
            {
                #region Update

                if (viewModel.DetentionAuthority.DetentionAuthorityId > 0)
                {
                    var detentionAuthorityToUpdate = viewModel.DetentionAuthority.CreateFrom();
                    detentionAuthorityToUpdate.UpdatedDate = DateTime.Now;
                    detentionAuthorityToUpdate.UpdatedBy = Session["LoginID"].ToString();
                    if (oDetentionAuthorityService.UpdateDetentionAuthority(detentionAuthorityToUpdate))
                    {
                        return RedirectToAction("Index");
                    }
                }
                #endregion

                #region Add

                else
                {
                    viewModel.DetentionAuthority.CreatedDate = DateTime.Now;
                    viewModel.DetentionAuthority.UpdatedDate = DateTime.Now;
                    viewModel.DetentionAuthority.CreatedBy = Session["LoginID"].ToString();
                    viewModel.DetentionAuthority.UpdatedBy = Session["LoginID"].ToString();
                    var modelToSave = viewModel.DetentionAuthority.CreateFrom();

                    if (oDetentionAuthorityService.AddDetentionAuthority(modelToSave))
                    {
                        viewModel.DetentionAuthority.DetentionAuthorityId = modelToSave.DetentionAuthorityId;
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

        public ActionResult Delete(int detentionAuthorityId)
        {
            var detentionAuthorityToBeDeleted = oDetentionAuthorityService.FindDetentionAuthorityById(detentionAuthorityId);
            try
            {
                var prisoners = oPrisonerService.LoadAllPrisoners();
                var enumerable = prisoners as IList<Prisoner> ?? prisoners.ToList();
                var prisonersWithDetentionId =enumerable.Where(x => x.PrisonerCaseInfo.DetentionAuthorityId != null && x.PrisonerCaseInfo.DetentionAuthorityId == detentionAuthorityId);
                if (!prisonersWithDetentionId.Any())
                {
                    oDetentionAuthorityService.DeleteDetentionAuthority(detentionAuthorityToBeDeleted);
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