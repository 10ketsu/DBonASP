using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Bober.Controllers
{
    public class SotrudnikController : Controller
    {
        public readonly BogbanContext _db;
        public SotrudnikController(BogbanContext db) => _db = db;

        public IActionResult Index()
        {
            List<Sotrudnik> sotrudnikList = _db.Sotrudnik.ToList();
            return View(sotrudnikList);
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
