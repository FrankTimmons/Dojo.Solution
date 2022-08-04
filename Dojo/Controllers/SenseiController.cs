using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Dojo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Controllers
{
  public class SenseiController : Controller
  {
    private readonly DojoContext _db;

    public SenseiController(DojoContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = ("Senseis");
      ViewBag.Header = ("Senseis");
      List<Sensei> model = _db.Senseis.Include(sensei => sensei.MartialArt).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = ("Add Sensei");
      ViewBag.Header = ("Add Sensei");
      ViewBag.MartialArtId = new SelectList(_db.MartialArts, "MartialArtId", "Type");
      ViewBag.Count = _db.MartialArts.ToList();
      return View();
    }

    [HttpPost]
    public ActionResult Create(Sensei sensei)
    {
      _db.Senseis.Add(sensei);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Sensei thisSensei = _db.Senseis.FirstOrDefault(sensei => sensei.SenseiId == id);
      return View(thisSensei);
    }

    public ActionResult Edit(int id)
    {
      var thisSensei = _db.Senseis.FirstOrDefault(sensei => sensei.SenseiId == id);
      ViewBag.MartialArtId = new SelectList(_db.MartialArts, "MartialArtId", "Type");
      return View(thisSensei);
    }

    [HttpPost]
    public ActionResult Edit(Sensei sensei)
    {
      _db.Entry(sensei).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSensei = _db.Senseis.FirstOrDefault(sensei => sensei.SenseiId == id);
      return View(thisSensei);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSensei = _db.Senseis.FirstOrDefault(sensei => sensei.SenseiId == id);
      _db.Senseis.Remove(thisSensei);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}