using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using JuniorBuilder.Models;

namespace CodeShare.Controllers
{
    public class MemberController : SurfaceController
    {
        public ActionResult RenderLogout()
        {
            return PartialView("_Logout", null);
        }

        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            //return RedirectToCurrentUmbracoPage();
            return RedirectToUmbracoPage(1367);
        }
    }
}
