using JuniorBuilder.Models;
using System;
using System.Web.Mvc;

namespace JuniorBuilder.Controllers
{
    public class RegisterController : Umbraco.Web.Mvc.SurfaceController
    {
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }                          

            var memberService = Services.MemberService;

            if (memberService.GetByEmail(model.EmailAddress) != null)
            {
                ModelState.AddModelError("", "Member with that email already excists");
                return CurrentUmbracoPage();
            }

            try
            {
                var member = memberService.CreateMemberWithIdentity(model.EmailAddress, model.EmailAddress, model.Name, "member");
                member.SetValue("haveChildren", "NoChild");
                memberService.SavePassword(member, model.Password);
                Members.Login(model.EmailAddress, model.Password);
                memberService.Save(member);
                return Redirect("/your-kids");
            }
            catch (Exception)
            {     
                ModelState.AddModelError("", "Error occured while registering");
                return CurrentUmbracoPage();
            }  
        }
    }
}