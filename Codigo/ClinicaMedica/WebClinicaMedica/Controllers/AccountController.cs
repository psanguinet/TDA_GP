using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using WebClinicaMedica.Models;
using DataAccess.Model;
using System.Web.Security;

namespace WebClinicaMedica.Controllers
{


    [Authorize]
    public partial class AccountController : Controller
    {
        private ClinicaMedicaEntities db = new ClinicaMedicaEntities();


        public AccountController(DataAccess.Model.Usuario userManager)
        {
            UserManager = userManager;
        }

        public AccountController()
        {
          
        }

        public DataAccess.Model.Usuario UserManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual  ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //var user = await UserManager.FindAsync(model.UserName, model.Password);
                var mUser = db.Usuario.SingleOrDefault(u => u.UserName == model.UserName && u.Password.Equals(model.Password));
                if (mUser != null)
                {
                    FormsAuthentication.SetAuthCookie(mUser.UserName, true);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Nombre de usuario o contrasena incorrecta.");
                    ViewBag.IsAutenticate = false;
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

      

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            return RedirectToAction(MVC.Account.ActionNames.Login, MVC.Account.Name);
        }
              


        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}