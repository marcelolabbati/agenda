using Agenda.ADO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agenda.Controllers
{
    public class AgendaController : Controller
    {
        AgendaRepository agendaRepository = new AgendaRepository();

        // GET: Agenda
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agenda()
        {
            return View();
        }

        public ActionResult Dashboard() {
            return View();
        }
    }
}