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
            var url = Request.RawUrl;
            var tempID = url.Split('?').Last();
            int kidID = tempID.AsInt();
            var kid = Services.MemberService.GetById(kidID);
            var urlEntries = url.Split('/');
            var lessonName = urlEntries[2].ToString();

            var oldValue = kid.GetValue<string>("childLessonsCompleted");
            if (oldValue != null)
            {
                var arrayOfAllOldValues = oldValue.Split('?');
                if (!arrayOfAllOldValues.Contains(lessonName))
                {
                    var saveValue = "?" + lessonName;
                    kid.SetValue("childLessonsCompleted", saveValue);
                    memberService.Save(kid);
                    var newValue = kid.GetValue<string>("childLessonsCompleted");
                    var completeEntry = oldValue + newValue;
                    kid.SetValue("childLessonsCompleted", completeEntry);
                    memberService.Save(kid);
                }
                else
                {                    
                    return CurrentUmbracoPage();
                }
            }
            return RedirectToUmbracoPage(1558);
        }

    }
}