using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dropbox.Api;
using Dropbox.Api.Files;
using EnterpriseProgrammingAssignment.Models;
using PagedList;

namespace EnterpriseProgrammingAssignment.Controllers
{
    public class ItemTypesController : Controller
    {
        static readonly string ApplicationName = "EdmondEnterpriseAssignment";
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemTypes
        public ViewResult Index(string sortingOrder, string filter, string Search, int? pg)
        {
            ViewBag.CurrentSort = sortingOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortingOrder) ? "itemName" : "";

            if (Search != null)
            {
                pg = 1;
            }
            else
            {
                Search = filter;
            }

            ViewBag.CurrentFilter = Search;

            var items = from s in db.itemTypes
                        select s;

            if (!String.IsNullOrEmpty(Search))
            {
                items = items.Where(s => s.ItemName.Contains(Search));
            }

            switch (sortingOrder)
            {
                case "itemName":
                    items = items.OrderByDescending(s => s.ItemName);
                    break;
                default:
                    items = items.OrderBy(s => s.category.CategoryName);
                    break;
            }

            int pgSize = 3;
            int pgNum = (pg ?? 1);
            return View(items.ToPagedList(pgNum,pgSize));
        }

        // GET: ItemTypes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTypes itemTypes = db.itemTypes.Find(id);
            if (itemTypes == null)
            {
                return HttpNotFound();
            }
            return View(itemTypes);
        }

        // GET: ItemTypes/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(db.categories, "Category_Id", "CategoryName");
            return View();
        }

        // POST: ItemTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemType_Id,Category_Id,ItemName,ImageUrl")] ItemTypes itemTypes)
        {
            if (!ModelState.IsValid)
            {

                string accessToken = "qJwkZLnkrnAAAAAAAAAAM5cYlNmKG_S7yEWJalqNYZKgMm_nQ9OlXPK50EkuuWI2";
                
                using (DropboxClient client = new DropboxClient(accessToken, new DropboxClientConfig(ApplicationName)))
                {
                    HttpPostedFileBase file = Request.Files["file"];
                    string[] splitInputFileName = file.FileName.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
                    string fileNameAndExtension = splitInputFileName[splitInputFileName.Length - 1];

                    string[] fileNameAndExtensionSplit = fileNameAndExtension.Split('.');
                    string originalFileName = fileNameAndExtensionSplit[0];
                    string originalExtension = fileNameAndExtensionSplit[1];


                    string fileName = @"/Images/" + originalFileName + Guid.NewGuid().ToString().Replace("-", "") + "." + originalExtension;

                    var updated = client.Files.UploadAsync(
                                    fileName,
                                    mode: WriteMode.Overwrite.Overwrite.Instance,
                                    body: file.InputStream).Result;

                    var result = client.Sharing.CreateSharedLinkWithSettingsAsync(fileName).Result;
                    string[] newUrl = result.Url.Split('?');
                    string newestUrl = newUrl[0] + "?dl=1";

                    itemTypes.ImageUrl = newestUrl;
                    db.itemTypes.Add(itemTypes);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                
            }
            ViewBag.Category_Id = new SelectList(db.categories, "Category_Id", "CategoryName", itemTypes.Category_Id);
            return View(itemTypes);
        }

        // GET: ItemTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTypes itemTypes = db.itemTypes.Find(id);
            if (itemTypes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.categories, "Category_Id", "CategoryName");
            return View(itemTypes);
        }

        // POST: ItemTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemType_Id,Category_Id,ItemName,ImageUrl")] ItemTypes itemTypes)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Request.Form.Get("Category_Id").ToString();
                    db.Entry(itemTypes).State = EntityState.Modified;
                    string accessToken = "qJwkZLnkrnAAAAAAAAAAM5cYlNmKG_S7yEWJalqNYZKgMm_nQ9OlXPK50EkuuWI2";

                    using (DropboxClient client = new DropboxClient(accessToken, new DropboxClientConfig(ApplicationName)))
                    {
                        HttpPostedFileBase file = Request.Files["file"];
                        string[] splitInputFileName = file.FileName.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
                        string fileNameAndExtension = splitInputFileName[splitInputFileName.Length - 1];

                        string[] fileNameAndExtensionSplit = fileNameAndExtension.Split('.');
                        string originalFileName = fileNameAndExtensionSplit[0];
                        string originalExtension = fileNameAndExtensionSplit[1];


                        string fileName = @"/Images/" + originalFileName + Guid.NewGuid().ToString().Replace("-", "") + "." + originalExtension;

                        var updated = client.Files.UploadAsync(
                                        fileName,
                                        mode: WriteMode.Overwrite.Overwrite.Instance,
                                        body: file.InputStream).Result;

                        var result = client.Sharing.CreateSharedLinkWithSettingsAsync(fileName).Result;
                        string[] newUrl = result.Url.Split('?');
                        string newestUrl = newUrl[0] + "?dl=1";

                        itemTypes.ImageUrl = newestUrl;
                        db.itemTypes.Add(itemTypes);
                        
                        List<ItemTypes> itemTypeList = db.itemTypes.Where(w => w.Category_Id == itemTypes.Category_Id).Where(x => x.ItemName == itemTypes.ItemName).ToList();
                        if (itemTypeList.Count >= 1)
                        {
                            Delete(itemTypes.ItemType_Id);
                        }
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Please upload an image!";
                return RedirectToAction("Edit");
            }
            return View(itemTypes);
        }

        // GET: ItemTypes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTypes itemTypes = db.itemTypes.Find(id);
            if (itemTypes == null)
            {
                return HttpNotFound();
            }
            return View(itemTypes);
        }

        // POST: ItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ItemTypes itemTypes = db.itemTypes.Find(id);

            db.itemTypes.Remove(itemTypes);
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
