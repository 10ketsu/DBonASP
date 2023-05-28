using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bober.Controllers
{
    public class FlatController : Controller
    {
        public readonly BogbanContext _db;
        public FlatController(BogbanContext db) => _db = db;
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NumberSortParm"] = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
            ViewData["StatusSortParm"] = sortOrder == "Status" ? "status_desc" : "Status";
            ViewData["RoomSortParm"] = sortOrder == "Room" ? "room_desc" : "Room";
            ViewData["SqyareSortParm"] = sortOrder == "Sqyare" ? "sqyare_desc" : "Sqyare";
            ViewData["FlorSortParm"] = sortOrder == "Flor" ? "flor_desc" : "Flor";
            ViewData["BuildingSortParm"] = sortOrder == "Building" ? "building_desc" : "Building";


            var flat = _db.Flat.Include(u => u.Building).ThenInclude(u => u.Zastr).Include(u => u.Building).ThenInclude(u => u.District).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                flat = flat.Where(a => a.FlatNumber.ToString().Contains(searchString) || a.Status.Contains(searchString) || a.RoomNumber.ToString().Contains(searchString) || a.Sqyare.ToString().Contains(searchString) || a.Flor.ToString().Contains(searchString) || a.Building.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "number_desc":
                    flat = flat.OrderByDescending(a => a.FlatNumber);
                    break;
                case "Status":
                    flat = flat.OrderBy(s => s.Status).ThenBy(s => s.Id);
                    break;
                case "status_desc":
                    flat = flat.OrderByDescending(s => s.Status).ThenBy(s => s.Id);
                    break;
                case "Room":
                    flat = flat.OrderBy(s => s.RoomNumber).ThenBy(s => s.Id);
                    break;
                case "room_desc":
                    flat = flat.OrderByDescending(s => s.RoomNumber).ThenBy(s => s.Id);
                    break;
                case "Sqyare":
                    flat = flat.OrderBy(s => s.Sqyare).ThenBy(s => s.Id);
                    break;
                case "sqyare_desc":
                    flat = flat.OrderByDescending(s => s.Sqyare).ThenBy(s => s.Id);
                    break;
                case "Flor":
                    flat = flat.OrderBy(s => s.Flor).ThenBy(s => s.Id);
                    break;
                case "flor_desc":
                    flat = flat.OrderByDescending(s => s.Flor).ThenBy(s => s.Id);
                    break;
                case "Building":
                    flat = flat.OrderBy(s => s.Building.Name).ThenBy(s => s.Id);
                    break;
                case "building_desc":
                    flat = flat.OrderBy(s => s.Building.Name).ThenBy(s => s.Id);
                    break;
                default:
                    flat = flat.OrderBy(a => a.FlatNumber);
                    break;
            }
            return View(flat.ToList());
        }

        public IActionResult Add()
        {

            IEnumerable<SelectListItem> BuildingList = _db.Building.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.BuildingList = BuildingList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Flat Flat)
        {
            if (ModelState.IsValid)
            {
                _db.Flat.Add(Flat);
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

            Flat? FlatDB = _db.Flat.Find(id);
            if (FlatDB == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> BuildingList = _db.Building.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.BuildingList = BuildingList;

            return View(FlatDB);
        }

        [HttpPost]
        public IActionResult Edit(Flat Flat)
        {
            if (ModelState.IsValid)
            {
                _db.Flat.Update(Flat);
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

            Flat? FlatDB = _db.Flat.Find(id);
            if (FlatDB == null)
            {
                return NotFound();
            }
            return View(FlatDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Flat? FlatDB = _db.Flat.Find(id);
            if (FlatDB == null)
            {
                return NotFound();
            }
            _db.Flat.Remove(FlatDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
