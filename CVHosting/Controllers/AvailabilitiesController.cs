using System;
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

namespace CVHosting.Controllers
{
    public class AvailabilitiesController : Controller
    {
        private IAvailabilityRepo _availabilityRepo;
        private ILogger _logger;

        public AvailabilitiesController(IAvailabilityRepo availabilityRepo, ILogger logger)
        {
            _availabilityRepo = availabilityRepo;
            _logger = logger;
        }

        // GET: Availabilities
        public ActionResult Index()
        {
            return View(_availabilityRepo.GetAllAvailability().ToList());
        }

        // GET: Availabilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = _availabilityRepo.GetAvailabilityBuId((int)id);
            if (availability == null)
            {
                return HttpNotFound();
            }
            return View(availability);
        }

        // GET: Availabilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Availabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _availabilityRepo.AddAvailability(availability);
                    _availabilityRepo.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    _logger.FatalFormat("Error in create availability, Ex: ", ex.ToString());
                    return View(availability);
                }
            }

            return View(availability);
        }

        // GET: Availabilities/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = _availabilityRepo.GetAvailabilityBuId((int)id);
            if (availability == null)
            {
                return HttpNotFound();
            }
            return View(availability);
        }

        // POST: Availabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _availabilityRepo.UpdateAvailability(availability);
                    _availabilityRepo.SaveChanges();
                }
                catch (Exception ex)
                {
                    _logger.FatalFormat("Error in edit availability, Ex: ", ex.ToString());
                    return View(availability);
                }
            }
            return RedirectToAction("Details", new { id = availability.Id});
        }

        // GET: Availabilities/Delete/5
        public ActionResult Delete(int? id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = _availabilityRepo.GetAvailabilityBuId((int)id);
            if (availability == null)
            {
                return HttpNotFound();
            }

            if (error != null)
                ViewBag.Error = true;

            return View(availability);
        }

        // POST: Availabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _availabilityRepo.DeleteAvailability(id);

            try
            {
                _availabilityRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.FatalFormat("Error in edit availability, Ex: ", ex.ToString());
                RedirectToAction("Delete", new { id = id, error = true });
            }

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
