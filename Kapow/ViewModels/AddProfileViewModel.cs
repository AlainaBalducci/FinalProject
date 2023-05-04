using System;
using System.ComponentModel.DataAnnotations;

namespace Kapow.ViewModels
{
	public class AddProfileViewModel
	{
        [Required(ErrorMessage = "Please enter username")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your hometown")]
        public string? HomeBase { get; set; }

        [Url]
        public string? ImageUrl { get; set; }

        public AddProfileViewModel()
		{
		}

	}
}

