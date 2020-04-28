using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;

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
            return RedirectToUmbracoPage(1367);
        }
    }
}