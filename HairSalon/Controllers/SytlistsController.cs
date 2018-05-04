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
            List<Stylist> allCategories = Stylist.GetAll();
            return View(allCategories);
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
            List<Stylist> allCategories = Stylist.GetAll();
            return View("Index", allCategories);
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Stylist> stylistClients = selectedStylist.GetStylists();
            model.Add("stylist", selectedStylist);
            model.Add("stylists", stylistClients);
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
          List<Stylist> stylistClients = foundStylist.GetStylists();
          model.Add("items", stylistClients);
          model.Add("stylist", foundStylist);
          return View("Details", model);
        }
    }
}
