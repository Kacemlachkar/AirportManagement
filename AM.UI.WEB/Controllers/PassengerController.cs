using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AM.ApplicationCore.Domain;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AM.UI.WEB.Controllers
{
    public class PassengerController : Controller
    {
        // GET: PassengerController
        private readonly IServicePassenger _passengerService;

        public PassengerController(IServicePassenger passengerService)
        {
            _passengerService = passengerService;
        }
        // GET: PlaneController
        public ActionResult Index()
        {
            return View(_passengerService.GetMany().ToList());
        }

        // GET: PassengerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PassengerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PassengerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Passenger passenger)
        {
            try
            {
                _passengerService.Add(passenger);
                _passengerService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = _passengerService.GetById((int)id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: PassengerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Passenger passenger)
        {
            try
            {
                _passengerService.Update(passenger);
                _passengerService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var passenger = _passengerService.GetById((int)id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: PassengerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var plane = _passengerService.GetById((int)id);
                _passengerService.Delete(plane);
                _passengerService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
