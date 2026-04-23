using BienBaDong.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BienBaDong.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            // Lấy 3 điểm đến đang Active mới nhất để hiển thị ra trang chủ
            var destinations = db.Destinations
                                 .Where(d => d.IsActive)
                                 .OrderByDescending(d => d.Id)
                                 .Take(3)
                                 .ToList();
            return View(destinations);
        }

        public ActionResult Details(int id)
        {
            var destination = db.Destinations.FirstOrDefault(d => d.Id == id && d.IsActive);

            if (destination == null)
            {
                return RedirectToAction("Index");
            }

            destination.ViewCount++;
            db.SaveChanges();

            return View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(int DestinationId, string AuthorName, string Content)
        {
            if (!string.IsNullOrEmpty(AuthorName) && !string.IsNullOrEmpty(Content))
            {
                Comment newComment = new Comment
                {
                    DestinationId = DestinationId,
                    AuthorName = AuthorName,
                    Content = Content,
                    CreatedDate = DateTime.Now,
                    IsApproved = true
                };

                db.Comments.Add(newComment);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = DestinationId });
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "FullName,Email,Phone,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreatedDate = DateTime.Now;
                contact.IsRead = false; // Đánh dấu là chưa đọc

                db.Contacts.Add(contact);
                db.SaveChanges();

                // Gửi thông báo thành công ra View
                ViewBag.SuccessMessage = "Cảm ơn bạn! Lời nhắn đã được gửi thành công, chúng tôi sẽ liên hệ lại sớm nhất.";

                // Xóa trắng form sau khi gửi thành công
                ModelState.Clear();
                return View(new Contact());
            }

            return View(contact);
        }
    }
}