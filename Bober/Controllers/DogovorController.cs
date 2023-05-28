using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bober.Controllers
{
    public class DogovorController : Controller
    {
        public readonly BogbanContext _db;
        public DogovorController(BogbanContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["DatesSortParm"] = String.IsNullOrEmpty(sortOrder) ? "dates_desc" : "";
            ViewData["DatefSortParm"] = sortOrder == "Datef" ? "datef_desc" : "Datef";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["SotrudnikSortParm"] = sortOrder == "Sotrudnik" ? "sotrudnik_desc" : "Sotrudnik";
            ViewData["ClientSortParm"] = sortOrder == "Client" ? "client_desc" : "Client";
            ViewData["FlatSortParm"] = sortOrder == "Flat" ? "flat_desc" : "Flat";


            var dogovor = _db.Dogovor.Include(u => u.Flat).ThenInclude(u => u.Building).ThenInclude(u => u.Zastr).Include(u => u.Flat).ThenInclude(u => u.Building).ThenInclude(u => u.District).Include(u => u.Client).Include(u => u.Sotrudnik).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                dogovor = dogovor.Where(a => a.DateStart.ToString().Contains(searchString) || a.DateFinish.ToString().Contains(searchString) || a.Price.ToString().Contains(searchString) || a.Sotrudnik.Id.ToString().Contains(searchString) || a.Client.Id.ToString().Contains(searchString) || a.Flat.Id.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "dates_desc":
                    dogovor = dogovor.OrderByDescending(a => a.DateStart);
                    break;
                case "Datef":
                    dogovor = dogovor.OrderBy(s => s.DateFinish).ThenBy(s => s.Id);
                    break;
                case "datef_desc":
                    dogovor = dogovor.OrderByDescending(s => s.DateFinish).ThenBy(s => s.Id);
                    break;
                case "Price":
                    dogovor = dogovor.OrderBy(s => s.Price).ThenBy(s => s.Id);
                    break;
                case "price_desc":
                    dogovor = dogovor.OrderByDescending(s => s.Price).ThenBy(s => s.Id);
                    break;
                case "Sotrudnik":
                    dogovor = dogovor.OrderBy(s => s.Sotrudnik).ThenBy(s => s.Id);
                    break;
                case "sotrudnik_desc":
                    dogovor = dogovor.OrderByDescending(s => s.Sotrudnik).ThenBy(s => s.Id);
                    break;
                case "Client":
                    dogovor = dogovor.OrderBy(s => s.Client).ThenBy(s => s.Id);
                    break;
                case "client_desc":
                    dogovor = dogovor.OrderByDescending(s => s.Client).ThenBy(s => s.Id);
                    break;
                case "Flat":
                    dogovor = dogovor.OrderBy(s => s.Flat).ThenBy(s => s.Id);
                    break;
                case "flat_desc":
                    dogovor = dogovor.OrderByDescending(s => s.Flat).ThenBy(s => s.Id);
                    break;


            }
            return View(dogovor.ToList());
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> SotrudnikList = _db.Sotrudnik.ToList().Select(u => new SelectListItem
            {
                Text = u.Fio,
                Value = u.Id.ToString()
            });
            ViewBag.SotrudnikList = SotrudnikList;

            IEnumerable<SelectListItem> clientsList = _db.Client.ToList().Select(u => new SelectListItem
            {
                Text = u.Passport,
                Value = u.Id.ToString()
            });
            ViewBag.clientsList = clientsList;

            IEnumerable<SelectListItem> FlatList = _db.Flat.ToList().Select(u => new SelectListItem
            {
                Text = u.FlatNumber.ToString(),
                Value = u.Id.ToString()
            });
            ViewBag.FlatList = FlatList;

            return View();
        }


        [HttpPost]
        public IActionResult Add(Dogovor Dogovor)
        {
            if (ModelState.IsValid)
            {
                _db.Dogovor.Add(Dogovor);
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

            Dogovor? DogovorDB = _db.Dogovor.Find(id);
            if (DogovorDB == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> SotrudnikList = _db.Sotrudnik.ToList().Select(u => new SelectListItem
            {
                Text = u.Fio,
                Value = u.Id.ToString()
            });
            ViewBag.SotrudnikList = SotrudnikList;

            IEnumerable<SelectListItem> clientsList = _db.Client.ToList().Select(u => new SelectListItem
            {
                Text = u.Passport,
                Value = u.Id.ToString()
            });
            ViewBag.clientsList = clientsList;

            IEnumerable<SelectListItem> FlatList = _db.Flat.ToList().Select(u => new SelectListItem
            {
                Text = u.FlatNumber.ToString(),
                Value = u.Id.ToString()
            });
            ViewBag.FlatList = FlatList;

            return View(DogovorDB);
        }

        [HttpPost]
        public IActionResult Edit(Dogovor Dogovor)
        {
            if (ModelState.IsValid)
            {

                _db.Dogovor.Update(Dogovor);
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

            Dogovor? DogovorDB = _db.Dogovor.Find(id);
            if (DogovorDB == null)
            {
                return NotFound();
            }
            return View(DogovorDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Dogovor? DogovorDB = _db.Dogovor.Find(id);
            if (DogovorDB == null)
            {
                return NotFound();
            }
            _db.Dogovor.Remove(DogovorDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
