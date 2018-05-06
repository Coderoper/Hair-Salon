
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalonApp.Models;
using System;

namespace HairSalonApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult CreateForm(int stylistId)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Stylist stylist = Stylist.Find(stylistId);
          return View(stylist);
        }
        [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Details(int stylistId, int clientId)
        {
          Client client = Client.Find(clientId);
          Dictionary<string, object> model = new Dictionary<string, object>();
          Stylist stylist = Stylist.Find(stylistId);
          model.Add("client", client);
          model.Add("stylist", stylist);
          return View(client);
        }
    //     [HttpGet("/clients")]
    //     public ActionResult Index()
    //     {
    //       // return new EmptyResult();
    //       List<Client> allClients = Client.GetAll();
    //       // return View();
    //       // return new EmptyResult();
    //       return View(allClients);
    //     }
    //
    //     [HttpGet("/clients/new")]
    //     public ActionResult CreateForm()
    //     {
    //         return View();
    //     }
    //     [HttpPost("/clients")]
    //     public ActionResult Create()
    //     {
    //       Client newClient = new Client (Request.Form["new-client"]);
    //       newClient.Save();
    //       List<Client> allClients = Client.GetAll();
    //       return View("Index", allClients);
    //     }
    //     [HttpPost("/clients/delete")]
    //     public ActionResult DeleteAll()
    //     {
    //         // Client.ClearAll();
    //         return View();
    //     }
    }
}
