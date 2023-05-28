using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bober.Controllers
{
    public class BuildingController : Controller
    {
        public readonly BogbanContext _db;
        public BuildingController(BogbanContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["FlorSortParm"] = sortOrder == "Flor" ? "flor_desc" : "Flor";
            ViewData["StatusSortParm"] = sortOrder == "Status" ? "status_desc" : "Status";
            ViewData["BonusSortParm"] = sortOrder == "Bonus" ? "bonus_desc" : "Bonus";
            ViewData["DistrictSortParm"] = sortOrder == "District" ? "district_desc" : "District";
            ViewData["ZastrSortParm"] = sortOrder == "Zastr" ? "zastr_desc" : "Zastr";



            var building = _db.Building.Include(u => u.District).Include(u => u.Zastr).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                building = building.Where(a => a.Name.Contains(searchString) || a.Status.Contains(searchString) || a.Bonus.Contains(searchString) || a.District.Name.Contains(searchString) || a.District.Location.Contains(searchString) || a.District.Name.Contains(searchString) || a.Zastr.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    building = building.OrderByDescending(a => a.Name);
                    break;
                case "Flor":
                    building = building.OrderBy(s => s.FlorNumber).ThenBy(s => s.Id);
                    break;
                case "flor_desc":
                    building = building.OrderByDescending(s => s.FlorNumber).ThenBy(s => s.Id);
                    break;
                case "Status":
                    building = building.OrderBy(s => s.Status).ThenBy(s => s.Id);
                    break;
                case "status_desc":
                    building = building.OrderByDescending(s => s.Status).ThenBy(s => s.Id);
                    break;
                case "Bonus":
                    building = building.OrderBy(s => s.Bonus).ThenBy(s => s.Id);
                    break;
                case "bonus_desc":
                    building = building.OrderByDescending(s => s.Bonus).ThenBy(s => s.Id);
                    break;
                case "District":
                    building = building.OrderBy(s => s.District.Name).ThenBy(s => s.Id);
                    break;
                case "district_desc":
                    building = building.OrderByDescending(s => s.District.Name).ThenBy(s => s.Id);
                    break;
                case "Zastr":
                    building = building.OrderBy(s => s.Zastr.Name).ThenBy(s => s.Id);
                    break;
                case "zastr_desc":
                    building = building.OrderByDescending(s => s.Zastr.Name).ThenBy(s => s.Id);
                    break;
                default:
                    building = building.OrderBy(a => a.Name);
                    break;
            }
            return View(building.ToList());
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
