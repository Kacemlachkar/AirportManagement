using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;
using AM.ApplicationCore.Domain;
using System.Numerics;

namespace AM.UI.WEB.Controllers
{
    public class TicketController : Controller
    {
        private readonly IServiceTicket tcktsrv;
        private readonly IServicePassenger psgsrv;
        private readonly IServiceFlight flgtsrv;
        // GET: TicketController

        public TicketController(IServiceTicket _tcktsrv, IServicePassenger _psgsrv, IServiceFlight _flgtsrv)
        {
            tcktsrv = _tcktsrv;
            psgsrv = _psgsrv;
            flgtsrv = _flgtsrv;
        }
        public ActionResult Index()
        {
   
                return View(tcktsrv.GetMany().ToList());
           
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            ViewBag.PassengerFK = new SelectList(psgsrv.GetMany(), "Id", "FullName.FirstName");
            ViewBag.FlightFK = new SelectList(flgtsrv.GetMany(), "FlightId", "Destination");
            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                tcktsrv.Add(ticket);
                tcktsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int? PassengerFK, int? FlightFK, int? TicketNbre)
        {
            if ((PassengerFK == null) || (FlightFK == null) || (TicketNbre == null))
            {
                return NotFound();
            }
            var ticket = tcktsrv.GetMany().Where(m => m.PassengerFK == PassengerFK && m.FlightFK == FlightFK && m.TicketNbre == TicketNbre).FirstOrDefault();
          
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            try
            {
  
                tcktsrv.Update(ticket);
                tcktsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int? PassengerFK, int? FlightFK, int? TicketNbre)
        {
            if ((PassengerFK == null) || (FlightFK == null) || (TicketNbre == null))
            {
                return NotFound();
            }
            var ticket = tcktsrv.GetMany()
                .FirstOrDefault(m => m.PassengerFK == PassengerFK && m.FlightFK == FlightFK && m.TicketNbre == TicketNbre);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
        
        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int PassengerFK, int FlightFK, int TicketNbre)
        {
            try
            {
                var ticket = tcktsrv.GetMany()
                .FirstOrDefault(m => m.PassengerFK == PassengerFK && m.FlightFK == FlightFK && m.TicketNbre == TicketNbre);
                tcktsrv.Delete(ticket);
                tcktsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
