using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Bober.Controllers
{
    public class ZastrController : Controller
    {
        public readonly BogbanContext _db;
        public ZastrController(BogbanContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SpecSortParm"] = sortOrder == "Spec" ? "spec_desc" : "Spec";

            var zastr = _db.Zastr.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                zastr = zastr.Where(a => a.Name.Contains(searchString) || a.Status.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    zastr = zastr.OrderByDescending(a => a.Name);
                    break;
                case "Spec":
                    zastr = zastr.OrderBy(s => s.Status).ThenBy(s => s.Id);
                    break;
                case "spec_desc":
                    zastr = zastr.OrderByDescending(s => s.Status).ThenBy(s => s.Id);
                    break;
                default:
                    zastr = zastr.OrderBy(a => a.Name);
                    break;
            }
            return View(zastr.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Zastr zastr)
        {
            if (ModelState.IsValid)
            {
                _db.Zastr.Add(zastr);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Zastr? zastrDB = _db.Zastr.Find(id);
            if (zastrDB == null)
            {
                return NotFound();
            }
            return View(zastrDB);
        }

        [HttpPost]
        public IActionResult Edit(Zastr zastr)
        {
            if (ModelState.IsValid)
            {
                _db.Zastr.Update(zastr);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Zastr? zastrDB = _db.Zastr.Find(id);
            if (zastrDB == null)
            {
                return NotFound();
            }
            return View(zastrDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Zastr? zastrDB = _db.Zastr.Find(id);
            if (zastrDB == null)
            {
                return NotFound();
            }
            _db.Zastr.Remove(zastrDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
