using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio31.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Twilio31.Controllers
{
	public class ContactsController : Controller
	{
        Twilio31Context db = new Twilio31Context();

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View(db.Contacts.ToList());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Contact contact)
		{
            
			const string accountSid = "ACbdad9a7a5b65ad655c501ef37ee0375f";
			const string authToken = "ac924cd3e5aca5f62680c3f4f0e16721";
			TwilioClient.Init(accountSid, authToken);

			var phoneNumber = new PhoneNumber(contact.Number);
			var validationRequest = ValidationRequestResource.Create(
				phoneNumber,
				friendlyName: contact.Name);

			var myValidation = (validationRequest.ValidationCode);


			db.Add(contact);
            db.SaveChanges();

			return Json(myValidation);
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

      

        public PartialViewResult ContactMessagePartial(string number)
        {
			const string accountSid = "ACbdad9a7a5b65ad655c501ef37ee0375f";
			const string authToken = "ac924cd3e5aca5f62680c3f4f0e16721";
			TwilioClient.Init(accountSid, authToken);

            var messages = MessageResource.Read(
                to: new PhoneNumber(number)

            );
            ViewBag.Messages = messages;
            return PartialView();
                
        }


	}
}
