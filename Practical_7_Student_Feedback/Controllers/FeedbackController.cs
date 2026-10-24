using P7_Student_Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P7_Student_Feedback.Controllers
{
    public class FeedbackController : Controller
    {
        public static List<Feedback> feedbackList = new List<Feedback>();
 
        public ActionResult Index()
        {
            return View(feedbackList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);
                return RedirectToAction("List");
            }

            return View(feedback);
        }

        public ActionResult List()
        {
            return View(feedbackList);
        }
    }
}