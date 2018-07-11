using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using _201807_MVC_HW1.Models;

namespace _201807_MVC_HW1.Controllers
{
    public class ContactsController : Controller
    {
        private 客戶聯絡人Repository contactRepo;
        private 客戶資料Repository customerRepo;

        public ContactsController()
        {
            contactRepo = RepositoryHelper.Get客戶聯絡人Repository();
            customerRepo = RepositoryHelper.Get客戶資料Repository(contactRepo.UnitOfWork);
        }

        // GET: Contacts
        public ActionResult Index()
        {
            var contacts = contactRepo.All().Include(客 => 客.客戶資料);
            return View(contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶聯絡人 contact = contactRepo.Find(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(customerRepo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,是否已刪除")]
            客戶聯絡人 contact)
        {
            if (ModelState.IsValid)
            {
                contactRepo.Add(contact);
                contactRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(customerRepo.All(), "Id", "客戶名稱", contact.客戶Id);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶聯絡人 contact = contactRepo.Find(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            ViewBag.客戶Id = new SelectList(customerRepo.All(), "Id", "客戶名稱", contact.客戶Id);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,是否已刪除")]
            客戶聯絡人 contact)
        {
            if (ModelState.IsValid)
            {
                contactRepo.UnitOfWork.Context.Entry(contact).State = EntityState.Modified;
                contactRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(customerRepo.All(), "Id", "客戶名稱", contact.客戶Id);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶聯絡人 contact = contactRepo.Find(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 contact = contactRepo.Find(id);
            contactRepo.Delete(contact);
            contactRepo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contactRepo.UnitOfWork.Context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}