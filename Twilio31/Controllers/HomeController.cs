using Microsoft.AspNetCore.Mvc;
using Twilio31.Models;

namespace Twilio31.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetMessages()
		{
			var allMessages = Message.GetMessages();
			return View(allMessages);
		}

		public IActionResult SendMessage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SendMessage(string[] formNum)
		{

			var from = formNum[0];
			var body = formNum[1];

			for (int i = 2; i < formNum.Length; i++)
			{
				Message message = new Message();
				message.From = from;
				message.Body = body;
				message.To = formNum[i];
				message.Send();

			}

			return RedirectToAction("Index");
		}
	}
}