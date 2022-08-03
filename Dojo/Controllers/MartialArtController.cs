using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;
using Dojo.Models;
using System;

namespace Dojo.Controllers
{
  public class MartialArtController : Controller
  {
    private readonly DojoContext _db;

    public MartialArtController(DojoContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = ("Martial Arts");
      ViewBag.Header = ("MARTIAL ARTS");
      List<MartialArt> model = _db.MartialArts.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = ("Create Martial Art");
      ViewBag.Header = ("MARTIAL ART CREATION");
      return View();
    }

    [HttpPost]
    public ActionResult Create(MartialArt martialArt)
    {
      _db.MartialArts.Add(martialArt);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}