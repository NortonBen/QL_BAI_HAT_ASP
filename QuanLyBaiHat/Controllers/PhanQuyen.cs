using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBaiHat.Models;

namespace QuanLyBaiHat.Controllers
{
    public class PhanQuyen : ActionFilterAttribute
    {
        private string[] admin = { "BaiHat", "CaSI", "User", "TacGia", "Slider", "Media" };
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string action = filterContext.ActionDescriptor.ActionName;
            string controll = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            var data = filterContext.RequestContext.HttpContext.Session["auth"];
            if(data == null)
            {
                filterContext.Result = new RedirectResult("~/Home/login");
                return;
            }

            User user = (User)data;
            if (user == null)
            {
                filterContext.Result = new RedirectResult("~/Home/login");
                return;
            }

            if (!admin.Contains(controll))
            {
                return;
            }

            DataContext db = new DataContext();
            var role = db.Roles.Where(t => t.User_id == user.Id).SingleOrDefault();
            if(role == null)
            {
                filterContext.Result = new RedirectResult("~/Loi/PhanQuyen");
                return;
            }

            if (role.permission.ToUpper() != "admin".ToUpper())
            {
                filterContext.Result = new RedirectResult("~/Loi/PhanQuyen");
                return;
            }

        }
    }
}