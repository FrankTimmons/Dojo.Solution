using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Dojo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Controllers
{
  public class DiscipleController : Controller
  {
    private readonly DojoContext _db;

    public DiscipleController(DojoContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = ("Disciples");
      ViewBag.Header = ("Disciples");
      return View(_db.Disciples.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = ("Add Disciple");
      ViewBag.Header = ("Add Disciples");      
      ViewBag.Count = _db.Senseis.ToList();
      ViewBag.SenseiId = new SelectList(_db.Senseis, "SenseiId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Disciple disciple, int senseiId)
    {
      _db.Disciples.Add(disciple);
      _db.SaveChanges();
      if (senseiId != 0)
      {
        _db.DiscipleSensei.Add(new DiscipleSensei() { SenseiId = senseiId, DiscipleId = disciple.DiscipleId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Disciple thisDisciple = _db.Disciples.FirstOrDefault(sensei => sensei.DiscipleId == id);
      ViewBag.PageTitle = (thisDisciple.Name + " Details");
      ViewBag.Header = ("Disciple " + thisDisciple.Name + " Details");
      return View(thisDisciple);
    }

    public ActionResult Edit(int id)
    {
      var thisDisciple = _db.Disciples.FirstOrDefault(sensei => sensei.DiscipleId == id);
      ViewBag.SenseiId = new SelectList(_db.Senseis, "SenseiId", "Name");
      return View(thisDisciple);
    }

    [HttpPost]
    public ActionResult Edit(Disciple sensei, int SenseiId)
    {
      if (SenseiId != 0)
      {
        _db.DiscipleSensei.Add(new DiscipleSensei() { SenseiId = SenseiId, DiscipleId = sensei.DiscipleId });
      }
      _db.Entry(sensei).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDisciple = _db.Disciples.FirstOrDefault(sensei => sensei.DiscipleId == id);
      return View(thisDisciple);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDisciple = _db.Disciples.FirstOrDefault(sensei => sensei.DiscipleId == id);
      _db.Disciples.Remove(thisDisciple);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteSensei(int joinId)
    {
      var joinEntry = _db.DiscipleSensei.FirstOrDefault(entry => entry.DiscipleSenseiId == joinId);
      _db.DiscipleSensei.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddSensei(int id)
    {
      var thisDisciple = _db.Disciples.FirstOrDefault(disciple => disciple.DiscipleId == id);
      ViewBag.PageTitle = (thisDisciple.Name + " Enroll");
      ViewBag.Header = ("Disciple " + thisDisciple.Name + " Enrollment");
      ViewBag.SenseiId = new SelectList(_db.Senseis, "SenseiId", "Name");
      return View(thisDisciple);
    }

    [HttpPost]
    public ActionResult AddSensei(Disciple disciple, int senseiId)
    {
      if (senseiId != 0)
      {
        _db.DiscipleSensei.Add(new DiscipleSensei() { SenseiId = senseiId, DiscipleId = disciple.DiscipleId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}