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
    public class PlacesController : Controller
    {
        private IPlaceRepo _availabilityRepo;
        private ILogger _logger;

        public PlacesController(IPlaceRepo availabilityRepo, ILogger logger)
        {
            _availabilityRepo = availabilityRepo;
            _logger = logger;
        }

        // GET: Places
        public ActionResult Index()
        {
            return View(_availabilityRepo.GetAllPlace().ToList());
        }

        // GET: Places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = _availabilityRepo.GetPlaceBuId((int)id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Place place)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _availabilityRepo.AddPlace(place);
                    _availabilityRepo.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.FatalFormat("Error in create place, Ex: ", ex.ToString());
                    return View(place);
                }
            }

            return View(place);
        }

        // GET: Places/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = _availabilityRepo.GetPlaceBuId((int)id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Place place)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _availabilityRepo.UpdatePlace(place);
                    _availabilityRepo.SaveChanges();
                }
                catch (Exception ex)
                {
                    _logger.FatalFormat("Error in edit place, Ex: ", ex.ToString());
                    return View(place);
                }
            }
            return RedirectToAction("Details", new { id = place.Id });
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = _availabilityRepo.GetPlaceBuId((int)id);
            if (place == null)
            {
                return HttpNotFound();
            }

            if (error != null)
                ViewBag.Error = true;

            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _availabilityRepo.DeletePlace(id);
                _availabilityRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.FatalFormat("Error in delete place, Ex: ", ex.ToString());
                RedirectToAction("Delete", new { id = id, error = true });
            }

            return RedirectToAction("Index");
        }

    }
}
