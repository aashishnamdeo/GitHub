using MessageBoard.Data;
using MessageBoard.Models;
using MessageBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private IMailService _mail;
        private IMessageBoardRepository _repo;

        public HomeController(IMailService mail, IMessageBoardRepository repo)
        {
            _mail = mail;
            _repo = repo;
        }

        public ActionResult Index()
        {
           var topic =  _repo.GetTopics()
                .OrderByDescending(t=> t.CreatedDate)
                .Take(25)
                .ToList();

            return View(topic);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult MyMessages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg =  model.ConstructEmail();            

            if(_mail.SentMail("abc@gmail.com", "abc@gmail.com", "Contact Us", msg))
            {
                ViewBag.MailSent = true;
            }

            return View();
        }
    }
}