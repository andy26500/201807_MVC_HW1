using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using _201807_MVC_HW1.Models;

namespace _201807_MVC_HW1.Controllers
{
    public class CategoriesController : Controller
    {
        private CustomerEntities db = new CustomerEntities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.客戶分類.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶分類 客戶分類 = db.客戶分類.Find(id);
            if (客戶分類 == null)
            {
                return HttpNotFound();
            }

            return View(客戶分類);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,分類名稱,是否已刪除")] 客戶分類 客戶分類)
        {
            if (ModelState.IsValid)
            {
                db.客戶分類.Add(客戶分類);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶分類);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶分類 客戶分類 = db.客戶分類.Find(id);
            if (客戶分類 == null)
            {
                return HttpNotFound();
            }

            return View(客戶分類);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,分類名稱,是否已刪除")] 客戶分類 客戶分類)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶分類).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶分類);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶分類 客戶分類 = db.客戶分類.Find(id);
            if (客戶分類 == null)
            {
                return HttpNotFound();
            }

            return View(客戶分類);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶分類 客戶分類 = db.客戶分類.Find(id);
            db.客戶分類.Remove(客戶分類);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}