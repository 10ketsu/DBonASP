using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bober.Controllers
{
    public class PaymentController : Controller
    {
        public readonly BogbanContext _db;
        public PaymentController(BogbanContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["SummSortParm"] = sortOrder == "Summ" ? "summ_desc" : "Summ";
            ViewData["BillSortParm"] = sortOrder == "Bill" ? "bill_desc" : "Bill";



            var payment = _db.Payment.Include(u => u.Bill).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                payment = payment.Where(a => a.PaymentDate.ToString().Contains(searchString) || a.PaymentSumm.ToString().Contains(searchString) || a.Bill.Id.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "date_desc":
                    payment = payment.OrderByDescending(a => a.PaymentDate);
                    break;
                case "Summ":
                    payment = payment.OrderBy(s => s.PaymentSumm).ThenBy(s => s.Id);
                    break;
                case "summ_desc":
                    payment = payment.OrderByDescending(s => s.PaymentSumm).ThenBy(s => s.Id);
                    break;
                case "Bill":
                    payment = payment.OrderBy(s => s.Bill).ThenBy(s => s.Id);
                    break;
                case "bill_desc":
                    payment = payment.OrderByDescending(s => s.Bill).ThenBy(s => s.Id);
                    break;
            }
            return View(payment.ToList());
        }


        public IActionResult Add()
        {
            IEnumerable<SelectListItem> BillList = _db.Bill.ToList().Select(u => new SelectListItem
            {
                Text = u.Id.ToString(),
                Value = u.Id.ToString()
            });
            ViewBag.BillList = BillList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Payment Payment)
        {
            if (ModelState.IsValid)
            {
                _db.Payment.Add(Payment);
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

            Payment? PaymentDB = _db.Payment.Find(id);
            if (PaymentDB == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> BillList = _db.Bill.Select(u => new SelectListItem
            {
                Text = u.Summ.ToString(),
                Value = u.Id.ToString()
            });
            ViewData["BillList"] = BillList;

            return View(PaymentDB);
        }

        [HttpPost]
        public IActionResult Edit(Payment Payment)
        {
            if (ModelState.IsValid)
            {
                _db.Payment.Update(Payment);
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

            Payment? PaymentDB = _db.Payment.Find(id);
            if (PaymentDB == null)
            {
                return NotFound();
            }
            return View(PaymentDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Payment? PaymentDB = _db.Payment.Find(id);
            if (PaymentDB == null)
            {
                return NotFound();
            }
            _db.Payment.Remove(PaymentDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
