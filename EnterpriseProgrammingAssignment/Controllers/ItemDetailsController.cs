using EnterpriseProgrammingAssignment.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;


namespace EnterpriseProgrammingAssignment.Controllers
{
    public class ItemDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemDetails
        public ViewResult Index(string sortingOrder,string filter, string Search, int? pg)
        {
            ViewBag.CurrentSort = sortingOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortingOrder) ? "price" : "";

            if (Search != null)
            {
                pg = 1;
            }
            else
            {
                Search = filter;
            }

            ViewBag.CurrentFilter = Search;

            var items = from s in db.itemDetails
                           select s;

            if (!String.IsNullOrEmpty(Search))
            {
                items = items.Where(s => s.itemType.ItemName.Contains(Search) || s.itemType.category.CategoryName.Contains(Search));
            }

            switch (sortingOrder)
            {
                case "price":
                    items = items.OrderByDescending(s => s.Price);
                    break;
                default:
                    items = items.OrderBy(s => s.User_Id);
                    break;
            }

            int pgSize = 6;
            int pgNum = (pg ?? 1);
            return View(items.ToPagedList(pgNum, pgSize));
        }

        // GET: ItemDetails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetails itemDetails = db.itemDetails.Find(id);
            if (itemDetails == null)
            {
                return HttpNotFound();
            }
            return View(itemDetails);
        }

        // GET: ItemDetails/Create
        public ActionResult Create()
        {
            ViewBag.ItemType_Id = new SelectList(db.itemTypes, "ItemType_Id", "ItemName");
            ViewBag.Quality_Id = new SelectList(db.qualities, "Quality_Id", "QualityType");
            return View();
        }

        // POST: ItemDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item_Id,ItemType_Id,Quality_Id,Quantity,Price,User_Id")] ItemDetails itemDetails)
        {

            if (ModelState.IsValid)
            {
                itemDetails.User_Id = User.Identity.GetUserId();
                itemDetails.ItemType_Id = Convert.ToInt32(Request.Form["ItemType_Id"]);
                itemDetails.Quality_Id = Convert.ToInt32(Request.Form["Quality_Id"]);

                List<ItemDetails> itemList = db.itemDetails.Where(w => w.ApplicationUser.UserName == User.Identity.Name).Where(x => x.ItemType_Id == itemDetails.ItemType_Id).Where(y => y.Price == itemDetails.Price).Where(z => z.Quality_Id == itemDetails.Quality_Id).ToList();
                if(itemList.Count >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    db.itemDetails.Add(itemDetails);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ItemType_Id = new SelectList(db.itemTypes, "ItemType_Id", "ItemName", itemDetails.ItemType_Id);
            ViewBag.Quality_Id = new SelectList(db.qualities, "Quality_Id", "QualityType", itemDetails.Quality_Id);
            return View(itemDetails);
        }

        // GET: ItemDetails/Edit/5
        
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetails itemDetails = db.itemDetails.Find(id);
            if (itemDetails == null)
            {
                return HttpNotFound();
            }
            return View(itemDetails);
        }

        // POST: ItemDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Item_Id,ItemType_Id,Quality_Id,Quantity,Price,User_Id")] ItemDetails itemDetails)
        {
            if (itemDetails.User_Id == User.Identity.GetUserId())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(itemDetails).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Item Updated";
                    return RedirectToAction("Index");
                }
                return View(itemDetails);
            }
            else
            {
                ViewBag.error = "You cannot update other user's Items";
                return RedirectToAction("Index");
            }
        }

        // GET: ItemDetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDetails itemDetails = db.itemDetails.Find(id);
            if (itemDetails == null)
            {
                return HttpNotFound();
            }
            return View(itemDetails);
        }

        // POST: ItemDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ItemDetails itemDetails = db.itemDetails.Find(id);
            if (itemDetails.User_Id == User.Identity.GetUserId())
            {
                db.itemDetails.Remove(itemDetails);
                db.SaveChanges();
                ViewBag.Message = "Item Deleted";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "You cannot delete other user's Items";
                return RedirectToAction("Index");
            }
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
