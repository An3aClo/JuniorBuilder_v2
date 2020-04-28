using JuniorBuilder.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

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

            var member = memberService.CreateMember(model.EmailAddress, model.EmailAddress, model.Name, "member");
            //memberService.SavePassword(member, model.Password);  --Does not work arent allowed
            Members.Login(model.EmailAddress, model.Password);
            memberService.Save(member);

            return Redirect("/lessons");
        }
    }
}