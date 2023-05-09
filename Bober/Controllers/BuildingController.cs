using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.ProjectModel;

namespace Bober.Controllers
{
    public class BuildingController : Controller
    {
        public readonly BogbanContext _db;
        public BuildingController(BogbanContext db) => _db = db;

        public IActionResult Index()
        {
            List<Building> buildingList = _db.Building.ToList();
            return View(buildingList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Building building)
        {
            if (ModelState.IsValid)
            {
                _db.Building.Add(building);
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

            Building? buildingDB = _db.Building.Find(id);
            if (buildingDB == null)
            {
                return NotFound();
            }
            return View(buildingDB);
        }

        [HttpPost]
        public IActionResult Edit(Building building)
        {
            if (ModelState.IsValid)
            {
                _db.Building.Update(building);
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

            Building? buildingDB = _db.Building.Find(id);
            if (buildingDB == null)
            {
                return NotFound();
            }
            return View(buildingDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Building? buildingDB = _db.Building.Find(id);
            if (buildingDB == null)
            {
                return NotFound();
            }
            _db.Building.Remove(buildingDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
