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

    public ActionResult Details(int id)
    {
      MartialArt thisMartialArt = _db.MartialArts.FirstOrDefault(martialArt => martialArt.MartialArtId == id);
      ViewBag.PageTitle = (thisMartialArt.Type + " Details");
      ViewBag.Header = (thisMartialArt.Type + " Details");
      return View(thisMartialArt);
    }

    public ActionResult Delete(int id)
    {
      MartialArt thisMartialArt = _db.MartialArts.FirstOrDefault(martialArt => martialArt.MartialArtId == id);
      ViewBag.PageTitle = ("Delete " + thisMartialArt.Type);
      ViewBag.Header = ("Delete " + thisMartialArt.Type + "?");
      return View(thisMartialArt);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      MartialArt thisMartialArt = _db.MartialArts.FirstOrDefault(martialArt => martialArt.MartialArtId == id);
      _db.MartialArts.Remove(thisMartialArt);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}