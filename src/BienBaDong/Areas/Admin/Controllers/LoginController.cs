using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BienBaDong.Models;
namespace BienBaDong.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hiển thị form đăng nhập
        public ActionResult Index()
        {
            return View();
        }

        // POST: Xử lý khi bấm nút Đăng nhập
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var user = db.AdminAccounts.SingleOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(username, false);

                return RedirectToAction("Index", "Destinations");
            }

            ViewBag.Error = "Sai tài khoản hoặc mật khẩu!";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}