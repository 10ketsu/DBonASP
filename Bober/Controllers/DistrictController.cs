using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Bober.Controllers
{
    public class DistrictController : Controller
    {
        public readonly BogbanContext _db;
        public DistrictController(BogbanContext db) => _db = db;

        public IActionResult Index()
        {
            List<District> districtsList = _db.District.ToList();
            return View(districtsList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(District district)
        {
            if (ModelState.IsValid)
            {
                _db.District.Add(district);
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

            District? districtDB = _db.District.Find(id);
            if (districtDB == null)
            {
                return NotFound();
            }
            return View(districtDB);
        }

        [HttpPost]
        public IActionResult Edit(District district)
        {
            if (ModelState.IsValid)
            {
                _db.District.Update(district);
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

            District? districtDB = _db.District.Find(id);
            if (districtDB == null)
            {
                return NotFound();
            }
            return View(districtDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            District? districtDB = _db.District.Find(id);
            if (districtDB == null)
            {
                return NotFound();
            }
            _db.District.Remove(districtDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
