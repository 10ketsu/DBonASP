using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bober.Controllers
{
    public class BillController : Controller
    {
        public readonly BogbanContext _db;
        public BillController(BogbanContext db) => _db = db;
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["DatesSortParm"] = String.IsNullOrEmpty(sortOrder) ? "dates_desc" : "";
            ViewData["DatefSortParm"] = sortOrder == "Datef" ? "datef_desc" : "Datef";
            ViewData["SummSortParm"] = sortOrder == "Summ" ? "summ_desc" : "Summ";
            ViewData["DogovorSortParm"] = sortOrder == "Dogovor" ? "dogovor_desc" : "Dogovor";



            var bill = _db.Bill.Include(u => u.Dogovor).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                bill = bill.Where(a => a.DateStart.ToString().Contains(searchString) || a.DateFinish.ToString().Contains(searchString) || 
                a.Summ.ToString().Contains(searchString) || a.Dogovor.Id.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "dates_desc":
                    bill = bill.OrderByDescending(a => a.DateStart);
                    break;
                case "Datef":
                    bill = bill.OrderBy(s => s.DateFinish).ThenBy(s => s.Id);
                    break;
                case "datef_desc":
                    bill = bill.OrderByDescending(s => s.DateFinish).ThenBy(s => s.Id);
                    break;
                case "summ_desc":
                    bill = bill.OrderByDescending(s => s.Summ).ThenBy(s => s.Id);
                    break;
                case "Summ":
                    bill = bill.OrderBy(s => s.Summ).ThenBy(s => s.Id);
                    break;
                case "Dogovor":
                    bill = bill.OrderBy(s => s.Dogovor).ThenBy(s => s.Id);
                    break;
                case "dogovor_desc":
                    bill = bill.OrderByDescending(s => s.Dogovor).ThenBy(s => s.Id);
                    break;
            }
            return View(bill.ToList());
        }


        public IActionResult Add()
        {

            IEnumerable<SelectListItem> DogovorList = _db.Dogovor.ToList().Select(u => new SelectListItem
            {
                Text = u.Id.ToString(),
                Value = u.Id.ToString()
            });
            ViewBag.DogovorList = DogovorList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Bill Bill)
        {
            if (ModelState.IsValid)
            {
                _db.Bill.Add(Bill);
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

            Bill? BillDB = _db.Bill.Find(id);
            if (BillDB == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> DogovorList = _db.Dogovor.ToList().Select(u => new SelectListItem
            {
                Text = u.Id.ToString(),
                Value = u.Id.ToString()
            });
            ViewBag.DogovorList = DogovorList;

            return View(BillDB);
        }

        [HttpPost]
        public IActionResult Edit(Bill Bill)
        {
            if (ModelState.IsValid)
            {
                _db.Bill.Update(Bill);
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

            Bill? BillDB = _db.Bill.Find(id);
            if (BillDB == null)
            {
                return NotFound();
            }
            return View(BillDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Bill? BillDB = _db.Bill.Find(id);
            if (BillDB == null)
            {
                return NotFound();
            }
            _db.Bill.Remove(BillDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
