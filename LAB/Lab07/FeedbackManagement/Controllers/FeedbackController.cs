using Microsoft.AspNetCore.Mvc;
using FeedbackManagement.Models;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        private static List<Feedback> feedbackList = new List<Feedback>();

        public IActionResult Index()
        {
            return View(feedbackList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Id = feedbackList.Count + 1;
                feedbackList.Add(feedback);

                return RedirectToAction("Index");
            }

            return View(feedback);
        }

        public IActionResult Details(int id)
        {
            var feedback = feedbackList.FirstOrDefault(x => x.Id == id);

            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}