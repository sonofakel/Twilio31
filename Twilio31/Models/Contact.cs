using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Twilio31.Models
{
	public class Contact
	{
		[Key]
		public int ContactId { get; set; }
		public string Number { get; set; }
		public string Name { get; set; }

		public static List<Contact> ContactList = new List<Contact> { };

		public Contact()
		{
		}


	}
}
