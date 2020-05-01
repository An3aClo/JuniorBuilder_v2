using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
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

        public ActionResult SubmitLevel()
        {
            var memberService = Services.MemberService;
            var Id = Request.RawUrl;
            var tempID = Id.Split('?').Last();
            int kidID = tempID.AsInt();
            var kid = Services.MemberService.GetById(kidID);
            var oldValue = kid.GetValue<string>("childLessonsCompleted");
            kid.SetValue("childLessonsCompleted", "?CompleteL");
            memberService.Save(kid);
            var newValue = kid.GetValue<string>("childLessonsCompleted");
            var completeEntry = oldValue + newValue;
            kid.SetValue("childLessonsCompleted", completeEntry);
            memberService.Save(kid);     
            return RedirectToUmbracoPage(1558);
        }

    }
}