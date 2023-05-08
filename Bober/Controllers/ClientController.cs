using Bober.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Bober.Controllers
{
    public class ClientController : Controller
    {
        public readonly BogbanContext _db;
        public ClientController(BogbanContext db) => _db = db;

        public IActionResult Index()
        {
            List<Client> clientsList = _db.Client.ToList();
            return View(clientsList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Client.Add(client);
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

            Client? clientDB = _db.Client.Find(id);
            if (clientDB == null)
            {
                return NotFound();
            }
            return View(clientDB);
        }

        [HttpPost]
        public IActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Client.Update(client);
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

            Client? clientDB = _db.Client.Find(id);
            if (clientDB == null)
            {
                return NotFound();
            }
            return View(clientDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Client? clientDB = _db.Client.Find(id);
            if (clientDB == null)
            {
                return NotFound();
            }
            _db.Client.Remove(clientDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
