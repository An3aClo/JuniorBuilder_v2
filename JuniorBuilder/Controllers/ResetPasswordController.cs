using JuniorBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuniorBuilder.Controllers
{
    public class ResetPasswordController : Umbraco.Web.Mvc.SurfaceController
    {
        // GET: ResetPassword
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            var memberService = Services.MemberService;
            try
            {               
                var memberProfile = memberService.GetByEmail(model.EmailAddress);
                if (memberProfile != null)
                {
                    if(model.PasswordQuestionAnswer.ToLower().Equals(memberProfile.RawPasswordAnswerValue.ToLower()))
                    {
                        memberService.SavePassword(memberProfile, model.Password);
                        Members.Login(model.EmailAddress, model.Password);
                        memberService.Save(memberProfile);
                        return Redirect("/your-kids");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Security message does not match");
                        return CurrentUmbracoPage();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No such member");
                    return CurrentUmbracoPage();
                }
             
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occured while resetting password");
                return CurrentUmbracoPage();
            }
        }
    }
}