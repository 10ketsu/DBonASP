using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bober.Controllers
{
    public class BuildingController : Controller
    {
        public readonly BogbanContext _db;
        public BuildingController(BogbanContext db) => _db = db;

        public IActionResult Index()
        {
            IEnumerable<Building> buildingList = _db.Building.ToList();
            return View(buildingList);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> ZastrList = _db.Zastr.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ZastrList = ZastrList;

            IEnumerable<SelectListItem> DistrictList = _db.District.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.DistrictList = DistrictList;

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

            IEnumerable<SelectListItem> ZastrList = _db.Zastr.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["ZastrList"] = ZastrList;

            IEnumerable<SelectListItem> DistrictList = _db.District.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewData["DistrictList"] = DistrictList;
            return View(buildingDB);
        }

        [HttpPost]
        public IActionResult Edit(Building building)
        {
            if (ModelState.IsValid)
            {
                //Building b = new Building()
                //{
                //    Id = building.Id,
                //    Name = building.Name,
                //    FlorNumber = building.FlorNumber,
                //    Status = building.Status,
                //    Bonus = building.Bonus,
                //    DistrictID = _db.District.FirstOrDefault(x => x.Id == building.DistrictID).Id,
                //    ZastrID = _db.Zastr.FirstOrDefault(x => x.Id == building.ZastrID).Id
                //};
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
