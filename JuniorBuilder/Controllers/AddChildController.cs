using Examine;
using Examine.Search;
using JuniorBuilder.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace JuniorBuilder.Controllers
{
    public class AddChildController : SurfaceController
    {
        public ActionResult AddChild(AddChildModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            var memberService = Services.MemberService;
            try
            {
                var parentProfile = System.Web.Security.Membership.GetUser();
                var parentEmail = parentProfile.Email;
                string trimpedName = model.Name.Replace(" ", "");
                var kidsEmaill = trimpedName + "@email.com";
                var member = memberService.CreateMemberWithIdentity(model.Name, kidsEmaill, model.Name, "childMember");                
                member.SetValue("parentEmail", parentEmail);
                member.SetValue("childPaymentStatus", "Unpaid");
                member.SetValue("childLessonsCompleted", "?");                
                memberService.Save(member);
                var parent =  memberService.GetByUsername(parentProfile.UserName);
                parent.SetValue("haveChildren", "HaveChild");
                memberService.Save(parent);
                return Redirect("/your-kids");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occured while adding a child");
                return CurrentUmbracoPage();
            }
        }
    }
}