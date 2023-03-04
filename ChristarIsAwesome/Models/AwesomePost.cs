using System;
using System.ComponentModel.DataAnnotations;

namespace ChristarIsAwesome.Models
{
	public class AwesomePost
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string post { get; set; }
		[Required]
		public string name { get; set; }
	}
}

