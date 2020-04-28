using System.Web.Mvc;
using Umbraco.Web.Models;

namespace JuniorBuilder.Controllers
{
    public class LoginController : Umbraco.Web.Mvc.SurfaceController
    {
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            if (Members.Login(model.Username, model.Password))
            {
                return Redirect("/lessons");
            }

            ModelState.AddModelError("", "Invalid login");
            return CurrentUmbracoPage();
        }
    }
}