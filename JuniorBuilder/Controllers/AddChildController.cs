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
                var kidsEmaill = model.Name + "@email.com";
                var member = memberService.CreateMemberWithIdentity(model.Name, kidsEmaill, model.Name, "childMember");                
                member.SetValue("parentEmail", parentEmail);
                memberService.Save(member);
                //var allMembers = memberService.GetAllMembers().Where(m => m.ContentTypeAlias.Equals("parentEmail"));
                
                return Redirect("/lessons");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occured while adding a child");
                return CurrentUmbracoPage();
            }
        }
    }
}