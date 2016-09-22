﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.IRepo;
using Repository.Logging;
using Repository.Models.Views;
using PagedList;

namespace CVHosting.Controllers
{
    public class CVApplicationsController : Controller
    {
        private ICVApplicationRepo _cvApplicationsRepo;
        private IAvailabilityRepo _availabilityRepo;
        private IPlaceRepo _placeRepo;
        private ILogger _logger;

        public CVApplicationsController(ICVApplicationRepo cvApplicationsRepo, IAvailabilityRepo availabilityRepo, IPlaceRepo placeRepo, ILogger logger)
        {
            _cvApplicationsRepo = cvApplicationsRepo;
            _availabilityRepo = availabilityRepo;
            _placeRepo = placeRepo;
            _logger = logger;
        }

        // GET: CVApplications
        [Authorize]
        public ActionResult Index(int? page, string sortOrder)
        {
            int currentPage = page ?? 1;
            int onPage = 4;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateTimeSort = String.IsNullOrEmpty(sortOrder) ? "DateTime" : "";
            ViewBag.NameSort = sortOrder == "Name" ? "NameAsc" : "Name";
            ViewBag.WorkplaceSort = sortOrder == "Workplace" ? "WorkplaceAsc" : "Workplace";
          

            //var cVApplication = db.CVApplication.Include(c => c.Availability).Include(c => c.Place);
            var cVApplicationQuery = _cvApplicationsRepo.GetAllCVs();

            switch (sortOrder)
            {
                //case "DateTime":
                //    cVApplicationQuery = cVApplicationQuery.OrderByDescending(s => s.DataDodania);
                //    break;
                case "DateTime":
                    cVApplicationQuery = cVApplicationQuery.OrderBy(s => s.DataDodania);
                    break;
                case "Name":
                    cVApplicationQuery = cVApplicationQuery.OrderByDescending(s => s.Name);
                    break;
                case "NameAsc":
                    cVApplicationQuery = cVApplicationQuery.OrderBy(s => s.Name);
                    break;
                case "Workplace":
                    cVApplicationQuery = cVApplicationQuery.OrderByDescending(s => s.Workplace);
                    break;
                case "WorkplaceAsc":
                    cVApplicationQuery = cVApplicationQuery.OrderBy(s => s.Workplace);
                    break;
                default:    // id descending
                    cVApplicationQuery = cVApplicationQuery.OrderByDescending(s => s.DataDodania);
                    break;
            }

            return View(cVApplicationQuery.ToPagedList<CVApplication>(currentPage, onPage));
        }

        // GET: CVApplications/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVApplication cVApplication = _cvApplicationsRepo.GetCVApplicationById((int)id);
            if (cVApplication == null)
            {
                return HttpNotFound();
            }
            return View(cVApplication);
        }

        // GET: CVApplications/Create
        public ActionResult Create()
        {
            var availabilityList = _availabilityRepo.GetAllAvailability().ToList();
            var placeList = _placeRepo.GetAllPlace().ToList();

            ViewBag.AvailabilityId = new SelectList(availabilityList, "Id", "Name");
            ViewBag.PlaceId = new SelectList(placeList, "Id", "Name");

            return View();
        }

        // POST: CVApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCVApplicationViewModel createCVApplicationViewModel)
        {
            CVApplication cVApplication = createCVApplicationViewModel.cvApplication;
            HttpPostedFileBase upload = createCVApplicationViewModel.File;

            if (ModelState.IsValid)
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var file = new CVFile
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            ContentType = upload.ContentType,
                            ContentLength = upload.ContentLength
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            file.Content = reader.ReadBytes(upload.ContentLength);
                        }

                        int fileID = _cvApplicationsRepo.AddCVFile(file);

                        cVApplication.CVFileId = fileID;

                        cVApplication.DataDodania = DateTime.Now;


                        _cvApplicationsRepo.AddCVApplication(cVApplication);
                        _cvApplicationsRepo.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    _logger.FatalFormat(ex, "Error in create CVAplication");

                    var availabilityListEx = _availabilityRepo.GetAllAvailability().ToList();
                    var placeListEx = _placeRepo.GetAllPlace().ToList();

                    ViewBag.AvailabilityId = new SelectList(availabilityListEx, "Id", "Name", cVApplication.AvailabilityId);
                    ViewBag.PlaceId = new SelectList(placeListEx, "Id", "Name", cVApplication.PlaceId);
                    return View(createCVApplicationViewModel);
                }
            }

            var availabilityList = _availabilityRepo.GetAllAvailability().ToList();
            var placeList = _placeRepo.GetAllPlace().ToList();

            ViewBag.AvailabilityId = new SelectList(availabilityList, "Id", "Name", cVApplication.AvailabilityId);
            ViewBag.PlaceId = new SelectList(placeList, "Id", "Name", cVApplication.PlaceId);
            return View(createCVApplicationViewModel);
        }

        // GET: CVApplications/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVApplication cVApplication = _cvApplicationsRepo.GetCVApplicationById((int)id);
            if (cVApplication == null)
            {
                return HttpNotFound();
            }

            var availabilityList = _availabilityRepo.GetAllAvailability().ToList();
            var placeList = _placeRepo.GetAllPlace().ToList();

            ViewBag.AvailabilityId = new SelectList(availabilityList, "Id", "Name", cVApplication.AvailabilityId);
            ViewBag.PlaceId = new SelectList(placeList, "Id", "Name", cVApplication.PlaceId);
            return View(cVApplication);
        }

        // POST: CVApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Workplace,Name,Email,Phone,Description,DataDodania,CVFileId,PlaceId,AvailabilityId")] CVApplication cVApplication)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cvApplicationsRepo.UpdateCVApplication(cVApplication);
                    _cvApplicationsRepo.SaveChanges();
                }
                catch (Exception ex)
                {
                    _logger.FatalFormat(ex, "Error in edit CVAplication");
                    var availabilityList = _availabilityRepo.GetAllAvailability().ToList();
                    var placeList = _placeRepo.GetAllPlace().ToList();

                    ViewBag.AvailabilityId = new SelectList(availabilityList, "Id", "Name", cVApplication.AvailabilityId);
                    ViewBag.PlaceId = new SelectList(placeList, "Id", "Name", cVApplication.PlaceId);
                    return View(cVApplication);
                }
            }
            return RedirectToAction("Details", new { id = cVApplication.Id });
        }

        // GET: CVApplications/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVApplication cVApplication = _cvApplicationsRepo.GetCVApplicationById((int)id);
            if (cVApplication == null)
            {
                return HttpNotFound();
            }

            if (error != null)
                ViewBag.Error = true;

            return View(cVApplication);
        }

        // POST: CVApplications/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _cvApplicationsRepo.DeleteCVApplication(id);
                _cvApplicationsRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.FatalFormat(ex, "Error in delete CVAplication");
                RedirectToAction("Delete", new { id = id, error = true });
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DownloadCVFile(int id)
        {
            CVFile cvFile = _cvApplicationsRepo.GetCVFileById(id);

            byte[] contents = cvFile.Content;
            return File(contents, cvFile.ContentType, cvFile.FileName);
        }
    }
}
