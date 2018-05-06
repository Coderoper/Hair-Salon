using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalonApp.Models;

namespace HairSalonApp.Controllers
{
    public class CategoriesController : Controller
    {

        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/stylists")]
        public ActionResult Create()
        {
            Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Stylist> stylistClients = selectedStylist.GetSylist();
            model.Add("stylist", selectedStylist);
            model.Add("clients", stylistClients);
            return View(model);
        }


        [HttpPost("/clients")]
        public ActionResult CreateStylist()
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Stylist foundStylist = Stylist.Find(Int32.Parse(Request.Form["stylist-id"]));
          string StylistDescription = Request.Form["Stylist-name"];
          Stylist newStylist = new Stylist(StylistDescription);
          foundStylist.AddStylist(newStylist);
          List<Stylist> stylistClients = foundStylist.GetSylist();
          model.Add("clients", stylistClients);
          model.Add("stylist", foundStylist);
          return View("Details", model);
        }
    }
}
