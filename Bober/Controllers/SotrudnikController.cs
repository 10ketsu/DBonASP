using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Bober.Controllers
{
    public class SotrudnikController : Controller
    {
        public readonly BogbanContext _db;
        public SotrudnikController(BogbanContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["FioSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fio_des" : "";
            ViewData["AgeSortParm"] = sortOrder == "Age" ? "age_desc" : "Age";
            ViewData["PolSortParm"] = sortOrder == "Pol" ? "pol_desc" : "Pol";
            ViewData["OtdelSortParm"] = sortOrder == "Otdel" ? "otdel_desc" : "Otdel";
            var sotrudnik = _db.Sotrudnik.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                sotrudnik = sotrudnik.Where(a => a.Fio.Contains(searchString) || a.Pol.Contains(searchString) || 
                a.Age.ToString().Contains(searchString) || a.OtdelName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "fio_des":
                    sotrudnik = sotrudnik.OrderByDescending(a => a.Fio);
                    break;
                case "Age":
                    sotrudnik = sotrudnik.OrderBy(s => s.Age);
                    break;
                case "age_desc":
                    sotrudnik = sotrudnik.OrderByDescending(s => s.Age);
                    break;
                case "Otdel":
                    sotrudnik = sotrudnik.OrderBy(s => s.OtdelName);
                    break;
                case "otdel_desc":
                    sotrudnik = sotrudnik.OrderByDescending(s => s.OtdelName);
                    break;
                case "Pol":
                    sotrudnik = sotrudnik.OrderBy(s => s.Pol);
                    break;
                case "pol_desc":
                    sotrudnik = sotrudnik.OrderByDescending(s => s.Pol);
                    break;
                default:
                    sotrudnik = sotrudnik.OrderBy(a => a.Fio);
                    break;
            }
            return View(sotrudnik.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Sotrudnik sotrudnik)
        {
            if (ModelState.IsValid)
            {
                _db.Sotrudnik.Add(sotrudnik);
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

            Sotrudnik? sotrudnikDB = _db.Sotrudnik.Find(id);
            if (sotrudnikDB == null)
            {
                return NotFound();
            }
            return View(sotrudnikDB);
        }

        [HttpPost]
        public IActionResult Edit(Sotrudnik sotrudnik)
        {
            if (ModelState.IsValid)
            {
                _db.Sotrudnik.Update(sotrudnik);
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

            Sotrudnik? sotrudnikDB = _db.Sotrudnik.Find(id);
            if (sotrudnikDB == null)
            {
                return NotFound();
            }
            return View(sotrudnikDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Sotrudnik? sotrudnikDB = _db.Sotrudnik.Find(id);
            if (sotrudnikDB == null)
            {
                return NotFound();
            }
            _db.Sotrudnik.Remove(sotrudnikDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
