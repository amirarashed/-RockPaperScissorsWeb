using Microsoft.AspNetCore.Mvc;

namespace RockPaperScissorsWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Wins = TempData["Wins"] ?? 0;
            ViewBag.Losses = TempData["Losses"] ?? 0;
            ViewBag.Ties = TempData["Ties"] ?? 0;

            TempData.Keep();
            return View();
        }

        [HttpPost]
        public IActionResult Play(string userChoice)
        {
            string[] options = { "Rock", "Paper", "Scissors" };
            Random rand = new Random();
            string computerChoice = options[rand.Next(3)];

            int wins = Convert.ToInt32(TempData["Wins"] ?? 0);
            int losses = Convert.ToInt32(TempData["Losses"] ?? 0);
            int ties = Convert.ToInt32(TempData["Ties"] ?? 0);

            string result = "";

            if (userChoice == computerChoice)
            {
                result = "It's a Tie!";
                ties++;
            }
            else if (
                (userChoice == "Rock" && computerChoice == "Scissors") ||
                (userChoice == "Paper" && computerChoice == "Rock") ||
                (userChoice == "Scissors" && computerChoice == "Paper")
            )
            {
                result = "You Win!";
                wins++;
            }
            else
            {
                result = "You Lose!";
                losses++;
            }

            TempData["Wins"] = wins;
            TempData["Losses"] = losses;
            TempData["Ties"] = ties;

            ViewBag.User = userChoice;
            ViewBag.Computer = computerChoice;
            ViewBag.Result = result;

            ViewBag.Wins = wins;
            ViewBag.Losses = losses;
            ViewBag.Ties = ties;

            ViewBag.Start = true;
            return View("Index");
        }

        public IActionResult Reset()
        {
            TempData["Wins"] = 0;
            TempData["Losses"] = 0;
            TempData["Ties"] = 0;
            return RedirectToAction("Index");
        }
    }
}