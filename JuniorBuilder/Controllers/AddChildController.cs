﻿using JuniorBuilder.Models;
using System;
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
                var member = memberService.CreateMemberWithIdentity(model.Name, kidsEmaill, model.Name, "newsMember");
                //memberService.SavePassword(member, model.Password);
                //Members.Login(model.EmailAddress, model.Password);

                //parentEmail
                member.SetValue("parentEmail", parentEmail);
                memberService.Save(member);
                return Redirect("/lessons");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occured while registering");
                return CurrentUmbracoPage();
            }
        }
    }
}