using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseProgrammingAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize()]
        public ActionResult Secret()
        {
            return Content("The secret Password - accessable to logged in users");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult TopSecret()
        {
            return Content("The secret Password");
        }

        [HttpGet]
        public ActionResult UploadImage()
        {
            return View();
        }

        static readonly string ApplicationName = "EdmondEnterpriseAssignment";

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            string accessToken = "phy9pu20yx0reqa";
            using (DropboxClient client = new DropboxClient(accessToken, new DropboxClientConfig(ApplicationName)))
            {
                string[] splitInputFileName = file.FileName.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
                string fileNameAndExtension = splitInputFileName[splitInputFileName.Length - 1];

                string[] fileNameAndExtensionSplit = fileNameAndExtension.Split('.');
                string originalFileName = fileNameAndExtensionSplit[0];
                string originalExtension = fileNameAndExtensionSplit[1];


                String fileName = @"/Images/" + originalFileName + Guid.NewGuid().ToString().Replace("-", "") + originalExtension;
                var updated = client.Files.UploadAsync(
                                fileName,
                                mode: WriteMode.Overwrite.Overwrite.Instance,
                                body: file.InputStream).Result;

                var result = client.Sharing.CreateSharedLinkWithSettingsAsync(fileName).Result;

                return RedirectToAction("View", "Home", new { ImageUrl = result.Url });
            }

        }

        public ActionResult ViewImage(String imageUrl)
        {
            throw new NotImplementedException();
        }
    }
}