using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanGear
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{botdetect}",
                new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "GioHang", action = "ThemSanPham", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanGear.Controllers" }
            );
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "GioHang", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanGear.Controllers" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "GioHang", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanGear.Controllers" }
            );
            routes.MapRoute(
                name: "DangKy",
                url: "dang-ky",
                defaults: new { controller = "User", action = "DangKy", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanGear.Controllers" }
            );
            routes.MapRoute(
                name: "DangNhap",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "DangNhap", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanGear.Controllers" }
            );
            routes.MapRoute(
                name: "Mua Hang Thanh Cong",
                url: "hoan-thanh",
                defaults: new { controller = "GioHang", action = "SuccessPay", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanGear.Controllers" }
            );
            routes.MapRoute(
                name: "Mua Hang That Bai",
                url: "loi-thanh-toan",
                defaults: new { controller = "GioHang", action = "FailtPay", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanGear.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanGear.Controllers" }
            );

        }
    }
}
