using Microsoft.AspNetCore.Http;
using System.IO;

using Microsoft.AspNetCore.Mvc;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        private readonly IServiceFlight _flightService;
        private readonly IServicePlane _planeService;

        public FlightController(IServiceFlight flightService,IServicePlane planeService)
        {
            _planeService = planeService;
            _flightService = flightService;
        }

        // GET: FlightController
        public ActionResult Index()
        {

      
                return View(_flightService.GetMany().ToList());
      
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {

            var flight = _flightService.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // GET: FlightController/Create
        public ActionResult Create() { 
            ViewBag.Planes = new SelectList(_planeService.GetMany().ToList(),
                "PlaneId", "Information");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight)
        {
            
            try
            {
                _flightService.Add(flight);
                _flightService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var flight = _flightService.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }

            ViewBag.Planes = new SelectList(_planeService.GetMany().ToList(),
                "PlaneId", "Information", flight.PlaneId);
            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Flight flight)
        {
            try
            {
                _flightService.Update(flight);
                _flightService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
           
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flight = _flightService.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var flight = _flightService.GetById((int)id);
                _flightService.Delete(flight);
                _flightService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
