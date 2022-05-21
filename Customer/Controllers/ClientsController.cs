using Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClientsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Clients> client = _db.clients;
            return View(client);
        }

       //Get(Create)
        public IActionResult Create()
        {
            
            return View();
        }

        //Post(Add_New)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Clients obj)
        {
            if (ModelState.IsValid)
            {
                _db.clients.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        

        //Get(Show)
        public IActionResult UpdateClients(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var clientsFromDb = _db.clients.Find(id);
            
            if(clientsFromDb == null)
            {
                return NotFound();
            }

            return View(clientsFromDb);
        }


        //post(Add Data)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateClients(Clients obj)
        {
            if(obj.Name == obj.Contact_No.ToString())
            {
                ModelState.AddModelError("Name", "The Contect number connot exactly match the name.");
            }
            
            if (ModelState.IsValid)
            {
                _db.clients.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }




        //Get(Show)
        public IActionResult DeleteClients(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var clientsFromDb = _db.clients.Find(id);

            if (clientsFromDb == null)
            {
                return NotFound();
            }

            return View(clientsFromDb);
        }


        //post(Add Data)
        [HttpPost,ActionName("DeleteClients")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteClient(int? id)
        {
            var obj = _db.clients.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            
                _db.clients.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           
            
        }



    }
}
